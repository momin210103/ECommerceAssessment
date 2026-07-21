using System.ComponentModel.DataAnnotations;
using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public class Category : BaseEntity
{
    public Guid? ParentCategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Self Reference
    public Category? ParentCategory { get; set; }

    public ICollection<Category> Children { get; set; } = new List<Category>();

    // One Category -> Many Products
    public ICollection<Product> Products { get; set; } = new List<Product>();
    
}