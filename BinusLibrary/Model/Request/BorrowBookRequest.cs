namespace BinusLibrary.Model.Request
{
    public class BorrowBookRequest
    {
        public int bookID { get; set; }
        public string studentID { get; set; }
        public string key { get; set; }
    }
}
