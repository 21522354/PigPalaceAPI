using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;
using PigPalaceAPI.Repository.FarmRepo;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }
        [HttpGet("GetUserByID")]    
        public async Task<IActionResult> GetUserByID(int ID)
        {
            var user = await _userRepository.GetUserByID(ID);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("GetUsersByFarmID")]
        public async Task<IActionResult> GetUsersByFarmID(Guid farmID)
        {
            var users = await _userRepository.GetUserByFarmID(farmID);  
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);   
        }
        [HttpDelete("DeleteUser")]  
        public async Task<IActionResult> DeleteUser(int userID)
        {
            var result = await _userRepository.DeleteUser(userID);
            if (result == "User does not exist")
            {
                return NotFound();
            }
            return Ok(result);  
        }
        [HttpPut("UpdateUser")]    
        public async Task<IActionResult> UpdateUser(UserModel userModel, int UserID)
        {
            var result = await _userRepository.UpdateUser(userModel, UserID);
            if (result == "Farm does not exist" || result == "User update failed" || result == "User does not exist")
            {
                return NotFound(result);
            }
            return Ok(result);  
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(int UserID, string PassWord)
        {
            var result = await _userRepository.SignIn(UserID, PassWord);
            if (result.Message == "Invalid Credentials")
            {
                return Unauthorized();
            }
            return Ok(result);  
        }
        [HttpPost("SignUp")]    
        public async Task<IActionResult> SignUp(UserModel user)
        {
            var result = await _userRepository.SignUp(user);
            if(result.Message == "Farm does not exist")
            {
                return BadRequest("Farm does not exist");
            }
            if(result.Message == "Sign up failed")
            {
                return BadRequest("Sign Up failed");
            }
            return Ok(result);  
        }
        [HttpPost("RefreshToken")]  
        public async Task<IActionResult> RefreshToken(TokenModel token)
        {
            var result = await _userRepository.RenewToken(token);
            if (result.Status == false)
            {
                return Unauthorized(result);
            }
            return Ok(result);  
        }
    }
}
