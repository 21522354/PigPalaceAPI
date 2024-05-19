using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Data.Entity
{
    public class LICHCHOAN
    {
        [Key]
        public Guid ID { get; set; }
        public DateTime NgayChoAn { get; set; }
        public Guid MaChuong { get; set; }
        [ForeignKey("MaChuong")]
        public virtual CHUONGHEO CHUONGHEO { get; set; }
        public int MaHangHoa { get; set; }
        [ForeignKey("MaHangHoa")]
        public virtual HANGHOA HANGHOA { get; set; }
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }      
        public string TinhTrang { get; set; }
        public float LuongThucAn1Con { get; set; }
        public Guid FarmID { get; set; }    

    }
}
