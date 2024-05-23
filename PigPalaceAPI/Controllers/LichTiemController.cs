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
    public class LichTiemController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public LichTiemController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        [HttpGet("GetAllLichTiem")]
        public async Task<IActionResult> GetAllLichTiem(Guid FarmID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var listLichTiem = await _context.LICHTIEMs.Where(x => x.FarmID == FarmID).ToListAsync();
            return Ok(_mapper.Map<List<LichTiemModel>>(listLichTiem));
        }
        [HttpGet("GetHeoTrongLichTiem")]    
        public async Task<IActionResult> GetHeoTrongLichTiem(Guid MaLichTiem)
        {
            var lichTiem = await _context.LICHTIEMs.FirstOrDefaultAsync(x => x.MaLichTiem == MaLichTiem);
            if (lichTiem == null)
            {
                return NotFound("Lich tiem not found");
            }
            var listHeoTiem = await _context.CT_LICHTIEMs.Where(x => x.MaLich == MaLichTiem).ToListAsync();
            return Ok(_mapper.Map<List<CTLichTiemModel>>(listHeoTiem));
        }
        [HttpPost("CreateLichTiem")]
        public async Task<IActionResult> CreateLichTiem(LichTiemModelCreate lichTiemModel)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == lichTiemModel.FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var lichTiem = new LICHTIEM();
            lichTiem.MaLichTiem = Guid.NewGuid();
            lichTiem.TinhTrang = "Not completed";
            lichTiem.FarmID = lichTiemModel.FarmID;
            lichTiem.LieuLuong = lichTiemModel.LieuLuong;
            lichTiem.NgayTiem = lichTiemModel.NgayTiem;
            lichTiem.MaHangHoa = lichTiemModel.MaHangHoa;
            lichTiem.UserID = lichTiemModel.UserID;
            var listHeo = lichTiemModel.ListHeoTiem;
            _context.LICHTIEMs.Add(lichTiem);
            foreach (var heo in listHeo)
            {
                var ct_lichTiem = new CT_LICHTIEM
                {
                    MaHeo = heo.MaHeo,
                    MaLich = lichTiem.MaLichTiem,
                    FarmID = lichTiem.FarmID,
                };
                _context.CT_LICHTIEMs.Add(ct_lichTiem);
            }
            await _context.SaveChangesAsync();
            return Ok("Create Injection Schedule successfully");
        }
        [HttpPut("HoanThanhLichTiem")]
        public async Task<IActionResult> HoanThanhLichTiem(Guid MaLichTiem)
        {
            var licTiem = await _context.LICHTIEMs.FirstOrDefaultAsync(x => x.MaLichTiem == MaLichTiem);
            if (licTiem == null)
            {
                return NotFound("Injection schedule not found");
            }
            licTiem.TinhTrang = "Completed";
            await _context.SaveChangesAsync();
            return Ok("Injection schedule completed");
        }
    }
}
