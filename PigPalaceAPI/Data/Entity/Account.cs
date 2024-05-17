using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Data.Entity
{
    public class Account
    {
        [Key]
        public Guid AccountID { get; set; }
        public string? Gmail { get; set; }
        public string? PassWord { get; set; }
        public bool IsFromGoogle { get; set; }
        public bool IsFromFB { get; set; }

        public string? FBID { get; set; }
        public string? GoogleID { get; set; }
        public bool IsPremium { get; set; } 
    }
}
