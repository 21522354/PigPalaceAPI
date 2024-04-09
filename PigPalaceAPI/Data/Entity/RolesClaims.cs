using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Data.Entity
{
    public class RolesClaims
    {
        [Key]
        public string RoleClaimID { get; set; }
        public Guid FarmID { get; set; }
        public string ActionDetail { get; set; }
        public string RoleID { get; set; }
        public virtual Roles Role { get; set; } 

    }
}
