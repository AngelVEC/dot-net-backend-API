using dot_net_backend_api.Object;
using Microsoft.EntityFrameworkCore;
using dot_net_backend_api.Data;

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
    }
}