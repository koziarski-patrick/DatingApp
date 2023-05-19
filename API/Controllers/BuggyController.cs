using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")] // This is the route for this method. It will be api/buggy/auth
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [Authorize]
        [HttpGet("not-found")] // This is the route for this method. It will be api/buggy/not-found
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.Users.Find(-1); // This will return null because there is no user with id -1
            if (thing == null) return NotFound(); // This will return a 404 Not Found response
            return thing; // This will never be reached because the NotFound() method will return a response
        }

        [Authorize]
        [HttpGet("server-error")] // This is the route for this method. It will be api/buggy/auth
        public ActionResult<string> GetServerError()
        {
            var thing = _context.Users.Find(-1); // This will return null because there is no user with id -1
            var thingToReturn = thing.ToString(); // This will throw an exception because thing is null
            return thingToReturn; 
        }

        [Authorize]
        [HttpGet("bad-request")] // This is the route for this method. It will be api/buggy/auth
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request"); // This will return a 400 Bad Request response
        }
    }
}