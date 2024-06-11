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
        [HttpGet("GetAllThuoc")]
        public async Task<IActionResult> GetAllThuoc(Guid FarmID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var listThuoc = await _context.HANGHOAs.Where(x => x.FarmID == FarmID && x.LoaiHangHoa == "Thuốc").ToListAsync();
            return Ok(listThuoc);
        }
        [HttpGet("GetAllVaccin")]
        public async Task<IActionResult> GetAllVaccin(Guid FarmID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var listThuoc = await _context.HANGHOAs.Where(x => x.FarmID == FarmID && x.LoaiHangHoa == "Vắc xin").ToListAsync();
            return Ok(listThuoc);
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
        [HttpGet("GetLichTiemByNhanVienThucHien")]
        public async Task<IActionResult> GetLichTiemByNhanVienThucHien(Guid FarmID, Guid UserID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == UserID);
            if (user == null)
            {
                return NotFound("User not found");
            }
            if (user.RoleName != "Quản lý")
            {
                var listLichTiem = await _context.LICHTIEMs.Where(x => x.FarmID == FarmID && x.UserID == UserID).ToListAsync();
                return Ok(_mapper.Map<List<LichTiemModel>>(listLichTiem));
            }
            else
            {
                var listLichTiem = await _context.LICHTIEMs.Where(x => x.FarmID == FarmID).ToListAsync();
                return Ok(_mapper.Map<List<LichTiemModel>>(listLichTiem));
            }
        }
        [HttpGet("GetByHeoID")]
        public async Task<IActionResult> GetByHeoID(string HeoID)
        {
            var heo = await _context.HEOs.FirstOrDefaultAsync(x => x.MaHeo == HeoID);
            if (heo == null)
            {
                return NotFound("Pig not found");
            }
            var listLichTiem = await _context.CT_LICHTIEMs.Where(x => x.MaHeo == HeoID).ToListAsync();
            var listLichTiemModel = new List<LichTiemModel>();
            foreach (var item in listLichTiem)
            {
                var lichTiem = await _context.LICHTIEMs.FirstOrDefaultAsync(x => x.MaLichTiem == item.MaLich);
                listLichTiemModel.Add(_mapper.Map<LichTiemModel>(lichTiem));
            }
            listLichTiemModel = listLichTiemModel.OrderByDescending(x => x.NgayTiem).ToList();
            return Ok(listLichTiemModel);
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
