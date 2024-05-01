using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    [Table("GIONGHEO")]
    public class GIONGHEO
    {
        [Key]
        public int MaGiongHeo { get; set; }
        public string TenGiongHeo { get; set; } 
        public string MoTa { get; set; }
        public Guid FarmID { get; set; }    
    }
}
