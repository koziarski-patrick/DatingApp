using API.Entities;

namespace API.Interfaces
{
    public interface ITokenService // This is the interface that will be used to create the token.
    {
        string CreateToken(AppUser user); // This method will create the token.
    }
}