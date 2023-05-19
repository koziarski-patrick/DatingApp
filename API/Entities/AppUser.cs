using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUser // This is the entity that will be used to represent the user in the database.
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; } // The password will be stored as a byte array.

        public byte[] PasswordSalt { get; set; } // The password salt will be stored as a byte array.

    }
}