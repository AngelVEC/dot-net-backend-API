using dot_net_backend_api.Data;
using dot_net_backend_api.Object;
using Microsoft.EntityFrameworkCore;

namespace dot_net_backend_api.mutation;

public class Mutation
{
    public async Task<User> CreateUserAsync([Service] ApiDbContext dbContext, string username, string password)
    {
            var user = new User 
            {
                UserName = username,
                Password = password
            };

            await dbContext.users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
    }

    public async Task<Food> CreateFoodAsync([Service] ApiDbContext dbContext, string foodname, float price)
    {
        var food = new Food
        {
            FoodName = foodname,
            Price = price,
        };

        await dbContext.foods.AddAsync(food);
        await dbContext.SaveChangesAsync();
        return food;
    }
}