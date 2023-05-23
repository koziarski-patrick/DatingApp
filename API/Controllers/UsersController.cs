using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    // .../api/users
    [Authorize] // This will require the user to be authorized to access the users controller.
    public class UsersController : BaseApiController // This is the controller that will be used for the users.
    {
        private readonly IUserRepository _userRepository; // This will be used to access the database.
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper) // Constructor that will be used to inject the database context.
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet] // .../api/users
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() // Returns a list of users
        {
            var users = await _userRepository.GetUsersAsync(); // Get the users from the database

            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users); // Map the users to the MemberDto

            return Ok(usersToReturn); // Return the users
        }

        [HttpGet("{id}")] // .../api/users/{{id}}
        public async Task<ActionResult<MemberDto>> GetUser(int id) // Returns a single user
        {
            var user = await _userRepository.GetUserByIdAsync(id); // Get the user from the database
            return _mapper.Map<MemberDto>(user); // Map the user to the MemberDto
        }

        [HttpGet("{username}")] // .../api/users/{{username}}
        public async Task<ActionResult<MemberDto>> GetUser(string username) // Returns a single user
        {
            var user = await _userRepository.GetUserByUsernameAsync(username); // Get the user from the database
            return _mapper.Map<MemberDto>(user); // Map the user to the MemberDto
        }
    }
}