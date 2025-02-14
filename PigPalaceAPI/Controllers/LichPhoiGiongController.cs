﻿using AutoMapper;
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
    public class LichPhoiGiongController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public LichPhoiGiongController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetAllLichPhoiGiong")]
        public async Task<IActionResult> GetAll(Guid FarmId)
        {
            var farm = await _context.PigFarms.FindAsync(FarmId);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var listLPG = await _context.LICHPHOIGIONGs.Where(x => x.FarmID == FarmId).ToListAsync();
            return Ok(listLPG);
        }
        [HttpGet("GetLichPhoiGiongByNhanVienThucHien")]
        public async Task<IActionResult> GetLichPhoiGiongByNhanVienThucHien(Guid FarmID, Guid UserID)
        {
            var farm = await _context.PigFarms.FindAsync(FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var user = await _context.Users.FindAsync(UserID);
            if (user == null)
            {
                return NotFound("User not found");
            }
            if(user.RoleName != "Management")
            {
                var listLPG = await _context.LICHPHOIGIONGs.Where(x => x.FarmID == FarmID && x.UserID == UserID).ToListAsync();
                return Ok(listLPG);
            }
            else
            {
                var listLPG = await _context.LICHPHOIGIONGs.Where(x => x.FarmID == FarmID).ToListAsync();
                return Ok(listLPG);
            }
        }
        [HttpGet("GetByHeoID")]
        public async Task<IActionResult> GetByHeoID(string HeoID)
        {
            var heo = await _context.HEOs.FindAsync(HeoID);
            if (heo == null)
            {
                return NotFound("Pig not found");
            }
            var listLPG = await _context.LICHPHOIGIONGs.Where(x => x.MaHeoDuc == HeoID || x.MaHeoNai == HeoID).ToListAsync();
            listLPG = listLPG.OrderByDescending(x => x.NgayPhoi).ToList();
            return Ok(listLPG); 
        }
        
        [HttpPost("CreateLPG")]
        public async Task<IActionResult> CreateLPG(LichPhoiGiongModel lichPhoiGiong)
        {
            var farm = await _context.PigFarms.FindAsync(lichPhoiGiong.FarmID);
            if(farm == null)
            {
                return NotFound("Farm not found");
            }
            var thamSo = await _context.THAMSOS.Where(x => x.FarmID == lichPhoiGiong.FarmID).FirstOrDefaultAsync();
            if (thamSo == null)
            {
                var newLichPhoiGiong = _mapper.Map<LICHPHOIGIONG>(lichPhoiGiong);
                newLichPhoiGiong.TrangThai = "Đang chờ kết quả";
                _context.LICHPHOIGIONGs.Add(newLichPhoiGiong);
                await _context.SaveChangesAsync();
                return Ok("Pregnancy Schedule created successfully");
            }
            else
            {
                var heoNai = await _context.HEOs.FindAsync(lichPhoiGiong.MaHeoNai);

                var listLPG = await _context.LICHPHOIGIONGs.Where(p => p.MaHeoNai == heoNai.MaHeo).ToListAsync();
                foreach (var item in listLPG)
                {
                    if(item.TrangThai == "Đang chờ kết quả" || item.TrangThai == "Đã đậu thai")
                    {
                        return BadRequest("Pig is already in pregnancy schedule");
                    }
                }

                int Tuoi = (DateTime.Now - heoNai.NgaySinh).Days / 30;
                if(Tuoi < thamSo.TuoiPhoiGiongToiThieuHeoCai)
                {
                    return BadRequest("Pig is too young for pregnancy");
                }
                var newLichPhoiGiong = _mapper.Map<LICHPHOIGIONG>(lichPhoiGiong);
                newLichPhoiGiong.TrangThai = "Đang chờ kết quả";
                _context.LICHPHOIGIONGs.Add(newLichPhoiGiong);
                await _context.SaveChangesAsync();
                return Ok("Pregnancy Schedule created successfully");
            }
        }
        [HttpPut("XacNhanDauThai")]
        public async Task<IActionResult> XacNhanDauThai(string MaLich, DateTime NgayDauThai, bool IsSuccess, Guid FarmID)
        {
            var farm = await _context.PigFarms.FindAsync(FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var lichPhoiGiong = await _context.LICHPHOIGIONGs.FindAsync(MaLich);
            if (lichPhoiGiong == null)
            {
                return NotFound("Pregnancy Schedule not found");
            }
            lichPhoiGiong.NgayDauThai = NgayDauThai;
            lichPhoiGiong.NgayDeDuKien = NgayDauThai.AddDays(114);  
            if (IsSuccess)
            {
                lichPhoiGiong.TrangThai = "Đã đậu thai";
            }
            else
            {
                lichPhoiGiong.TrangThai = "Thất bại";
            }
            await _context.SaveChangesAsync();
            return Ok("Pregnancy Schedule updated successfully");
        }
        [HttpPut("XacNhanDeThanhCong")]
        public async Task<IActionResult> XacNhanDeThanhCong(string MaLich, DateTime NgayDeChinhThuc, int SoHeoConSong, int SoHeoDuc, int SoHeoCai, int SoHeoChet, int SoHeoTat)
        {
            var lichPhoiGiong = await _context.LICHPHOIGIONGs.FindAsync(MaLich);
            if (lichPhoiGiong == null)
            {
                return NotFound("Pregnancy Schedule not found");
            }
            lichPhoiGiong.NgayDeChinhThuc = NgayDeChinhThuc;
            lichPhoiGiong.SoHeoCai = SoHeoCai;
            lichPhoiGiong.SoHeoDuc = SoHeoDuc;
            lichPhoiGiong.SoHeoChet = SoHeoChet;
            lichPhoiGiong.SoHeoTat = SoHeoTat;
            lichPhoiGiong.TrangThai = "Thành công";

            await _context.SaveChangesAsync();
            return Ok("Pregnancy Schedule updated successfully");
        }
        [HttpPut("XacNhanDeThatBai")]
        public async Task<IActionResult> XacNhanDeThatBai(string MaLich, string NguyenNhan, string CachGiaiQuyet, string GhiChuTaiSaoThatBai)
        {
            var lichPhoiGiong = await _context.LICHPHOIGIONGs.FindAsync(MaLich);
            if (lichPhoiGiong == null)
            {
                return NotFound("Pregnancy Schedule not found");
            }
            lichPhoiGiong.NguyenNhanThatBai = NguyenNhan;
            lichPhoiGiong.CachGiaiQuyet = CachGiaiQuyet;
            lichPhoiGiong.GhiChuTaiSaoThatBai = GhiChuTaiSaoThatBai;
            lichPhoiGiong.TrangThai = "Thất bại";
            await _context.SaveChangesAsync();
            return Ok("Pregnancy Schedule updated successfully");
        }
        [HttpDelete("XoaLichPhoiGiong")]
        public async Task<IActionResult> XoaLichPhoiGiong(string MaLich)
        {
            var lichPhoiGiong = await _context.LICHPHOIGIONGs.FindAsync(MaLich);
            if (lichPhoiGiong == null)
            {
                return NotFound("Pregnancy Schedule not found");
            }
            _context.LICHPHOIGIONGs.Remove(lichPhoiGiong);
            await _context.SaveChangesAsync();
            return Ok("Pregnancy Schedule deleted");
        }
    }
}
