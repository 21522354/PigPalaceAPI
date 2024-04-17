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
        public string? Gmail { get; set; }
        public string? PassWord { get; set; }
        public bool IsFromGoogle { get; set; }
        public bool IsFromFB { get; set; }  

        public string? FBID { get; set; }
        public string? GoogleID { get; set; }
    }
}
