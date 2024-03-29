using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    [Table("PigFarm")]
    public class PigFarm
    {
        public int ID { get; set; } 
        public string Name { get; set; }    
        public string Address { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]  
        public string PassWord { get; set; }    
    }
}
