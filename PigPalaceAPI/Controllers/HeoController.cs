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
    public class HeoController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public HeoController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost("CreateHeo")]
        public async Task<ActionResult<string>> CreateHeo(HeoModel heoModel)
        {
            // check valid field
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == heoModel.FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            var heocheck = await _context.HEOs.FirstOrDefaultAsync(x => x.MaHeo == heoModel.MaHeo);
            if (heocheck != null)
            {
                return BadRequest("PigID already exists");
            }
            var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == heoModel.MaChuong);
            if (chuongHeo == null)
            {
                return BadRequest("Cage not found");
            }
            if(heoModel.MaHeoCha != null)
            {
                var heoCha = await _context.HEOs.FirstOrDefaultAsync(x => x.MaHeo == heoModel.MaHeoCha);    
                if (heoCha == null)
                {
                    return BadRequest("PigFather not found");
                }
            }
            if(heoModel.MaHeoMe != null)
            {
                var heoMe = await _context.HEOs.FirstOrDefaultAsync(x => x.MaHeo == heoModel.MaHeoMe);    
                if (heoMe == null)
                {
                    return BadRequest("PigMother not found");
                }
            }
            var giongHeo = await _context.GIONGHEOs.FindAsync(heoModel.MaGiongHeo);     
            if (giongHeo == null)
            {
                return BadRequest("Breed not found");
            }

            // add new Heo
            try
            {
                var heo = _mapper.Map<HEO>(heoModel);
                _context.HEOs.Add(heo);
                await _context.SaveChangesAsync();
                return Ok("Heo created successfully");
            }
            catch
            {
                return BadRequest("Can't create Heo");  
            }
        }
        [HttpGet("GetAllHeo/{FarmID}")]
        public async Task<ActionResult<List<HeoModel>>> GetAllHeo(Guid FarmID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            var listHeo = await _context.HEOs.Where(p => p.FarmID == FarmID && p.IsTrongTrangTrai == true).ToListAsync();
            return Ok(_mapper.Map<List<HeoModel>>(listHeo));
        }
        [HttpGet("GetHeoByID/{id}")]
        public async Task<ActionResult<HeoModel>> GetHeoByID(string id)
        {
            var heo = await _context.HEOs.FindAsync(id);
            if (heo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<HeoModel>(heo));
        }
        [HttpPut("UpdateHeo")]
        public async Task<ActionResult<string>> UpdateHeo(HeoModel heoModel)
        {
            var heo = await _context.HEOs.FindAsync(heoModel.MaHeo);
            if (heo == null)
            {
                return NotFound("Pig not found");
            }
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == heoModel.FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == heoModel.MaChuong);
            if (chuongHeo == null)
            {
                return BadRequest("Cage not found");
            }
            if(heoModel.MaHeoCha != null)
            {
                var heoCha = await _context.HEOs.FirstOrDefaultAsync(x => x.MaHeo == heoModel.MaHeoCha);    
                if (heoCha == null)
                {
                    return BadRequest("PigFather not found");
                }
            }
            if(heoModel.MaHeoMe != null)
            {
                var heoMe = await _context.HEOs.FirstOrDefaultAsync(x => x.MaHeo == heoModel.MaHeoMe);    
                if (heoMe == null)
                {
                    return BadRequest("PigMother not found");
                }
            }
            var giongHeo = await _context.GIONGHEOs.FindAsync(heoModel.MaGiongHeo);     
            if (giongHeo == null)
            {
                return BadRequest("Breed not found");
            }
            try
            {
                _context.Entry(heo).CurrentValues.SetValues(heoModel);
                await _context.SaveChangesAsync();
                return Ok("Pig updated successfully");
            }
            catch
            {
                return BadRequest("Can't update this Pig");  
            }
        }
        [HttpDelete("DeleteHeo/{id}")]
        public async Task<ActionResult<string>> DeleteHeo(Guid id)
        {
            try
            {
                var heo = await _context.HEOs.FindAsync(id);
                if (heo == null)
                {
                    return NotFound("Pig not found");
                }
                _context.HEOs.Remove(heo);
                await _context.SaveChangesAsync();
                return Ok("Pig deleted successfully");
            }
            catch
            {
                return BadRequest("Can't delete this Pig");  
            }
        }
    }
}
