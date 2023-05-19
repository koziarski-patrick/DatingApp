using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDto // This is the user DTO that will be used to return the user to the client.
    {
        public string Username { get; set; }
        public string Token { get; set; } // This is the token that will be returned to the user.
    }
}