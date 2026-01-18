using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class UserService(IUserRepository userRepository)
{
    public async Task<User> GetOrCreateUserAsync(string subject)
    {
        var user = await userRepository.GetUserAsync(subject);

        if (user != null)
        {
            return user;
        }

        // TODO: Call Auth0Service for firstname, lastname, email
        var firstName = string.Empty;
        var lastName = string.Empty;
        var email = string.Empty;
        var id = await userRepository.CreateUserAsync(subject, firstName, lastName, email);
        return (await userRepository.GetUserAsync(id))!;
    }
}