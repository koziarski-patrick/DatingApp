using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // This is the controller that will be used for the account. 
    public class AccountController : BaseApiController 
    {
        private readonly DataContext _context; // This is the database context that will be used to access the database.
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")] // .../api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) // This method will be used to register a user. 
        {
            if (await UserExists(registerDto.UserName)) return BadRequest("Username is taken"); // This will check if the username is taken.

            using var hmac = new HMACSHA512(); // Create a new instance of the HMACSHA512 class.

            var user = new AppUser // Create a new instance of the AppUser class.
            {
                UserName = registerDto.UserName.ToLower(), // This will set the username to the username from the registerDto. 
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)), // This will compute the hash of the password.
                PasswordSalt = hmac.Key // This will set the password salt to the key of the HMACSHA512 instance.
            };

            _context.Users.Add(user); // Add the user to the database.
            await _context.SaveChangesAsync(); // Save the changes to the database.

            return new UserDto { // Return a new instance of the UserDto class to hide the password hash and password salt.
                Username = user.UserName, // Set the username to the username of the user.
                Token = _tokenService.CreateToken(user) // Set the token to the token created by the token service (ITokenService)
            }; 
        }

        [HttpPost("login")] // .../api/account/login
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) // This method will be used to login a user.
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName); // Get the user from the database.

            if (user == null) return Unauthorized("Invalid username"); // If the user is null, return an unauthorized error.

            using var hmac = new HMACSHA512(user.PasswordSalt); // Create a new instance of the HMACSHA512 class with the password salt of the user.

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password)); // Compute the hash of the password.

            for (int i = 0; i < computedHash.Length; i++) // Loop through the computed hash.
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password"); // If the computed hash is not equal to the password hash, return an unauthorized error.

            return new UserDto { // Return a new instance of the UserDto class to hide the password hash and password salt.
                Username = user.UserName, // Set the username to the username of the user.
                Token = _tokenService.CreateToken(user) // Set the token to the token created by the token service (ITokenService)
            }; 
        }

        private async Task<bool> UserExists(string username) // This method will check if a user exists.
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower()); // Return true if the user exists, false if not.
        }
    }
}