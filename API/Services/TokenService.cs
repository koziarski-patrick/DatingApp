using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    // This class is used to create a token for the user to use for authentication purposes. 
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key; // This is the key that will be used to sign the token. 
        public TokenService(IConfiguration config) 
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string CreateToken(AppUser user) // Creates the token.
        {
            var claims = new List<Claim> { // List of claims that will be added to the token. 
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); // Credentials that will be used to sign the token.
            var tokenDescriptor = new SecurityTokenDescriptor { // Token descriptor that will be used to create the token.
                Subject = new ClaimsIdentity(claims), // Subject of the token.
                Expires = DateTime.UtcNow.AddDays(7), // Expiration date of the token.
                SigningCredentials = creds // This is the signing credentials of the token.
            };
            var tokenHandler = new JwtSecurityTokenHandler(); // This is the token handler that will be used to create the token.
            var token = tokenHandler.CreateToken(tokenDescriptor); // This will create the token.
            return tokenHandler.WriteToken(token); // This will return the token.
        }
    }
}