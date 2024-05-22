namespace PigPalaceAPI.Model
{
    public class LichChoAnNhieuNgayModel
    {
        public Guid FarmID { get; set; }
        public Guid UserID { get; set; }    
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public DateTime ThoiGianCachNhauMoiLanChoAn { get; set; }
        public int MaHangHoa { get; set; }
        public float SoLuongCho1ConHeo1Ngay { get; set; }
        public int SoLanChoAnMoiNgay { get; set; }
        public List<ChuongChoAn> ListChuongHeoChoAn { get; set; }
    }
}
