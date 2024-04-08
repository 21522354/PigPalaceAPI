using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;

namespace PigPalaceAPI.Repository.FarmRepo
{
    public class FarmRepository : IFarmRepository
    {
        private readonly PigPalaceDBContext _context;

        public FarmRepository(PigPalaceDBContext context)
        {
            _context = context;
        }

        public async Task<string> FbSignIn(string FBID)
        {
            var PigFarm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FBID == FBID);
            if (PigFarm == null)
            {
                return "Invalid Credentials";
            }   
            return "Login Successful";
        }

        public async Task<string> GoogleSignIn(string GoogleID)
        {
            var PigFarm = await _context.PigFarms.FirstOrDefaultAsync(x => x.GoogleID == GoogleID);   
            if (PigFarm == null)
            {
                return "Invalid Credentials";
            }
            return "Login Successful";  
        }

        public async Task<string> NormalSignIn(string Gmail, string PassWord)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.Gmail == Gmail && x.PassWord == PassWord);
            if (farm == null)
            {
                return "Invalid Credentials";
            }
            return "Login Successful";  
        }

        public async Task<string> SignUp(string Name, string Gmail, string PassWord)
        {
            var validEmail = await _context.PigFarms.FirstOrDefaultAsync(x => x.Gmail == Gmail);
            if (validEmail != null)
            {
                return "Email already exists";
            }
            var farm = new PigFarm
            {
                FarmID = Guid.NewGuid(),
                Name = Name,
                Gmail = Gmail,
                PassWord = PassWord
            };
            await _context.PigFarms.AddAsync(farm); 
            await _context.SaveChangesAsync();
            return "Registration Successful";
        }
    }
}
