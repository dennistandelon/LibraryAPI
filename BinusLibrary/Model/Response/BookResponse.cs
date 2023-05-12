using System.Net;
using System.Security.Policy;

namespace BinusLibrary.Model.Response
{
    public class BookResponse
    {
        public int BookID { get; set; } 
        public string ShelfID { get; set; }
	    public string BookTitle { get; set; }
	    public string Category { get; set; }
	    public string Author { get; set; }
	    public string Publisher { get; set; }
	    public int Availability { get; set; }
    }
}
