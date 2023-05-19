using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // .../api/users
    [Authorize] // This will require the user to be authorized to access the users controller.
    public class UsersController : BaseApiController // This is the controller that will be used for the users.
    {
        private readonly DataContext _context; // Database context that will be used to access the database.

        public UsersController(DataContext context) // Constructor that will be used to inject the database context.
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet] // .../api/users
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() // Returns a list of users
        {
            var users = await _context.Users.ToListAsync(); // Get the users from the database. ToListAsync() is an extension method that will convert the users to a list asynchronously.
            return users;
        }

        [HttpGet("{id}")] // .../api/users/id
        public async Task<ActionResult<AppUser>> GetUser(int id) // Returns a single user
        {
            var user = await _context.Users.FindAsync(id); // Get the user from the database. FindAsync() is an extension method that will find the user asynchronously.
            return user;
        }
    }
}