
using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Application.Common.Interface.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        // 1. Validate the user don't exist
        if (_userRepository.GetUserByEmail(Email) != null)
        {
            throw new Exception("User already exists");
        }

        // 2. Create the user and save it DB
        var user = new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
        };

        _userRepository.Add(user);
        // 3. Generate the token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string Email, string Password)
    {

        // 1. Validate the user exist
        if (_userRepository.GetUserByEmail(Email) is not User user)
        {
            throw new Exception("User not found");
        }

        // 2. Validate the password

        if (user.Password != Password)
        {
            throw new Exception("Invalid password");
        }

        // 3. Generate the token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);

    }

}