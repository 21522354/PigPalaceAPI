using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Data.Entity
{
    public class DOITAC
    {
        [Key]
        public int MaDoiTac { get; set; }
        public string TenCongTy { get; set; }
        public string? TenDoiTac { get; set; }
        public string? DiaChi { get; set; }  
        public string? SoDienThoai { get; set; } 
        public string? Email { get; set; }
        public Guid FarmID { get; set; }
    }
}           
        