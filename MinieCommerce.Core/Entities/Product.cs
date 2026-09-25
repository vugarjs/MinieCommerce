using MinieCommerce.Core.Entities.Common;

namespace MinieCommerce.Core.Entities;

internal class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }

}
