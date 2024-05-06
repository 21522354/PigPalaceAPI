using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Data.Entity
{
    public class HANGHOA
    {
        [Key]
        public int ID { get; set; }
        public string TenHangHoa { get; set; }
        public float TonKho { get; set; }
        public float GiaTriToiThieu { get; set; }
        public float TienMuaTrenMotDonVi { get; set; }
        public string DonViTinh { get; set; }
        public DateTime NgayHetHan { get; set; }
        public Guid FarmID { get; set; }
    }
}
