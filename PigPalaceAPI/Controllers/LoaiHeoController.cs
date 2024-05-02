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
    public class LoaiHeoController : ControllerBase
    {
        private PigPalaceDBContext _context;
        private IMapper _mapper;

        public LoaiHeoController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("CreateLoaiHeo")]
        public async Task<ActionResult<string>> CreateLoaiHeo(LoaiHeoModel loaiHeoModel)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == loaiHeoModel.FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            _context.LOAIHEOs.Add(_mapper.Map<LOAIHEO>(loaiHeoModel));
            await _context.SaveChangesAsync();
            return Ok("Loai heo created successfully");
        }
        [HttpGet("GetAllLoaiHeo/{FarmID}")]  
        public async Task<ActionResult<List<LOAIHEO>>> GetAllLoaiHeo(Guid FarmID)
        {
            return Ok(await _context.LOAIHEOs.Where(p => p.FarmID == FarmID).ToListAsync());
        }
        [HttpGet("GetLoaiHeoByID/{id}")]
        public async Task<ActionResult<LOAIHEO>> GetLoaiHeoByID(int id)
        {
            var loaiHeo = await _context.LOAIHEOs.FindAsync(id);
            if (loaiHeo == null)
            {
                return NotFound();
            }
            return Ok(loaiHeo);
        }
        [HttpPut("UpdateLoaiHeo")]  
        public async Task<ActionResult<string>> UpdateLoaiHeo(LOAIHEO loaiHeo)
        {
            var _loaiHeo = await _context.LOAIHEOs.FindAsync(loaiHeo.MaLoaiHeo); 
            if (_loaiHeo == null)
            {
                return NotFound("LoaiHeo not found");
            }
            _context.Entry(_loaiHeo).CurrentValues.SetValues(loaiHeo);  
            await _context.SaveChangesAsync();
            return Ok("Loaiheo updated successfully");
        }
        [HttpDelete("DeleteLoaiHeo/{id}")]
        public async Task<ActionResult<string>> DeleteLoaiHeo(int id)
        {
            try
            {
                var loaiHeo = await _context.LOAIHEOs.FindAsync(id);
                if (loaiHeo == null)
                {
                    return NotFound("LoaiHeo not found");
                }
                _context.LOAIHEOs.Remove(loaiHeo);
                await _context.SaveChangesAsync();
                return Ok("LoaiHeo deleted successfully");
            }
            catch
            {
                return BadRequest("Can't delete this LoaiHeo");  
            }
        }
    }
}
