using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    public class HOADON
    {
        [Key]
        public string MaHoaDon { get; set; }
        public string LoaiHoaDon { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaDoiTac { get; set; }
        [ForeignKey("MaDoiTac")]
        public virtual DOITAC DOITAC { get; set; }  

    }
}
