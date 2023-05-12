using BinusLibrary.Helper;
using BinusLibrary.Model.Response;
using BinusLibrary.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BinusLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookHelper bookHelper;
        public BookController(BookHelper bookHelper)
        {
            this.bookHelper = bookHelper;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult getAllBook(string keyword)
        {
            try
            {
                var objJSON = new List<BookResponse>();
                objJSON = bookHelper.GetAllBook(keyword);
                if(objJSON.Count == 0) {
                    Response.StatusCode = 404;
                    return new ObjectResult(new StatusOutput { message = "cannot find any book with given keyword!", statusCode = 404 });
                }

                return new OkObjectResult(objJSON);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    
    }



}
