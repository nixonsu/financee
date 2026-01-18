using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<BusinessEntity> Businesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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
        var camelCasePattern = System.Text.RegularExpressions.Regex.Replace(
            input,
            "([a-z0-9])([A-Z])",
            "$1_$2");
        return camelCasePattern.ToLower();
    }
}