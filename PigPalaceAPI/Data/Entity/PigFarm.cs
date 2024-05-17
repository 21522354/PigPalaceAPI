using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    [Table("PigFarm")]
    public class PigFarm
    {
        [Key]   
        public Guid FarmID { get; set; } 
        public string? Name { get; set; }
        public Guid AccountID { get; set; }
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }    
    }
}
