using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;

namespace PigPalaceAPI.Repository.FarmRepo
{
    public interface IUserRepository
    {
        public Task<User> GetUserByID(int ID);
        public Task<List<User>> GetUserByFarmID(Guid FarmID);
        public Task<APIRespond> SignIn(int userID, string password);    
        public Task<APIRespond> SignUp(UserModel user);      
        public Task<string> UpdateUser(UserModel user, int userID);    
        public Task<string> DeleteUser(int userID);     
    }
}
