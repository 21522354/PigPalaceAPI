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
    public class LichChoAnController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public LichChoAnController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetAllThucAn")]
        public async Task<IActionResult> GetAllThucAn(Guid FarmID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var listThucAn = await _context.HANGHOAs.Where(x => x.FarmID == FarmID && x.LoaiHangHoa == "Thức ăn").ToListAsync();
            return Ok(listThucAn);
        }
        [HttpGet("GetAllLichChoAn")]
        public async Task<IActionResult> GetAllLichChoAn(Guid FarmId)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmId);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var listLichChoAn = await _context.LICHCHOANs.Where(x => x.FarmID == FarmId).ToListAsync();
            var listLichChoAnRespond = _mapper.Map<List<LichChoAnRespond>>(listLichChoAn);
            for(int i = 0; i < listLichChoAn.Count; i++)
            {
                var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == listLichChoAn[i].MaChuong);
                listLichChoAnRespond[i].LuongThucAn = listLichChoAn[i].LuongThucAn1Con * chuongHeo.SoLuongHeo;
                var hangHoa = await _context.HANGHOAs.FirstOrDefaultAsync(x => x.ID == listLichChoAn[i].MaHangHoa);
                listLichChoAnRespond[i].TenHangHoa = hangHoa.TenHangHoa;
            }
            return Ok(listLichChoAnRespond);
        }
        [HttpGet("GetLichChoAnByNhanVienThucHien")]
        public async Task<IActionResult> GetLichChoAnByNhanVienThucHien(Guid FarmID, Guid UserID)
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
            if(user.RoleName != "Management")
            {
                var listLichChoAn = await _context.LICHCHOANs.Where(x => x.FarmID == FarmID && x.UserID == UserID).ToListAsync();
                var listLichChoAnRespond = _mapper.Map<List<LichChoAnRespond>>(listLichChoAn);
                for (int i = 0; i < listLichChoAn.Count; i++)
                {
                    var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == listLichChoAn[i].MaChuong);
                    listLichChoAnRespond[i].LuongThucAn = listLichChoAn[i].LuongThucAn1Con * chuongHeo.SoLuongHeo;
                    var hangHoa = await _context.HANGHOAs.FirstOrDefaultAsync(x => x.ID == listLichChoAn[i].MaHangHoa);
                    listLichChoAnRespond[i].TenHangHoa = hangHoa.TenHangHoa;
                }
                return Ok(listLichChoAnRespond);
            }
            else
            {
                var listLichChoAn = await _context.LICHCHOANs.Where(x => x.FarmID == FarmID).ToListAsync();
                var listLichChoAnRespond = _mapper.Map<List<LichChoAnRespond>>(listLichChoAn);
                for (int i = 0; i < listLichChoAn.Count; i++)
                {
                    var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == listLichChoAn[i].MaChuong);
                    listLichChoAnRespond[i].LuongThucAn = listLichChoAn[i].LuongThucAn1Con * chuongHeo.SoLuongHeo;
                    var hangHoa = await _context.HANGHOAs.FirstOrDefaultAsync(x => x.ID == listLichChoAn[i].MaHangHoa);
                    listLichChoAnRespond[i].TenHangHoa = hangHoa.TenHangHoa;
                }
                return Ok(listLichChoAnRespond);
            }
        }
        [HttpPost("CreateLichChoAn1Ngay")]   
        public async Task<IActionResult> CreateLichChoAn1Ngay(LichChoAn1NgayModel lichChoAnModel)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == lichChoAnModel.FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            if (lichChoAnModel.ListChuongHeoChoAn.Count == 0)
            {
                return BadRequest("Please choose Barn to feed");
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == lichChoAnModel.UserID);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            var HangHoa = await _context.HANGHOAs.FirstOrDefaultAsync(x => x.ID == lichChoAnModel.MaHangHoa);
            if (HangHoa == null)
            {
                return BadRequest("Product not found");
            }
            TimeSpan ngayHienTai = new TimeSpan(lichChoAnModel.NgayBatDau.Hour, lichChoAnModel.NgayBatDau.Minute, lichChoAnModel.NgayBatDau.Second);
            TimeSpan tGianCachNhau = new TimeSpan(lichChoAnModel.ThoiGianCachNhauMoiLanChoAn.Hour, lichChoAnModel.ThoiGianCachNhauMoiLanChoAn.Minute, lichChoAnModel.ThoiGianCachNhauMoiLanChoAn.Second);
            for(int i = 0; i < lichChoAnModel.SoLanChoAnMoiNgay; i++)
            {
                ngayHienTai += tGianCachNhau;
            }
            if(ngayHienTai.Days >= 1)
            {
                return BadRequest("Feeding hours exceed the day");
            }

            float tongLuongThucAn = 0;
            for (int i = 0; i < lichChoAnModel.ListChuongHeoChoAn.Count; i++)
            {
                var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == lichChoAnModel.ListChuongHeoChoAn[i].MaChuong);
                tongLuongThucAn += lichChoAnModel.SoLuongCho1ConHeo1Ngay * chuongHeo.SoLuongHeo;
            }
            if (tongLuongThucAn > HangHoa.TonKho)
            {
                return BadRequest("Insufficient inventory");
            }

            DateTime NgayChoAn = lichChoAnModel.NgayBatDau;
            for(int i = 0; i < lichChoAnModel.SoLanChoAnMoiNgay; i++)
            {
                for(int j = 0; j < lichChoAnModel.ListChuongHeoChoAn.Count; j++)
                {
                    LICHCHOAN newLichChoAn = new LICHCHOAN();
                    newLichChoAn.ID = Guid.NewGuid();   
                    newLichChoAn.MaHangHoa = lichChoAnModel.MaHangHoa;
                    newLichChoAn.NgayChoAn = NgayChoAn;
                    newLichChoAn.UserID = lichChoAnModel.UserID;
                    newLichChoAn.FarmID = lichChoAnModel.FarmID;
                    newLichChoAn.MaChuong = lichChoAnModel.ListChuongHeoChoAn[j].MaChuong;
                    newLichChoAn.LuongThucAn1Con = (lichChoAnModel.SoLuongCho1ConHeo1Ngay)/lichChoAnModel.SoLanChoAnMoiNgay;
                    newLichChoAn.TinhTrang = "Not Completed";
                    _context.LICHCHOANs.Add(newLichChoAn);
                    await _context.SaveChangesAsync();
                }
                NgayChoAn = NgayChoAn.Add(tGianCachNhau);
            }
            return Ok("Feed schedule create successfully");
        }
        [HttpPost("CreateLichChoAnNhieuNgay")]
        public async Task<IActionResult> CreateLichChoAnNhieuNgay(LichChoAnNhieuNgayModel lichChoAnModel)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == lichChoAnModel.FarmID);
            if (farm == null)
            {
                return BadRequest("Farm not found");
            }
            if (lichChoAnModel.ListChuongHeoChoAn.Count == 0)
            {
                return BadRequest("Please choose Barn to feed");
            }
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserID == lichChoAnModel.UserID);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            var HangHoa = await _context.HANGHOAs.FirstOrDefaultAsync(x => x.ID == lichChoAnModel.MaHangHoa);
            if (HangHoa == null)
            {
                return BadRequest("Product not found");
            }
            if(lichChoAnModel.NgayBatDau > lichChoAnModel.NgayKetThuc)
            {
                return BadRequest("Start date must be less than end date");
            }       
            TimeSpan ngayHienTai = new TimeSpan(lichChoAnModel.NgayBatDau.Hour, lichChoAnModel.NgayBatDau.Minute, lichChoAnModel.NgayBatDau.Second);
            TimeSpan tGianCachNhau = new TimeSpan(lichChoAnModel.ThoiGianCachNhauMoiLanChoAn.Hour, lichChoAnModel.ThoiGianCachNhauMoiLanChoAn.Minute, lichChoAnModel.ThoiGianCachNhauMoiLanChoAn.Second);
            for (int i = 0; i < lichChoAnModel.SoLanChoAnMoiNgay; i++)
            {
                ngayHienTai += tGianCachNhau;
            }
            if (ngayHienTai.Days >= 1)
            {
                return BadRequest("Feeding hours exceed the day");
            }

            DateTime NgayBatDau = lichChoAnModel.NgayBatDau;
            DateTime NgayKetThuc = lichChoAnModel.NgayKetThuc;
            while (!NgayBatDau.Date.Equals(NgayKetThuc.AddDays(1).Date))
            {
                DateTime NgayChoAn = NgayBatDau;
                for (int i = 0; i < lichChoAnModel.SoLanChoAnMoiNgay; i++)
                {
                    for (int j = 0; j < lichChoAnModel.ListChuongHeoChoAn.Count; j++)
                    {
                        LICHCHOAN newLichChoAn = new LICHCHOAN();
                        newLichChoAn.ID = Guid.NewGuid();
                        newLichChoAn.MaHangHoa = lichChoAnModel.MaHangHoa;
                        newLichChoAn.NgayChoAn = NgayChoAn;
                        newLichChoAn.UserID = lichChoAnModel.UserID;
                        newLichChoAn.FarmID = lichChoAnModel.FarmID;
                        newLichChoAn.MaChuong = lichChoAnModel.ListChuongHeoChoAn[j].MaChuong;
                        newLichChoAn.LuongThucAn1Con = (lichChoAnModel.SoLuongCho1ConHeo1Ngay) / lichChoAnModel.SoLanChoAnMoiNgay;
                        newLichChoAn.TinhTrang = "Not Completed";
                        _context.LICHCHOANs.Add(newLichChoAn);
                        await _context.SaveChangesAsync();
                    }
                    NgayChoAn = NgayChoAn.Add(tGianCachNhau);
                }
                NgayBatDau = NgayBatDau.AddDays(1); 
            }
            return Ok("Feed schedule create successfully");
        }
        [HttpPut("HoanThanhLichChoAn")]
        public async Task<IActionResult> HoanThanhLichChoAn(Guid MaLich)
        {
            var lichChoAn = await _context.LICHCHOANs.FirstOrDefaultAsync(x => x.ID == MaLich);
            if (lichChoAn == null)
            {
                return BadRequest("Feed schedule not found");
            }
            lichChoAn.TinhTrang = "Completed";
            var hangHoa = await _context.HANGHOAs.FirstOrDefaultAsync(x => x.ID == lichChoAn.MaHangHoa);
            var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == lichChoAn.MaChuong);   
            hangHoa.TonKho -= lichChoAn.LuongThucAn1Con * chuongHeo.SoLuongHeo;
            if(hangHoa.TonKho < 0)
            {
                return BadRequest("Insufficient inventory");
            }

            _context.HANGHOAs.Update(hangHoa);
            _context.LICHCHOANs.Update(lichChoAn);
            await _context.SaveChangesAsync();
            return Ok("Feed schedule completed");
        }
        [HttpDelete("XoaLichChoAn")]
        public async Task<IActionResult> XoaLichChoAn(Guid MaLich)
        {
            var lichChoAn = await _context.LICHCHOANs.FirstOrDefaultAsync(x => x.ID == MaLich);
            if (lichChoAn == null)
            {
                return BadRequest("Feed schedule not found");
            }
            _context.LICHCHOANs.Remove(lichChoAn);
            await _context.SaveChangesAsync();
            return Ok("Feed schedule deleted");
        }
    }
}
