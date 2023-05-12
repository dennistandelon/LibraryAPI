using BinusLibrary.Model.Request;
using BinusLibrary.Output;
using System.Runtime.CompilerServices;

namespace BinusLibrary.Helper
{
    public class BorrowHelper
    {
        private BinusLibraryContext dbContext;
        public BorrowHelper(BinusLibraryContext dbContext) {
            this.dbContext = dbContext;
        }

        public StatusOutput createBorrow(BorrowBookRequest data)
        {
            var apikey = "48t8g7u4rh890y45h5y50hgf";
            try
            {
                var student = dbContext.MsStudent.Where(st => st.studentID == data.studentID).FirstOrDefault();
                var book = dbContext.MsBook.Where(bk => bk.BookID == data.bookID).FirstOrDefault();
                if (data.key != apikey)
                {
                    return new StatusOutput { message = "You don't have permission to access this API!", statusCode = 403 };
                }

                if(book == null || student == null)
                {
                    return new StatusOutput { message = "Invalid Student ID or Book ID!", statusCode = 500 };
                } 
                if(student.isBlacklisted == 1)
                {
                    return new StatusOutput { message = "Student Blacklisted", statusCode = 500 };
                }
                if (book.Availability == 0)
                {
                    return new StatusOutput { message = "Book not available", statusCode = 500 };
                }


                book.Availability = 0;
                dbContext.MsBook.Update(book);


                dbContext.TrBook.Add(new Model.BinusLibrary.TrBook { studentID = data.studentID, bookID = data.bookID });
                dbContext.SaveChanges();

                return new StatusOutput { message = "Success", statusCode= 200 };
            }catch (Exception ex)
            {
                return new StatusOutput {message=ex.Message, statusCode=500 };
            }

        }

        public StatusOutput returnBorrow(ReturnBookRequest data)
        {
            var apikey = "48t8g7u4rh890y45h5y50hgf";
            try
            {
                if (data.key != apikey)
                {
                    return new StatusOutput { message = "You don't have permission to access this API!", statusCode = 403 };
                }
                var deleteBorrow = dbContext.TrBook.Where(borrow => borrow.bookID == data.bookID).FirstOrDefault();


                if(deleteBorrow == null)
                {
                    return new StatusOutput { message = "Transaction Not Found", statusCode = 500 };
                }

                var book = dbContext.MsBook.Where(bk => bk.BookID == deleteBorrow.bookID).FirstOrDefault();
                book.Availability = 1;
                dbContext.MsBook.Update(book);

                dbContext.TrBook.Remove(deleteBorrow);
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
