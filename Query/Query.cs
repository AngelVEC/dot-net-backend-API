using dot_net_backend_api.Object;
using Microsoft.EntityFrameworkCore;
using dot_net_backend_api.Data;
using dot_net_backend_API.Migrations;

namespace dot_net_backend_api.Query
{
    public class Query{
        
        //for User object
        public async Task<List<User>> AllUsersAsync([Service] ApiDbContext dbContext)
        {
            return await dbContext.users.ToListAsync();
        }

        // for food object
        public async Task<List<Food>> AllfoodsAsync([Service] ApiDbContext dbContext)
        {
            return await dbContext.foods.ToListAsync();
        }

        public async Task<List<Admin>> AllAdminAsync([Service] ApiDbContext dbContext)
        {
            return await dbContext.admin.ToListAsync();
        }

        public bool AdminCheck([Service] ApiDbContext dbContext, string username, string password)
        {
            var adminData = dbContext.admin.Where(e => e.UserName == username && e.Password == password).FirstOrDefault();
            
            if (adminData != null)
            {
                return true;
            }

            return false;
        }

        public bool UserCheck([Service] ApiDbContext dbContext, string username, string password)
        {
            var userData = dbContext.users.Where(e => e.UserName == username && e.Password == password).FirstOrDefault();
            
            if (userData != null)
            {
                return true;
            }

            return false;
        }
    }
}