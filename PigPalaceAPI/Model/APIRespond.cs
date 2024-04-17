namespace PigPalaceAPI.Model
{
    public class APIRespond
    {
        public int UserID { get; set; }     
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
