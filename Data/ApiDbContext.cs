using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using dot_net_backend_api.Object;

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
            //Declaring the username,password, and host. and then assign these variable with the "Secret" that stored in local
            var username = Configuration["postgress-username"];
            var password = Configuration["postgress-password"];
            var host =  Configuration["postgress-host"];

            // Make a connection to the database and replace the default username,password, and host to variable assigned above
            options.UseNpgsql(Configuration.GetConnectionString("postgressConnection")
            .Replace("{USERNAME}", username)
            .Replace("{PASSWORD}", password)
            .Replace("{HOST}", host));
        }

        //Create the database
        public DbSet <User> Users { get; set;}
        public DbSet <Food> Foods { get; set; }
    }
}