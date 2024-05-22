using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace PigPalaceAPI.Data.Entity
{
    public class LICHTIEM
    {
        [Key]
        public Guid MaLichTiem { get; set; }
        public DateTime NgayTiem { get; set; }
        public int MaHangHoa { get; set; }
        [ForeignKey("MaHangHoa")]
        public virtual HANGHOA HANGHOA { get; set; }
        public float LieuLuong { get; set; }
        public Guid UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }  
        public string TinhTrang { get; set; }   

    }
}
