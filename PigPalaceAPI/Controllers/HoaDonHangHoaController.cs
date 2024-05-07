using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;
using System.Text;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonHangHoaController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public HoaDonHangHoaController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetListPhieuNhap")]
        public async Task<IActionResult> GetListPhieuNhap(Guid FarmID)
        {
            if (_context.PigFarms.Find(FarmID) == null)
            {
                return BadRequest("Farm not found");
            }
            var listPhieuNhap = await _context.HOADONHANGHOAs.Where(x => x.FarmID == FarmID).ToListAsync();
            return Ok(listPhieuNhap);
        }
        [HttpPost("CreatePhieuNhapHangHoa")]
        public async Task<IActionResult> ThemPhieuNhapHangHoa(HoaDonHangHoaModel hoaDonHangHoa)
        {
            try
            {
                var HoaDon = _mapper.Map<HOADONHANGHOA>(hoaDonHangHoa);
                HoaDon.MaHoaDon = GenerateRandomString(10);
                HoaDon.TrangThai = "Progress";
                _context.HOADONHANGHOAs.Add(HoaDon);
                await _context.SaveChangesAsync();
                return Ok("Invoice create successfully");
            }
            catch
            {
                return BadRequest("Invoice create failed");
            }
        }
        [HttpPost("UpdateHoaDonHangHoa")]
        public async Task<IActionResult> UpdateHoaDonHangHoa(string maHoaDon, HoaDonHangHoaModel2 hoaDonHangHoa)
        {
            var hoaDon = await _context.HOADONHANGHOAs.FirstOrDefaultAsync(x => x.MaHoaDon == maHoaDon);
            if (hoaDon == null)
            {
                return BadRequest("Invoice not found");
            }
            try
            {
                hoaDon.LoaiHangHoa = hoaDonHangHoa.LoaiHangHoa;
                hoaDon.SoLuong = hoaDonHangHoa.SoLuong;
                hoaDon.GiaTien = hoaDonHangHoa.GiaTien;
                hoaDon.NgayLap = hoaDonHangHoa.NgayLap;
                hoaDon.NgayMua = hoaDonHangHoa.NgayMua;
                hoaDon.GhiChu = hoaDonHangHoa.GhiChu;
                hoaDon.TienTrenDVT = hoaDonHangHoa.TienTrenDVT;
                hoaDon.TongTien = hoaDonHangHoa.TongTien;
                hoaDon.TenCongTy = hoaDonHangHoa.TenCongTy;
                hoaDon.TenKhachHang = hoaDonHangHoa.TenKhachHang;
                hoaDon.DiaChi = hoaDonHangHoa.DiaChi;
                hoaDon.SDT = hoaDonHangHoa.SDT;
                hoaDon.Email = hoaDonHangHoa.Email;
                await _context.SaveChangesAsync();
                return Ok("Update invoice successfully");
            }
            catch
            {
                return BadRequest("Can't update invoice");
            }
        }

        public static string GenerateRandomString(int length)
        {
            const string prefix = "HDHH"; // Các ký tự đầu tiên cố định
            Random random = new Random();
            // Tạo một StringBuilder để xây dựng chuỗi
            StringBuilder stringBuilder = new StringBuilder(prefix);

            // Số lượng ký tự ngẫu nhiên cần tạo bổ sung sau ký tự đầu tiên
            int charactersToGenerate = length - prefix.Length;

            // Tạo các ký tự ngẫu nhiên
            for (int i = 0; i < charactersToGenerate; i++)
            {
                // Sinh một ký tự chữ cái ngẫu nhiên từ 'A' đến 'Z'
                char randomChar = (char)random.Next('A', 'Z' + 1);
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }
    }
}
