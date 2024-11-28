using ChitChatAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class ChitChatDbContextFactory : IDesignTimeDbContextFactory<ChitChatDbContext>
{
    public ChitChatDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddUserSecrets(typeof(ChitChatDbContextFactory).Assembly)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not found.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<ChitChatDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ChitChatDbContext(optionsBuilder.Options);
    }
}
