using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Repository.FarmRepo;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;
        private readonly PigPalaceDBContext _context;

        public AccountController(IAccountRepository repository, PigPalaceDBContext context)
        {
            _repository = repository;
            _context = context;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(string Gmail, string PassWord)
        {
            var result = await _repository.SignUp(Gmail, PassWord); 
            if(result == "Account already exists")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("NormalSignIn")]
        public async Task<IActionResult> NormalSignIn(string Gmail, string PassWord)
        {
            var result = await _repository.NormalSignIn(Gmail, PassWord);
            if (result == "Invalid Credentials")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("GoogleSignIn")]
        public async Task<IActionResult> GoogleSignIn(string GoogleID, string Gmail)
        {
            var result = await _repository.GoogleSignIn(GoogleID, Gmail);
            return Ok(result);
        }
        [HttpPost("FbSignIn")]
        public async Task<IActionResult> FbSignIn(string FBID)
        {
            var result = await _repository.FbSignIn(FBID);
            return Ok(result);
        }
        [HttpPut("UpgradeAccount")]
        public async Task<IActionResult> UpgradeAccount(string AccountID)
        {
            var result = await _repository.UpgradeAccount(AccountID);
            return Ok(result);
        }
        [HttpGet("GetIsUpgraded")]
        public async Task<IActionResult> GetIsUpgraded(Guid AccountID)
        {
            var result = await _context.Accounts.FindAsync(AccountID);
            if (result == null)
            {
                return BadRequest("Account not found");
            }
            return Ok(result.IsPremium);
        }
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string Gmail, string NewPassword)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.Gmail == Gmail);
            if(account == null)
            {
                return BadRequest("Account not found");
            }
            account.PassWord = NewPassword;
            await _context.SaveChangesAsync();
            return Ok("Password reset successfully");
        }
    }
}
