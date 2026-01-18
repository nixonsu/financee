using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User?> GetUserAsync(Guid id)
    {
        var user = await context.Users
            .FirstAsync(e => e.Id == id);

        return user.ToDomain();
    }

    public async Task<User?> GetUserAsync(string subject)
    {
        var user = await context.Users
            .FirstAsync(e => e.Subject == subject);

        return user.ToDomain();
    }

    public async Task<Guid> CreateUserAsync(string subject, string firstName, string lastName, string email)
    {
        var userEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            Subject = subject,
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };
        
        await context.Users.AddAsync(userEntity);
        await context.SaveChangesAsync();
        return userEntity.Id;
    }
}