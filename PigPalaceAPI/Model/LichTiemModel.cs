using PigPalaceAPI.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Model
{
    public class LichTiemModel
    {
        public Guid MaLichTiem { get; set; }
        public DateTime NgayTiem { get; set; }
        public int MaHangHoa { get; set; }
        public float LieuLuong { get; set; }
        public Guid UserID { get; set; }
        public string TinhTrang { get; set; }
        public Guid FarmID { get; set; }    
    }
}
