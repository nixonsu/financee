using System.Text.RegularExpressions;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public partial class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<BusinessEntity> Businesses { get; set; }
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            
        modelBuilder.Entity<BusinessEntity>()
            .HasOne(b => b.User)
            .WithMany(u => u.Businesses)
            .HasForeignKey(b => b.UserId)
            .HasPrincipalKey(b => b.Id)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<ClientEntity>()
            .HasOne(c => c.Business)
            .WithMany(b => b.Clients)
            .HasForeignKey(c => c.BusinessId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Subject);

        // Convert all table and column names to snake_case
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Convert table name to snake_case
            entity.SetTableName(ToSnakeCase(entity.GetTableName()!));

            // Convert all column names to snake_case
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(ToSnakeCase(property.Name));
            }
        }
    }

    private static string ToSnakeCase(string input)
    {
        var camelCasePattern = AlphaNumericRegex().Replace(input, "$1_$2");
        return camelCasePattern.ToLower();
    }

    [GeneratedRegex("([a-z0-9])([A-Z])")]
    private static partial Regex AlphaNumericRegex();
}