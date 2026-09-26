using MinieCommerce.Core.Dtos.ProductDtos;

namespace MinieCommerce.Core.Services.Interfaces;

internal interface IProductService
{
    Task<ProductReturnDto> GetByIdAsync(int id);
    Task<List<ProductReturnDto>> GetAllAsync();
    Task CreateAsync(ProductCreateDto dto);
    Task UpdateAsync(int id, ProdcutUpdateDto dto);
    Task DeleteAsync(int id);
    Task UpdateStockAsync(int productId, int quantityChange);
}
