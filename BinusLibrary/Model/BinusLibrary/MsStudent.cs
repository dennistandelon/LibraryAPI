using System.ComponentModel.DataAnnotations;

namespace BinusLibrary.Model.BinusLibrary
{
    public class MsStudent
    {
        [Key]
        public string studentID { get; set; }
        public string studentName { get; set; }
        public Byte isBlacklisted { get; set; }

        /*  1 = Blacklisted, 0 = Not Blacklisted */
    }
}
