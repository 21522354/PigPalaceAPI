using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigPalaceAPI.Repository.FarmRepo;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;

        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
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
        public async Task<IActionResult> GoogleSignIn(string GoogleID)
        {
            var result = await _repository.GoogleSignIn(GoogleID);
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
    }
}
