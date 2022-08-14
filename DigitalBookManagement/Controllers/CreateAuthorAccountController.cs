using DigitalBookManagement.Model;
using DigitalBookManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DigitalBookManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateAuthorAccountController : ControllerBase
    {
        //private readonly ICreateAuthorAccout _createAuthorAccout;
        //public CreateAuthorAccountController(ICreateAuthorAccout createAuthorAccout)
        //{
        //    _createAuthorAccout = createAuthorAccout;
        //}

        //[HttpPost]
        //public ActionResult<string> CreateAuthor([FromBody]User userDetails)
        //{
        //    string result = _createAuthorAccout.CreateAuthor(userDetails);
        //    return Ok(result);
        //}
    }
}