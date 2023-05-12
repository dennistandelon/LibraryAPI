using BinusLibrary.Helper;
using BinusLibrary.Model.Request;
using BinusLibrary.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinusLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private StudentHelper studentHelper;
        public StudentController(StudentHelper studentHelper){
            this.studentHelper = studentHelper;
        }

        [HttpPost("blacklist")]
        [Produces("application/json")]
        public IActionResult blackListStudent([FromBody] BlacklistRequest data)
        {
            try
            {
                var objJSON = new StatusOutput();
                objJSON = studentHelper.BlacklistStudent(data);

                Response.StatusCode = objJSON.statusCode;
                return new ObjectResult(objJSON);            
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

    }
}
