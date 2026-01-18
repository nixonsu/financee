using Domain.Models;

namespace Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserAsync(Guid id);
    Task<User?> GetUserAsync(string subject);
    Task<Guid> CreateUserAsync(string subject, string firstName, string lastName, string email);
}