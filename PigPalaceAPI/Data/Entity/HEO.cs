using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    [Table("HEO")]  
    public class HEO
    {
        [Key]
        public string MaHeo { get; set; }     
        public int MaLoaiHeo { get; set; }
        [ForeignKey("MaLoaiHeo")]   
        public virtual LOAIHEO LOAIHEO { get; set; }
        public int MaGiongHeo { get; set; }
        [ForeignKey("MaGiongHeo")]      
        public virtual GIONGHEO GIONGHEO { get; set; }
        public Guid MaChuong { get; set; }
        [ForeignKey("MaChuong")]    
        public virtual CHUONGHEO CHUONGHEO { get; set; }        
        public string GioiTinh { get; set; }
        public float TrongLuong { get; set; }
        public string? MaHeoCha { get; set; }
        public string? MaHeoMe { get; set; }
        public bool IsTrongTrangTrai { get; set; }
        public DateTime NgaySinh { get; set; }
        public float? DonGiaNhap { get; set; }
        public DateTime NgayDenTrangTrai { get; set; }    
        public Guid FarmID { get; set; }    
    }
}
