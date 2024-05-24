using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;

        public HangHoaController(PigPalaceDBContext context)
        {
            _context = context;
        }
        [HttpGet("GetListHangHoa")]
        public async Task<IActionResult> GetListHangHoa(Guid FarmID)
        {
            var farm = await _context.PigFarms.FindAsync(FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            var listHangHoa = await _context.HANGHOAs.Where(x => x.FarmID == FarmID).ToListAsync(); 
            return Ok(listHangHoa); 
        }
    }
}
