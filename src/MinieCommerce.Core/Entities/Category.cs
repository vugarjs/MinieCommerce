using MinieCommerce.Core.Entities.Common;

namespace MinieCommerce.Core.Entities;

internal class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    // public ICollection<Product> Products { get; set; } = new List<Product>();
}
