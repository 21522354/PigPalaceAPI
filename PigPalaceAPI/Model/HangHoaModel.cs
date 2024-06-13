namespace PigPalaceAPI.Model
{
    public class HangHoaModel
    {
        public string TenHangHoa { get; set; }
        public string LoaiHangHoa { get; set; }
        public float TonKho { get; set; }
        public float GiaTriToiThieu { get; set; }
        public float TienMuaTrenMotDonVi { get; set; }
        public string DonViTinh { get; set; }
        public DateTime NgayHetHan { get; set; }
        public Guid FarmID { get; set; }
    }
}
