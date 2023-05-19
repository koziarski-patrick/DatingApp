using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{
    public static class IdentityServiceExtensions // This is an extension class for the identity service (JWT bearer authentication scheme)
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  // Add the authentication scheme to the services container (JWT bearer authentication scheme)
            .AddJwtBearer(options =>
            { // Add the JWT bearer options to the services container 
                options.TokenValidationParameters = new TokenValidationParameters // Add the token validation parameters to the services container (rules for validating the token)
                {
                    ValidateIssuerSigningKey = true, // Validate the issuer signing key (the key that was used to sign the token).
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])), // Key that was used to sign the token (the same key that was used to create the token).
                    ValidateIssuer = false, // Validate the issuer of the token (the API server) (info about the issuer is not included in the token)
                    ValidateAudience = false // Validate the audience of the token (the Angular application) (info about the audience is not included in the token)
                };
            }); // This will add the authentication service to the services container.
            return services;
        }
    }
}