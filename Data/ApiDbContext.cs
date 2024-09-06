using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dot_net_backend_api.Data 
{
    public class ApiDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public ApiDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var username = Configuration["postgress-username"];
            var password = Configuration["postgress-password"];
            var host =  Configuration["postgress-host"];
            options.UseNpgsql(Configuration.GetConnectionString("postgressConnection")
            .Replace("{USERNAME}", username)
            .Replace("{PASSWORD}", password)
            .Replace("{HOST}", host));
        }

        public DbSet <User> Users { get; set;}
        public DbSet <Food> foods { get; set; }
    }
}