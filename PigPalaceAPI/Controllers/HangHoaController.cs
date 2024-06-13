using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public HangHoaController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        [HttpPost("UpdateHangHoa")]
        public async Task<IActionResult> UpdateHangHoa(Guid FarmID, HangHoaModel hanghoa)
        {
            var farm = await _context.PigFarms.FindAsync(FarmID);
            if(farm == null)
            {
                return BadRequest("Farm not found");
            }
            var updateHangHoa = await _context.HANGHOAs.Where(p => p.TenHangHoa == hanghoa.TenHangHoa).FirstOrDefaultAsync();
            if (updateHangHoa == null)
            {
                return BadRequest("HangHoa not found");
            }
            _context.Entry(updateHangHoa).CurrentValues.SetValues(hanghoa);
            await _context.SaveChangesAsync();
            return Ok("Goods update successfully");
        }
        [HttpDelete("DeleteHangHoa")]
        public async Task<IActionResult> DeleteHangHoa(Guid FarmID, string tenHangHoa)
        {
            var farm = await _context.PigFarms.FindAsync(FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            var deleteHangHoa = await _context.HANGHOAs.Where(p => p.TenHangHoa == tenHangHoa).FirstOrDefaultAsync();
            if (deleteHangHoa == null)
            {
                return BadRequest("Goods not found");
            }
            _context.HANGHOAs.Remove(deleteHangHoa);
            await _context.SaveChangesAsync();
            return Ok("Goods delete successfully");
        }
    }
}
