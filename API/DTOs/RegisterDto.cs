using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto // This is the DTO that will be used to transfer data from the client to the server.
    {
        [Required] // Data annotation that will make sure that the username is required.
        public string UserName { get; set; } // The username of the user.

        [Required]
        [StringLength(8, MinimumLength = 4)] // Data annotation that will make sure that the password is required and is between 4 and 8 characters long.
        public string Password { get; set; } // The password of the user.
    }
}