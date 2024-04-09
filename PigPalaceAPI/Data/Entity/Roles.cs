using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Data.Entity
{
    public class Roles
    {
        [Key]
        public string RoleID { get; set; }
        public Guid FarmID { get; set; }        
        public string RoleName { get; set; }
        public float BasicSalary { get; set; }
        public string Description { get; set; }     
    }
}
