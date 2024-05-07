﻿using AutoMapper;
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
    public class HoaDonNhapHeoController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public HoaDonNhapHeoController(PigPalaceDBContext context, IMapper mapper)
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
                    _context.HEOs.Add(_mapper.Map<HEO>(item));
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

        [HttpPost("XacNhanHoaDonHeo")]  
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
