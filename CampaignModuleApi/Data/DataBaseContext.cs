using CampaignModuleApi.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace CampaignModuleApi.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public string DbPath { get; private set; }

        public DataBaseContext()
        {
            DbPath = $"CampaignModule.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{GetEnviroment()}.json", false, true)
                .AddEnvironmentVariables()
                .Build();


            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            options.EnableSensitiveDataLogging();
        }

        string? GetEnviroment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }

    }
}
