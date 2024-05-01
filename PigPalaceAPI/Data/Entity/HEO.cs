using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    [Table("HEO")]  
    public class HEO
    {
        [Key]
        public Guid MaHeo { get; set; }     
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
        public Guid MaHeoCha { get; set; }
        public Guid MaHeoMe { get; set; }
        public string TinhTrang { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DonGiaNhap { get; set; }
        public DateTime LastModifyWeight { get; set; }
        public Guid FarmID { get; set; }    
    }
}
