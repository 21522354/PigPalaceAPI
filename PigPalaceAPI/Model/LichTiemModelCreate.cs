namespace PigPalaceAPI.Model
{
    public class LichTiemModelCreate
    {
        public DateTime NgayTiem { get; set; }
        public int MaHangHoa { get; set; }
        public float LieuLuong { get; set; }
        public Guid UserID { get; set; }
        public Guid FarmID { get; set; }
        public List<HeoIDModel> ListHeoTiem { get; set; }       
    }
    public class HeoIDModel
    {
        public string MaHeo { get; set; }
    }
}
