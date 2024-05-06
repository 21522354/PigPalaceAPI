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
    public class DoiTacController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public DoiTacController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient([FromBody] DoiTacModel model)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == model.FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            var doiTac = _mapper.Map<DOITAC>(model);
            _context.DOITACs.Add(doiTac);
            _context.SaveChanges();
            return Ok("Client create successfully");
        }
        [HttpGet("GetAllClient/{FarmID}")]
        public async Task<IActionResult> GetAllClient(Guid FarmID)
        {
            var doiTac = await _context.DOITACs.Where(p => p.FarmID == FarmID).ToListAsync();
            return Ok(doiTac);
        }
        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] DOITAC model)
        {
            var doiTac = await _context.DOITACs.FirstOrDefaultAsync(x => x.MaDoiTac == model.MaDoiTac);
            if (doiTac == null)
            {
                return BadRequest("Client not found");
            }
            _context.Entry(doiTac).CurrentValues.SetValues(model);
            _context.SaveChanges();
            return Ok("Client update successfully");
        }
        [HttpDelete("DeleteClient/{MaDoiTac}")]
        public async Task<IActionResult> DeleteClient(int MaDoiTac)
        {
            var doiTac = await _context.DOITACs.FirstOrDefaultAsync(x => x.MaDoiTac == MaDoiTac);
            if (doiTac == null)
            {
                return BadRequest("Client not found");
            }
            _context.DOITACs.Remove(doiTac);
            _context.SaveChanges();
            return Ok("Client delete successfully");
        }
    }
}
