using System.ComponentModel.DataAnnotations;

namespace BinusLibrary.Model.BinusLibrary
{
    public class MsBook
    {
        [Key]
        public int BookID { get; set; }
        public string ShelfID { get; set; }
        public string BookTitle { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Byte Availability { get; set; }

        /* 1 = Book Available,  0 = Book Borrowed or Lost*/
    }
}
