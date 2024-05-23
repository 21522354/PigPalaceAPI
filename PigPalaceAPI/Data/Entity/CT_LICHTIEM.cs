using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    public class CT_LICHTIEM
    {
        [Key]
        public int ID { get; set; }
        public Guid MaLich { get; set; }
        [ForeignKey("MaLich")]
        public virtual LICHTIEM LICHTIEM { get; set; }
        public string MaHeo { get; set; }
        [ForeignKey("MaHeo")]
        public virtual HEO HEO { get; set; }
        public Guid FarmID { get; set; }        
    }
}
