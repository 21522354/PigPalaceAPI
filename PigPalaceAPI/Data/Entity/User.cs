using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }
        public Guid FarmID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]  
        public string PassWord { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Sex { get; set; }
        public float CoefficientsSalary { get; set; }
        public string? RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Roles? Role { get; set; } 
    }
}
