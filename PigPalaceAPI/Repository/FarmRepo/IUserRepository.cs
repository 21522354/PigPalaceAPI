using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;

namespace PigPalaceAPI.Repository.FarmRepo
{
    public interface IUserRepository
    {
        public Task<User> GetUserByID(Guid ID);
        public Task<List<User>> GetUserByFarmID(Guid FarmID);
        public Task<APIRespond> SignIn(Guid userID, string password);    
        public Task<APIRespond> SignUp(UserModel user);      
        public Task<string> UpdateUser(UserModel user, Guid userID);    
        public Task<string> DeleteUser(Guid userID);
        public Task<APIRespond2> RenewToken(TokenModel tokenModel);
    }
}
