using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigPalaceAPI.Repository.FarmRepo;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly IFarmRepository _farmRepository;

        public FarmController(IFarmRepository farmRepository)
        {
            _farmRepository = farmRepository;
        }

        [HttpPost("NormalSignIn")]
        public async Task<IActionResult> NormalSignIn(string Gmail, string PassWord)
        {
            var result = await _farmRepository.NormalSignIn(Gmail, PassWord);
            if(result == "Invalid Credentials")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(string Name, string Gmail, string PassWord)
        {
            var result = await _farmRepository.SignUp(Name, Gmail, PassWord);
            if(result == "Email already exists")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("GoogleSignIn")]
        public async Task<IActionResult> GoogleSignIn(string GoogleID)
        {
            var result = await _farmRepository.GoogleSignIn(GoogleID);
            if(result == "Invalid Credentials")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("FbSignIn")]
        public async Task<IActionResult> FbSignIn(string FBID)
        {
            var result = await _farmRepository.FbSignIn(FBID);
            if(result == "Invalid Credentials")
            {
                return BadRequest(result);
            }   
            return Ok(result);
        }   
    }
}
