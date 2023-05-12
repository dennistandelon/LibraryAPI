using BinusLibrary.Model.BinusLibrary;
using BinusLibrary.Model.Request;
using BinusLibrary.Output;

namespace BinusLibrary.Helper
{
    public class StudentHelper
    {
        private BinusLibraryContext dbContext;
        public StudentHelper(BinusLibraryContext dbContext) {
            this.dbContext = dbContext;
        }

        public StatusOutput BlacklistStudent(BlacklistRequest data)
        {
            try
            {
                var apikey = "48t8g7u4rh890y45h5y50hgf";
                var blackListedStudent = dbContext.MsStudent.Where(st => st.studentID == data.studentID).FirstOrDefault();
                var lostBook = dbContext.MsBook.Where(book => book.BookID == data.bookID).FirstOrDefault();
                if (data.key != apikey)
                {
                    return new StatusOutput { message = "You don't have permission to access this API!", statusCode = 403 };
                }
                if (blackListedStudent == null || lostBook == null)
                {
                    return new StatusOutput { message = "Not Found", statusCode = 500 };
                }
                
                blackListedStudent.isBlacklisted = 1;
                lostBook.Availability = 0;


                dbContext.MsBook.Update(lostBook);

                dbContext.MsStudent.Update(blackListedStudent);
                dbContext.SaveChanges();

                return new StatusOutput { message = "Success", statusCode = 200 };
            }
            catch (Exception ex)
            {
                return new StatusOutput { message = ex.Message, statusCode = 500 };
            }
        }
    }
}
