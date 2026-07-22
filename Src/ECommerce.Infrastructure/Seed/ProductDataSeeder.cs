using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Persistence.Seed;

public static class ProductDataSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Products.AnyAsync())
            return;

        var categories = await context.Categories
            .ToDictionaryAsync(c => c.Name, c => c.Id);

        var now = DateTime.UtcNow;

        var products = new List<Product>
        {
            // Electronics
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "iPhone 16 Pro Max",
                SKU = "ELEC-001",
                Description = "Apple flagship smartphone with A18 Pro chip.",
                Price = 185000m,
                Stock = 20,
                Status = ProductStatus.Active,
                CategoryId = categories["Electronics"],
                CreatedAt = now,
                UpdatedAt = now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy S25 Ultra",
                SKU = "ELEC-002",
                Description = "Samsung premium Android smartphone.",
                Price = 165000m,
                Stock = 15,
                Status = ProductStatus.Active,
                CategoryId = categories["Electronics"],
                CreatedAt = now,
                UpdatedAt = now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dell XPS 15",
                SKU = "ELEC-003",
                Description = "High-performance professional laptop.",
                Price = 235000m,
                Stock = 10,
                Status = ProductStatus.Active,
                CategoryId = categories["Electronics"],
                CreatedAt = now,
                UpdatedAt = now
            },

            // Fashion
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Nike Air Max",
                SKU = "FASH-001",
                Description = "Comfortable running shoes.",
                Price = 14500m,
                Stock = 40,
                Status = ProductStatus.Active,
                CategoryId = categories["Fashion"],
                CreatedAt = now,
                UpdatedAt = now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Levi's 511 Jeans",
                SKU = "FASH-002",
                Description = "Slim fit denim jeans.",
                Price = 4200m,
                Stock = 35,
                Status = ProductStatus.Active,
                CategoryId = categories["Fashion"],
                CreatedAt = now,
                UpdatedAt = now
            },

            // Books
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Clean Code",
                SKU = "BOOK-001",
                Description = "Book by Robert C. Martin.",
                Price = 950m,
                Stock = 50,
                Status = ProductStatus.Active,
                CategoryId = categories["Books"],
                CreatedAt = now,
                UpdatedAt = now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "ASP.NET Core in Action",
                SKU = "BOOK-002",
                Description = "Comprehensive ASP.NET Core guide.",
                Price = 1800m,
                Stock = 30,
                Status = ProductStatus.Active,
                CategoryId = categories["Books"],
                CreatedAt = now,
                UpdatedAt = now
            },

            // Sports
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Adidas Football",
                SKU = "SPORT-001",
                Description = "FIFA standard football.",
                Price = 1800m,
                Stock = 25,
                Status = ProductStatus.Active,
                CategoryId = categories["Sports"],
                CreatedAt = now,
                UpdatedAt = now
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Yoga Mat",
                SKU = "SPORT-002",
                Description = "Non-slip exercise yoga mat.",
                Price = 1200m,
                Stock = 45,
                Status = ProductStatus.Active,
                CategoryId = categories["Sports"],
                CreatedAt = now,
                UpdatedAt = now
            }
        };

        await context.Products.AddRangeAsync(products);
        await context.SaveChangesAsync();
    }
}