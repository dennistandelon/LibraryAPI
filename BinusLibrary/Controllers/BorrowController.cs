using BinusLibrary.Helper;
using BinusLibrary.Model.Request;
using BinusLibrary.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinusLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {

        private BorrowHelper borrowHelper;
        public BorrowController(BorrowHelper borrowHelper)
        {
            this.borrowHelper = borrowHelper;
        }

        [HttpPost("borrow")]
        [Produces("application/json")]
        public IActionResult createBorrow([FromBody] BorrowBookRequest data)
        {
            try
            {
                var objJSON = new StatusOutput();
                objJSON = borrowHelper.createBorrow(data);
                Response.StatusCode = objJSON.statusCode;

                return new ObjectResult(objJSON);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("return")]
        [Produces("application/json")]
        public IActionResult returnBorrow([FromBody] ReturnBookRequest data)
        {
            try
            {
                var objJSON = new StatusOutput();
                objJSON = borrowHelper.returnBorrow(data);
                Response.StatusCode = objJSON.statusCode;

                return new ObjectResult(objJSON);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
