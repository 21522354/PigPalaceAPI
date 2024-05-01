using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    [Table("LOAIHEO")]
    public class LOAIHEO
    {
        [Key]
        public int MaLoaiHeo { get; set; }
        public string TenLoaiHeo { get; set; }
        public string MoTa { get; set; }
        public Guid FarmID { get; set; }                
    }
}
