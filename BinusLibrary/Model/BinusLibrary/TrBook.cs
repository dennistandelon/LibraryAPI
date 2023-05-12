using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BinusLibrary.Model.BinusLibrary
{
    public class TrBook
    {
        public string studentID { get; set; }
        [Key]
        public int bookID { get; set; }
    }
}
