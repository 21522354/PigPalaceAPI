using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    public class CT_HOADONHEO
    {
        [Key]
        public int ID { get; set; }
        public string MaHeo { get; set; }
        [ForeignKey("MaHeo")]   
        public virtual HEO HEO { get; set; }
        public string MaHoaDon { get; set; }
        [ForeignKey("MaHoaDon")]    
        public virtual HOADONHEO HOADONHEO { get; set; }
        public Guid FarmID { get; set; }    
    }
}
