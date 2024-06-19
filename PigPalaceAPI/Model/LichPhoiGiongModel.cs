using PigPalaceAPI.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PigPalaceAPI.Model
{
    public class LichPhoiGiongModel
    {
        public string MaLich { get; set; }
        public string MaHeoNai { get; set; }
        public string? MaHeoDuc { get; set; }
        public DateTime NgayPhoi { get; set; }
        public Guid UserID { get; set; }
        public Guid FarmID { get; set; }
        public string GhiChu { get; set; }
        public string LoaiPhoiGiong { get; set; }
        public int? MaGiongHeoDuc { get; set; }
    }
}
