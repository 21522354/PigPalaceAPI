using PigPalaceAPI.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Model
{
    public class HoaDonHangHoaModel
    {
        public string TenHangHoa { get; set; }
        public string LoaiHangHoa { get; set; } 
        public int SoLuong { get; set; }
        public float GiaTien { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayMua { get; set; }
        public string? GhiChu { get; set; }
        public float TienTrenDVT { get; set; }
        public float TongTien { get; set; }
        public string TenCongTy { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public Guid UserID { get; set; }
        public Guid FarmID { get; set; }
    }
}
