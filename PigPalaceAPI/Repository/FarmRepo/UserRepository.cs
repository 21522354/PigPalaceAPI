using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PigPalaceAPI.Repository.FarmRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly PigPalaceDBContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(PigPalaceDBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<string> DeleteUser(Guid userID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == userID);  
            if (user == null)
            {
                return "User does not exist";
            }
            _context.Users.Remove(user);        
            await _context.SaveChangesAsync();      
            return "User deleted successfully"; 
        }

        public async Task<List<User>> GetUserByFarmID(Guid FarmID)
        {
            var users = await _context.Users.Where(x => x.FarmID == FarmID).ToListAsync();     
            return users;   
        }

        public async Task<User> GetUserByID(Guid ID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == ID);
            return user;
        }
        #region Token
        private async Task<TokenModel> GenerateToken(User user)
        {
            // phát sinh token và trả về cho người dùng sau khi đăng nhập thành công
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["AppSettings:SecretKey"];
            var secterKeyByte = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // nội dung của token   
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserID", user.UserID.ToString()),
                    // role

                }),
                // thời gian sống của token
                Expires = DateTime.UtcNow.AddHours(1),
                // ký vào token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secterKeyByte), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefeshToken();
            // lưu database
            var RefreshToken = new RefreshToken
            {
                Token = refreshToken,
                UserID = user.UserID,
                JwtID = token.Id,
                IsUsed = false,
                IsRevoked = false,
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddHours(1)
            };

            await _context.RefreshTokens.AddAsync(RefreshToken);
            await _context.SaveChangesAsync();

            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
        private string GenerateRefeshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                var refreshToken = Convert.ToBase64String(randomNumber);
                return refreshToken;
            }
        }
        public async Task<APIRespond2> RenewToken(TokenModel model)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = _configuration["AppSettings:SecretKey"];
            var secterKeyByte = Encoding.UTF8.GetBytes(secretKey);
            var tokenValidateParam = new TokenValidationParameters
            {
                // tự cấp token nên validate = false
                ValidateIssuer = false,
                ValidateAudience = false,
                // có thể sử dụng các dịch vụ cấp token như OAuth2

                // ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secterKeyByte),

                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false // không kiểm tra thời gian sống của token

            };
            try
            {
                // kiểm tra format token
                var tokenVerification = jwtTokenHandler.ValidateToken(model.AccessToken, tokenValidateParam, out var validatedToken);
                // Kiểm tra thuật toán
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (result == false)
                    {
                        return new APIRespond2
                        {
                            Status = false,
                            Message = "Invalid token"
                        };
                    }
                }
                // kiểm tra token đã hết hạn chưa
                var utcExpiryDate = long.Parse(tokenVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expireDate = UnixTimeStampToDateTime(utcExpiryDate);
                if ((DateTime)expireDate > DateTime.UtcNow)
                {
                    return new APIRespond2
                    {
                        Status = false,
                        Message = "This token has not expired yet"
                    };
                }
                // Kiểm tra refresh token có tồn tại trong db không
                var storedToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == model.RefreshToken);
                if (storedToken == null)
                {
                    return new APIRespond2
                    {
                        Status = false,
                        Message = "Refresh token not found"
                    };
                }
                // Kiểm tra refresh token đã sử dụng chưa
                if (storedToken.IsUsed)
                {
                    return new APIRespond2
                    {
                        Status = false,
                        Message = "Refresh token has been used"
                    };
                }
                // Kiểm tra đã bị thu hồi chưa
                if (storedToken.IsRevoked)
                {
                    return new APIRespond2
                    {
                        Status = false,
                        Message = "Refresh token has been revoked"
                    };
                }
                // Kiểm tra AccessToken id == jwtID in RefreshToken 
                var jti = tokenVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtID != jti)
                {
                    return new APIRespond2
                    {
                        Status = false,
                        Message = "Refresh token does not match this JWT token"
                    };
                }
                // update Token đã sử dụng
                storedToken.IsUsed = true;
                storedToken.IsRevoked = true;
                _context.RefreshTokens.Update(storedToken);
                await _context.SaveChangesAsync();

                // cấp token mới    
                var user = await _context.Users.SingleOrDefaultAsync(x => x.UserID == storedToken.UserID);
                var Token = await GenerateToken(user);


                return new APIRespond2
                {
                    Status = true,
                    Message = "Renew Token Success",
                    Data = Token
                };
            }
            catch
            {
                return new APIRespond2
                {
                    Status = false,
                    Message = "SomeThing went wrong"
                };
            }
        }
        private object UnixTimeStampToDateTime(long utcExpiryDate)
        {
            DateTime dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval = dateTimeInterval.AddSeconds(utcExpiryDate).ToUniversalTime();

            return dateTimeInterval;
        }
        #endregion

        public async Task<APIRespond> SignIn(Guid userID, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == userID && x.PassWord == password);
            if (user == null)
            {
                return new APIRespond
                {
                    Status = false,
                    Message = "Invalid Credentials"
                };
            }
            return new APIRespond
            {
                UserID = user.UserID,   
                Status = true,
                Message = "Login successful",
                Data = await GenerateToken(user)
            };
        }

        public async Task<APIRespond> SignUp(UserModel user)
        {
            try
            {
                var ressult = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == user.FarmID);
                if(ressult == null)
                {
                    return new APIRespond
                    {
                        Status = false,
                        Message = "Farm does not exist"
                    };
                }   
                var newUser = new User
                {
                    UserID = Guid.NewGuid(),
                    FarmID = user.FarmID,
                    Name = user.Name,
                    PassWord = user.PassWord,
                    DateOfBirth = user.DateOfBirth,
                    Address = user.Address,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                };
                if (user.RoleID != null)
                {
                    newUser.RoleID = user.RoleID;
                    newUser.Role = await _context.Roles.FirstOrDefaultAsync(x => x.RoleID == user.RoleID);
                }
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return new APIRespond { UserID = newUser.UserID ,Status = true, Message = "Login successful", Data = await GenerateToken(newUser) };
            }
            catch
            {
                return new APIRespond() { Status = false, Message = "Sign up failed" };
            }
            
        }

        public async Task<string> UpdateUser(UserModel user, Guid userID)
        {
            try
            {
                var ressult = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == user.FarmID);
                if (ressult == null)
                {
                    return "Farm does not exist";
                }
                var oldUser = await _context.Users.FirstOrDefaultAsync(x => x.UserID == userID);   
                if (oldUser == null)
                {
                    return "User does not exist";
                }
                oldUser.FarmID = user.FarmID;   
                oldUser.Name = user.Name;
                oldUser.PassWord = user.PassWord;
                oldUser.DateOfBirth = user.DateOfBirth;
                oldUser.Address = user.Address;
                oldUser.Email = user.Email;
                oldUser.PhoneNumber = user.PhoneNumber;
                if(user.RoleID != null)
                {
                    oldUser.RoleID = user.RoleID;
                    oldUser.Role = await _context.Roles.FirstOrDefaultAsync(x => x.RoleID == user.RoleID);
                }   
                await _context.SaveChangesAsync();
                return "User updated successfully";
            }
            catch
            {
                return "User update failed";
            }
        }
    }
}
