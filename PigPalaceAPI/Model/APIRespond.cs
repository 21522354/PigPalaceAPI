namespace PigPalaceAPI.Model
{
    public class APIRespond
    {
        public Guid UserID { get; set; }     
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
