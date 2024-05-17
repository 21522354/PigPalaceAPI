using Microsoft.AspNetCore.Mvc;

namespace PigPalaceAPI.Repository.FarmRepo
{
    public interface IAccountRepository
    {
        public Task<string> NormalSignIn(string Gmail, string PassWord);
        public Task<string> GoogleSignIn(string GoogleID);  
        public Task<string> FbSignIn(string FBID); 
        public Task<string> SignUp(string Gmail, string PassWord);
        public Task<string> UpgradeAccount(string AccountID);

    }
}
