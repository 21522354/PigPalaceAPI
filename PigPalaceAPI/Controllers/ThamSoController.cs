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
    public class ThamSoController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public ThamSoController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        [HttpGet("GetListThamSo")]
        public async Task<IActionResult> GetListThamSo(Guid FarmID)
        {
            if (_context.PigFarms.Find(FarmID) == null)
            {
                return BadRequest("Farm not found");
            }
            var listThamSo = await _context.THAMSOS.Where(x => x.FarmID == FarmID).ToListAsync();
            return Ok(listThamSo);
        }
        [HttpPut("UpdateThamSo")]
        public async Task<IActionResult> UpdateThamSo(ThamSoModel model)
        {
            var thamSo = await _context.THAMSOS.Where(x => x.FarmID == model.FarmID).FirstOrDefaultAsync();
            if(thamSo == null)
            {
                var newThamSo = _mapper.Map<THAMSO>(model);
                await _context.THAMSOS.AddAsync(newThamSo);
                await _context.SaveChangesAsync();  
                return Ok("Update Successfully");
            }
            else
            {
                var updateThamSo = _mapper.Map(model, thamSo);
                _context.THAMSOS.Update(updateThamSo);
                await _context.SaveChangesAsync();
                return Ok("Update Successfully");   
            }
        }
    }
}
