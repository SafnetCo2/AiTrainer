using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HotelChatbotBackend;
using System.IO;

public class HotelDbContextFactory : IDesignTimeDbContextFactory<HotelDbContext>
{
    public HotelDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<HotelDbContext>();

        // Manually build the IConfiguration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Make sure it points to the correct directory
            .AddJsonFile("appsettings.json") // Ensure that appsettings.json exists
            .Build();

        var connectionString = configuration.GetConnectionString("HotelDb");

        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion("8.0.23"), options => options.EnableRetryOnFailure());

        return new HotelDbContext(optionsBuilder.Options);
    }
}
