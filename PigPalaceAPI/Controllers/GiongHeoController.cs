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
    public class GiongHeoController : ControllerBase
    {
        private PigPalaceDBContext _context;
        private IMapper _mapper;

        public GiongHeoController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("CreateGiongHeo")]
        public async Task<ActionResult<string>> CreateGiongHeo(GiongHeoModel giongHeoModel)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == giongHeoModel.FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            _context.GIONGHEOs.Add(_mapper.Map<GIONGHEO>(giongHeoModel));
            await _context.SaveChangesAsync();
            return Ok("Giong heo created successfully");
        }
        [HttpGet("GetAllGiongHeo/{FarmID}")]
        public async Task<ActionResult<List<LOAIHEO>>> GetAllGiongHeo(Guid FarmID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);    
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            return Ok(await _context.GIONGHEOs.Where(p => p.FarmID == FarmID).ToListAsync());
        }
        [HttpGet("GetGiongHeoByID/{id}")]
        public async Task<ActionResult<LOAIHEO>> GetGiongHeoByID(int id)
        {
            var giongHeo = await _context.GIONGHEOs.FindAsync(id);
            if (giongHeo == null)
            {
                return NotFound();
            }
            return Ok(giongHeo);
        }
        [HttpPut("UpdateGiongHeo")]
        public async Task<ActionResult<string>> UpdateGiongHeo(GIONGHEO giongHeo)
        {
            var _giongHeo = await _context.GIONGHEOs.FindAsync(giongHeo.MaGiongHeo);
            if (_giongHeo == null)
            {
                return NotFound("GiongHeo not found");
            }
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == giongHeo.FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            _context.Entry(_giongHeo).CurrentValues.SetValues(giongHeo);
            await _context.SaveChangesAsync();
            return Ok("GiongHeo updated successfully");
        }
        [HttpDelete("DeleteGiongHeo/{id}")]
        public async Task<ActionResult<string>> DeleteLoaiHeo(int id)
        {
            try
            {
                var giongHeo = await _context.GIONGHEOs.FindAsync(id);
                if (giongHeo == null)
                {
                    return NotFound("GiongHeo not found");
                }
                _context.GIONGHEOs.Remove(giongHeo);
                await _context.SaveChangesAsync();
                return Ok("GiongHeo deleted successfully");
            }
            catch
            {
                return BadRequest("Can't delete this GiongHeo");
            }
        }
    }
}
