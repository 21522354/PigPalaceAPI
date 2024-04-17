using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
        public async Task<string> DeleteUser(int userID)
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

        public async Task<User> GetUserByID(int ID)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == ID);
            return user;
        }
        private async Task<string> GenerateToken(User user)
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
                    new Claim("UserID", user.UserID.ToString())
                }),
                // thời gian sống của token
                Expires = DateTime.UtcNow.AddMinutes(20),
                // ký vào token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secterKeyByte), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var accessToken = jwtTokenHandler.WriteToken(token);
            return accessToken;
        }

        public async Task<APIRespond> SignIn(int userID, string password)
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

        public async Task<string> UpdateUser(UserModel user, int userID)
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
