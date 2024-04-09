using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;

namespace PigPalaceAPI.Repository.FarmRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly PigPalaceDBContext _context;

        public UserRepository(PigPalaceDBContext context)
        {
            _context = context;
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

        public async Task<string> SignIn(int userID, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == userID && x.PassWord == password);
            if (user == null)
            {
                return "Invalid Credentials";
            }
            return "Login Successful";  
        }

        public async Task<string> SignUp(UserModel user)
        {
            try
            {
                var ressult = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == user.FarmID);
                if(ressult == null)
                {
                    return "Farm does not exist";
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
                return "User created successfully";
            }
            catch
            {
                return "User creation failed";
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
