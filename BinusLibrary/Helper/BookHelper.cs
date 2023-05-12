using BinusLibrary.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BinusLibrary.Helper
{
    public class BookHelper
    {
        private BinusLibraryContext dbContext;
        public BookHelper(BinusLibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Produces("application/json")]
        public List<BookResponse> GetAllBook(string keyword)
        {
            var returnValue = new List<BookResponse>();
            try
            {
                var books = dbContext.MsBook.ToList();


                returnValue = books.Where(book =>
                    (((book.BookID.ToString().ToLower().Contains(keyword.ToLower())) ||
                    (book.BookTitle.ToString().ToLower().Contains(keyword.ToLower())) ||
                    (book.Author.ToString().ToLower().Contains(keyword.ToLower())) ||
                    (book.Publisher.ToString().ToLower().Contains(keyword.ToLower())))
                    && (book.Availability == 1))
                    ).Select(book => new BookResponse
                {
                    BookID = book.BookID,
                    ShelfID = book.ShelfID,
                    BookTitle = book.BookTitle,
                    Category = book.Category,
                    Author = book.Author,
                    Publisher = book.Publisher,
                    Availability = book.Availability
                }).ToList() ;

                
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return returnValue;
        }



    }
}
