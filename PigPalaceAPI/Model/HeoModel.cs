using PigPalaceAPI.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Model
{
    public class HeoModel
    {
        public int MaLoaiHeo { get; set; }
        public int MaGiongHeo { get; set; }
        public Guid MaChuong { get; set; }
        public string GioiTinh { get; set; }
        public float TrongLuong { get; set; }
        public Guid? MaHeoCha { get; set; }
        public Guid? MaHeoMe { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DonGiaNhap { get; set; }
        public DateTime LastModifyWeight { get; set; }
        public Guid FarmID { get; set; }
    }
}
