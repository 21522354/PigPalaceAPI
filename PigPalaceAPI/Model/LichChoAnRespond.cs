namespace PigPalaceAPI.Model
{
    public class LichChoAnRespond
    {
        public Guid ID { get; set; }
        public DateTime NgayChoAn { get; set; }
        public Guid MaChuong { get; set; }
        public string TenHangHoa { get; set; }  
        public Guid UserID { get; set; }
        public string TinhTrang { get; set; }
        public float LuongThucAn { get; set; }
        public Guid FarmID { get; set; }
    }
}
