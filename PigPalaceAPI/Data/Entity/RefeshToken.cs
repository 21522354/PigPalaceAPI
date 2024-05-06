using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Data.Entity
{
    [Table("RefreshToken")]
    public class RefreshToken
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public User CurrentUser { get; set; }
        public string Token { get; set; }
        public string JwtID { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
