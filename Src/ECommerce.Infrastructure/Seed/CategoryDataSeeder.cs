using ECommerce.Domain.Entities;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Seed;

public static class CategoryDataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Categories.AnyAsync())
            return;

        var categories = new List<Category>
        {
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Electronics",
                Description = "Electronic products"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Fashion",
                Description = "Fashion and clothing"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Books",
                Description = "Books and magazines"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Home & Kitchen",
                Description = "Home and kitchen products"
            },
            new Category
            {
                Id = Guid.NewGuid(),
                Name = "Sports",
                Description = "Sports and fitness products"
            }
        };

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
    }
}