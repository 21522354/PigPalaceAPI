using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Repository.FarmRepo;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;

        public FarmController(PigPalaceDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetFarm")]
        public async Task<IActionResult> GetFarm(Guid AccountID)
        {
            var listFarm = await _context.PigFarms.Where(p => p.AccountID == AccountID).ToListAsync();
            return Ok(listFarm);
        }
        [HttpPost("CreateFarm")]
        public async Task<IActionResult> CreateFarm(Guid AccountID, string name)
        {
            PigFarm farm = new PigFarm
            {
                FarmID = Guid.NewGuid(),
                Name = name,
                AccountID = AccountID
            };
            await _context.PigFarms.AddAsync(farm);
            await _context.SaveChangesAsync();
            return Ok(farm.FarmID.ToString());  
        }
        [HttpPut("ChangeName")]    
        public async Task<IActionResult> ChangeName(Guid FarmID, string Name)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if(farm == null)
            {
                return BadRequest("Farm not found");    
            }
            farm.Name = Name;
            await _context.SaveChangesAsync();  
            return Ok("Change name successfully");
        }
    }
}
