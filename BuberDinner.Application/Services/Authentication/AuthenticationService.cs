
using BuberDinner.Application.Common.Interface.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public AuthenticationResult Login(string Email, string Password)
    {
        
        return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", Email, "token");
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        // TODO: Check if user exists in the database

      
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, FirstName, LastName);

        return new AuthenticationResult(userId, FirstName, LastName, Email, token);
    }
}