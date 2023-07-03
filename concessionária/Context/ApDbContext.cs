using concessionária.Models;
using Microsoft.EntityFrameworkCore;

namespace concessionária.Context
{
    public class ApDbContext : DbContext
    {
        public ApDbContext(DbContextOptions<ApDbContext> options)
            : base(options) 
        { 
        
        }

        public DbSet<Veiculos> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }
}
