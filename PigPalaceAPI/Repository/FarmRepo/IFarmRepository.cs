using Microsoft.AspNetCore.Mvc;

namespace PigPalaceAPI.Repository.FarmRepo
{
    public interface IFarmRepository
    {
        public Task<string> NormalSignIn(string Gmail, string PassWord);
        public Task<string> GoogleSignIn(string GoogleID);  
        public Task<string> FbSignIn(string FBID); 
        public Task<string> SignUp(string Name, string Gmail, string PassWord);

    }
}
