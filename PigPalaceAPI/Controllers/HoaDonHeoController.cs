using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;
using System.Text;
using System;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonHeoController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public HoaDonHeoController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetListHoaDonHeo")]   
        public async Task<IActionResult> GetListHoaDonHeo(Guid FarmID)
        {
            if (_context.PigFarms.Find(FarmID) == null)
            {
                return BadRequest("Farm not found");
            }
            var listHoaDon = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID).ToListAsync();
            return Ok(listHoaDon);
        }
        [HttpGet("GetListPhieuNhap")]
        public async Task<IActionResult> GetListPhieuNhap(Guid FarmID)
        {
            if (_context.PigFarms.Find(FarmID) == null)
            {
                return BadRequest("Farm not found");
            }
            var listPhieuNhap = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu nhập heo").ToListAsync();
            return Ok(listPhieuNhap);
        }
        [HttpGet("GetHeoTrongPhieuNhap")]
        public async Task<IActionResult> GetHeoTrongPhieuNhap(string MaHoaDon, Guid FarmID)
        {
            if (_context.PigFarms.Find(FarmID) == null)
            {
                return BadRequest("Farm not found");
            }
            var listHeo = await _context.CT_HOADONHEOs.Where(x => x.FarmID == FarmID && x.MaHoaDon == MaHoaDon).ToListAsync();
            return Ok(listHeo);
        }
        [HttpPost("CreatePhieuNhapHeo")]
        public async Task<IActionResult> CreatePhieuNhap(DateTime NgayLap, DateTime NgayMua, string Note, Guid FarmID, Guid UserId, string TenCongTy, string TenDoiTac, string DiaChi, string SoDienThoai, string Email, [FromBody] List<HeoModel> listHeoNhap)
        {
            try
            {
                HOADONHEO hoadon = new HOADONHEO();
                hoadon.MaHoaDon = GenerateRandomString(10);
                hoadon.LoaiHoaDon = "Phiếu nhập heo";
                hoadon.SoLuong = listHeoNhap.Count;
                hoadon.TongTien = (float)listHeoNhap.Sum(x => x.DonGiaNhap);
                hoadon.NgayLap = NgayLap;
                hoadon.NgayMua = NgayMua;
                hoadon.TrangThai = "Progress";
                hoadon.GhiChu = Note;
                hoadon.TienTrenDVT = 0;
                hoadon.TenCongTy = TenCongTy;
                hoadon.TenKhachHang = TenDoiTac;
                hoadon.DiaChi = DiaChi;
                hoadon.SDT = SoDienThoai;
                hoadon.Email = Email;
                hoadon.FarmID = FarmID;
                hoadon.UserID = UserId;

                _context.HOADONHEOs.Add(hoadon);
                await _context.SaveChangesAsync();
                foreach (var item in listHeoNhap)
                {
                    var heo = _mapper.Map<HEO>(item);
                    heo.IsTrongTrangTrai = false;
                    _context.HEOs.Add(heo);
                    CT_HOADONHEO cT_HOADONHEO = new CT_HOADONHEO();
                    cT_HOADONHEO.MaHoaDon = hoadon.MaHoaDon;
                    cT_HOADONHEO.FarmID = FarmID;
                    cT_HOADONHEO.MaHeo = item.MaHeo;
                    _context.CT_HOADONHEOs.Add(cT_HOADONHEO);
                    await _context.SaveChangesAsync();
                }
                return Ok("Invoice create successfully");
            }
            catch
            {
                return BadRequest("Invoice create failed");
            }
            
        }

        [HttpPut("XacNhanHoaDonHeo")]  
        public async Task<IActionResult> XacNhanPhieuNhap(string MaHoaDon)
        {
            var hoadon = await _context.HOADONHEOs.Where(x => x.MaHoaDon == MaHoaDon).FirstOrDefaultAsync();
            if (hoadon == null)
            {
                return BadRequest("Invoice not found");
            }
            hoadon.TrangThai = "Paid";
            var listCTHeo = await _context.CT_HOADONHEOs.Where(x => x.MaHoaDon == MaHoaDon).ToListAsync();
            foreach (var item in listCTHeo)
            {
                HEO? heo = await _context.HEOs.Where(x => x.MaHeo == item.MaHeo && x.FarmID == hoadon.FarmID).FirstOrDefaultAsync();
                if(heo == null)
                {
                    return BadRequest("Pig not found");
                }
                heo.IsTrongTrangTrai = true;
                CHUONGHEO chuong = await _context.CHUONGHEOs.FindAsync(heo.MaChuong);
                chuong.SoLuongHeo++;
            }
            await _context.SaveChangesAsync();
            return Ok("Invoice confirmed successfully");
        }
        [HttpDelete("XoaHoaDonHeo")]
        public async Task<IActionResult> XoaHoaDonHeo(string MaHoaDon)
        {
            var hoaDon = await _context.HOADONHEOs.Where(x => x.MaHoaDon == MaHoaDon).FirstOrDefaultAsync();    
            if (hoaDon == null)
            {
                return BadRequest("Invoice not found");
            }
            var listCTHeo = await _context.CT_HOADONHEOs.Where(x => x.MaHoaDon == MaHoaDon).ToListAsync();
            foreach (var item in listCTHeo)
            {
                _context.CT_HOADONHEOs.Remove(item);
            }
            await _context.SaveChangesAsync();  
            _context.HOADONHEOs.Remove(hoaDon);
            await _context.SaveChangesAsync();
            return Ok("Invoice deleted successfully");  
        }

        [HttpPost("CreatePhieuXuatHeo")]    
        public async Task<IActionResult> CreatePhieuXuat(DateTime NgayLap, DateTime NgayBan, string Note, Guid FarmID, Guid UserId, float TienTrenDVT, float TongTien ,string TenCongTy, string TenDoiTac, string DiaChi, string SoDienThoai, string Email, [FromBody] List<HeoXuatModel> listHeoXuat)
        {
            try
            {
                HOADONHEO hoadon = new HOADONHEO();
                hoadon.MaHoaDon = GenerateRandomString(10);
                hoadon.LoaiHoaDon = "Phiếu xuất heo";
                hoadon.SoLuong = listHeoXuat.Count;
                hoadon.TongTien = TongTien;
                hoadon.NgayLap = NgayLap;
                hoadon.TrangThai = "Progress";
                hoadon.GhiChu = Note;
                hoadon.TienTrenDVT = TienTrenDVT;
                hoadon.TenCongTy = TenCongTy;
                hoadon.TenKhachHang = TenDoiTac;
                hoadon.DiaChi = DiaChi;
                hoadon.SDT = SoDienThoai;
                hoadon.Email = Email;
                hoadon.FarmID = FarmID;
                hoadon.UserID = UserId;
                
                var thamSo = await _context.THAMSOS.Where(p => p.FarmID == FarmID).FirstOrDefaultAsync();
                if(thamSo == null)
                {
                    _context.HOADONHEOs.Add(hoadon);
                    await _context.SaveChangesAsync();
                    foreach (var item in listHeoXuat)
                    {
                        CT_HOADONHEO cT_HOADONHEO = new CT_HOADONHEO();
                        cT_HOADONHEO.MaHoaDon = hoadon.MaHoaDon;
                        cT_HOADONHEO.FarmID = FarmID;
                        cT_HOADONHEO.MaHeo = item.Maheo;
                        _context.CT_HOADONHEOs.Add(cT_HOADONHEO);
                        await _context.SaveChangesAsync();
                    }
                    return Ok("Invoice create successfully");
                }
                else
                {
                    var TuoiToiThieuXuatChuong = thamSo.TuoiToiThieuXuatChuong;
                    var TuoiToiDaXuatChuong = thamSo.TuoiToiDaXuatChuong;
                    var TrongLuongToiThieuXuatChuong = thamSo.TrongLuongToiThieuXuatChuong;
                    var TrongLuongToiDaXuatChuong = thamSo.TrongLuongToiDaXuatChuong;
                    int soHeoKhongDat = 0;
                    foreach (var item in listHeoXuat)
                    {
                        var heo = await _context.HEOs.Where(x => x.MaHeo == item.Maheo).FirstOrDefaultAsync();
                        int tuoi = (DateTime.Now - heo.NgaySinh).Days / 30;
                        float trongLuong = heo.TrongLuong;
                        if (tuoi < TuoiToiThieuXuatChuong || tuoi > TuoiToiDaXuatChuong || trongLuong < TrongLuongToiThieuXuatChuong || trongLuong > TrongLuongToiDaXuatChuong)
                        {
                            soHeoKhongDat++;
                        }
                    }
                    if (soHeoKhongDat > 0)
                    {
                        return BadRequest(soHeoKhongDat + " pig not meet the requirements");
                    }
                    else
                    {
                        _context.HOADONHEOs.Add(hoadon);
                        await _context.SaveChangesAsync();
                        foreach (var item in listHeoXuat)
                        {
                            CT_HOADONHEO cT_HOADONHEO = new CT_HOADONHEO();
                            cT_HOADONHEO.MaHoaDon = hoadon.MaHoaDon;
                            cT_HOADONHEO.FarmID = FarmID;
                            cT_HOADONHEO.MaHeo = item.Maheo;
                            _context.CT_HOADONHEOs.Add(cT_HOADONHEO);
                            await _context.SaveChangesAsync();
                        }
                        return Ok("Invoice create successfully");
                    }
                }
                
            }
            catch
            {
                return BadRequest("Invoice create failed");
            }
            
        }
        [HttpPut("XacNhanPhieuXuatHeo")]
        public async Task<IActionResult> XacNhanPhieuXuatHeo(string maHoaDon)
        {
            var hoadon = await _context.HOADONHEOs.Where(x => x.MaHoaDon == maHoaDon).FirstOrDefaultAsync();
            if (hoadon == null)
            {
                return BadRequest("Invoice not found");
            }
            hoadon.TrangThai = "Paid";
            var listCTHeo = await _context.CT_HOADONHEOs.Where(x => x.MaHoaDon == maHoaDon).ToListAsync();
            foreach (var item in listCTHeo)
            {
                HEO? heo = await _context.HEOs.Where(x => x.MaHeo == item.MaHeo && x.FarmID == hoadon.FarmID).FirstOrDefaultAsync();
                if(heo == null)
                {
                    return BadRequest("Pig not found");
                }
                heo.IsTrongTrangTrai = false;    
            }
            await _context.SaveChangesAsync();
            return Ok("Invoice confirmed successfully");
        }
        public static string GenerateRandomString(int length)
        {
            const string prefix = "HDH"; // Các ký tự đầu tiên cố định
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
