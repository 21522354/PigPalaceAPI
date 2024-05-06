using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    public class HOADONHEO
    {
        [Key]
        public string MaHoaDon { get; set; }
        public string LoaiHoaDon { get; set; }
        public float SoLuong { get; set; }
        public float TongTien { get; set; }
        public DateTime NgayLap { get; set; }
        public DateTime NgayMua { get; set; }
        public string TrangThai { get; set; }   
        public string? GhiChu { get; set; }
        public float TienTrenDVT { get; set; }
        public int MaDoiTac { get; set; }

        [ForeignKey("MaDoiTac")]
        public virtual DOITAC DOITAC { get; set; }
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]  
        public virtual User User { get; set; }
        public Guid FarmID { get; set; }
    }
}
