using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;

namespace PigPalaceAPI.Repository.FarmRepo
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PigPalaceDBContext _context;

        public AccountRepository(PigPalaceDBContext context)
        {
            _context = context;
        }
        public async Task<string> FbSignIn(string FBID)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.FBID == FBID);
            if (account == null)
            {
                var newAccount = new Account
                {
                    AccountID = Guid.NewGuid(),
                    FBID = FBID,
                    IsFromFB = true
                };
                await _context.Accounts.AddAsync(newAccount);
                await _context.SaveChangesAsync();
                return newAccount.AccountID.ToString();
            }
            return account.AccountID.ToString();
        }

        public async Task<string> GoogleSignIn(string GoogleID)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.GoogleID == GoogleID);   
            if (account == null)
            {
                var newAccount = new Account
                {
                    AccountID = Guid.NewGuid(),
                    GoogleID = GoogleID,
                    IsFromGoogle = true
                };
                await _context.Accounts.AddAsync(newAccount);
                await _context.SaveChangesAsync();
                return newAccount.AccountID.ToString(); 
            }
            return account.AccountID.ToString(); 
        }

        public async Task<string> NormalSignIn(string Gmail, string PassWord)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Gmail == Gmail && x.PassWord == PassWord);
            if (account == null)
            {
                return "Invalid Credentials";
            }
            return account.AccountID.ToString();    
        }

        public async Task<string> SignUp(string Gmail, string PassWord)
        {
            var validEmail = await _context.Accounts.FirstOrDefaultAsync(x => x.Gmail == Gmail);
            if (validEmail != null)
            {
                return "Email already exists";
            }
            var account = new Account
            {
                AccountID = Guid.NewGuid(),
                Gmail = Gmail,
                PassWord = PassWord
            };
            await _context.Accounts.AddAsync(account); 
            await _context.SaveChangesAsync();
            return account.AccountID.ToString();
        }

        public async Task<string> UpgradeAccount(string AccountID)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountID.ToString() == AccountID);
            if (account == null)
            {
                return "Account not found";
            }
            account.IsPremium = true;
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return "Account upgraded to premium";
        }
    }
}
