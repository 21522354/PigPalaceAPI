using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    [Table("CHUONGHEO")]
    public class CHUONGHEO
    {
        [Key]
        public Guid MaChuong { get; set; }
        public string TinhTrang { get; set; }
        public int SoLuongHeo { get; set; }
        public string GhiChu { get; set; }
        public int SucChuaToiDa { get; set; }
        public Guid FarmID { get; set; }        
    }
}
