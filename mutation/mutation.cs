using dot_net_backend_api.Data;
using dot_net_backend_api.Object;
using Microsoft.EntityFrameworkCore;

namespace dot_net_backend_api.mutation;

public class Mutation
{
    public async Task<bool> CreateUserAsync([Service] ApiDbContext dbContext, string username, string password)
    {
            var user = new User 
            {
                UserName = username,
                Password = password
            };

            await dbContext.users.AddAsync(user);

            //If it write to the database will return any number above 0
            var result = await dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
    }

        public async Task<bool> CreateAdminAsync([Service] ApiDbContext dbContext, string username, string password)
    {
            var admin = new Admin 
            {
                UserName = username,
                Password = password
            };

            await dbContext.admin.AddAsync(admin);

            //If it write to the database will return any number above 0
            var result = await dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
    }

    public async Task<bool> CreateFoodAsync([Service] ApiDbContext dbContext, string foodname, float price)
    {
        var food = new Food
        {
            FoodName = foodname,
            Price = price,
        };

        await dbContext.foods.AddAsync(food);
        var result = await dbContext.SaveChangesAsync();
        if (result > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> DeleteFood([Service] ApiDbContext dbContext, int id)
    {
        var foodData = dbContext.foods.Where(e => e.Id == id).FirstOrDefault();
        if (foodData != null)
            {
                dbContext.foods.Remove(foodData);
                var result = await dbContext.SaveChangesAsync();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
        
        
        return false;
    }

    public async Task<bool> updateFood([Service] ApiDbContext dbContext, Food updatedFood)
    {
        var foodData = dbContext.foods.Where(e => e.Id == updatedFood.Id);

        if (foodData != null)
        {
            dbContext.foods.Update(updatedFood);
            var result = await dbContext.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}