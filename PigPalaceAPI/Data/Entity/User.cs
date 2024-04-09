using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Data.Entity
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
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
        public string RoleID { get; set; }  
        public virtual Roles Role { get; set; } 
    }
}
