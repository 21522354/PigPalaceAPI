using PigPalaceAPI.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Model
{
    public class HeoModel
    {
        public string MaHeo { get; set; }
        public int MaGiongHeo { get; set; }
        public Guid MaChuong { get; set; }
        public string GioiTinh { get; set; }
        public float TrongLuong { get; set; }
        public string? MaHeoCha { get; set; }
        public string? MaHeoMe { get; set; }
        public DateTime NgaySinh { get; set; }
        public float? DonGiaNhap { get; set; }
        public DateTime NgayDenTrangTrai { get; set; }
        public Guid FarmID { get; set; }
    }
}
