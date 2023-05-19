using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto // This is the DTO that will be used to transfer data from the client to the server.
    {
        [Required] // Data annotation that will make sure that the username is required.
        public string UserName { get; set; } // The username of the user.

        [Required]
        public string Password { get; set; } // The password of the user.
    }
}