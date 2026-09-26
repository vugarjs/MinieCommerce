namespace MinieCommerce.Core.Dtos.ProductDtos;

internal class ProdcutUpdateDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
}
