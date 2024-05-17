using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    public class LICHPHOIGIONG
    {
        [Key]
        public string MaLich { get; set; }
        public string MaHeoNai { get; set; }
        [ForeignKey("MaHeoNai")]
        public virtual HEO HEONAI { get; set; }

        public string MaHeoDuc { get; set; }
        [ForeignKey("MaHeoDuc")]
        public virtual HEO HEODUC { get; set; }
        public DateTime NgayPhoi { get; set; }
        public DateTime NgayDeDuKien { get; set; }
        public DateTime NgayDauThai { get; set; }
        public DateTime NgayDeChinhThuc { get; set; }
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User NhanVien { get; set; }
        public Guid FarmID { get; set; }    
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public string LoaiPhoiGiong { get; set; }
        public int? MaGiongHeoDuc { get; set; }
        [ForeignKey("MaGiongHeoDuc")]
        public virtual GIONGHEO GIONGHEODUC { get; set; }
        public int? SoHeoCai { get; set; }
        public int? SoHeoDuc { get; set; }
        public int? SoHeoChet { get; set; }
        public int? SoHeoTat { get; set; }
        public string NguyenNhanThatBai { get; set; }
        public string CachGiaiQuyet { get; set; }
        public string GhiChuTaiSaoThatBai { get; set; }     
    }
}
