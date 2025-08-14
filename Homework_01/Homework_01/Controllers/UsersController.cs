using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        // GET api/users
        [HttpGet]
        public ActionResult<List<string>> GetAllUsers()
        {
            return Ok(StaticDb.Users);
        }

        // GET api/users/{index}
        [HttpGet("{index}")]
        public ActionResult<string> GetUserByIndex(int index)
        {
            if (index < 0 || index >= StaticDb.Users.Count)
            {
                return NotFound("User not found");
            }
            return Ok(StaticDb.Users[index]);
        }
    }
}

