

using BuberDinner.Application.Common.Interface.Authentication;
using BuberDinner.Application.Common.Interface.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;

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

    public ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password)
    {
        // 1. Validate the user don't exist
        if (_userRepository.GetUserByEmail(Email) != null)
        {
            return Errors.User.DuplicateEmail;
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

    public ErrorOr<AuthenticationResult> Login(string Email, string Password)
    {

        // 1. Validate the user exist
        if (_userRepository.GetUserByEmail(Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password

        if (user.Password != Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // 3. Generate the token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);

    }

}