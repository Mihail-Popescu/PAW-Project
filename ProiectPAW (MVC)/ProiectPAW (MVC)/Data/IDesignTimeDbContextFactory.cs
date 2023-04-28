using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProiectPAW__MVC_.Data
{
    public class ProiectPAWDbContextFactory : IDesignTimeDbContextFactory<ProiectPAWDbContext>
    {
        public ProiectPAWDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ProiectPAWDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ProiectPAWDbContext"));

            return new ProiectPAWDbContext(optionsBuilder.Options, configuration);
        }
    }
}
