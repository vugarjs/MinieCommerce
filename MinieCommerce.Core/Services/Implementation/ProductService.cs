using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinieCommerce.Core.Context;
using MinieCommerce.Core.Dtos.ProductDtos;
using MinieCommerce.Core.Entities;
using MinieCommerce.Core.Services.Interfaces;

namespace MinieCommerce.Core.Services.Implementation;

internal class ProductService : IProductService
{
    private readonly CommerceDb _commerce;
    private readonly IMapper _mapper;
    public ProductService(CommerceDb commerce, IMapper mapper)
    {
        _commerce = commerce;
        _mapper = mapper;
    }
    public async Task CreateAsync(ProductCreateDto dto)
    {
        var product = _mapper.Map<Product>(dto);
        await _commerce.Products.AddAsync(product);
        await _commerce.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _commerce.Products.FindAsync(id);
        if (product != null)
        {
            _commerce.Products.Remove(product);
            await _commerce.SaveChangesAsync();
        }
    }

    public async Task<List<ProductReturnDto>> GetAllAsync()
    {
        var products = await _commerce.Products.ToListAsync();
        return products.Select(p => _mapper.Map<ProductReturnDto>(p)).ToList();
    }


    public async Task<ProductReturnDto> GetByIdAsync(int id)
    {
        var product = _commerce.Products.Find(id);
        var result = _mapper.Map<ProductReturnDto>(product);
        return result;
    }

    public Task UpdateAsync(int id, ProdcutUpdateDto dto)
    {
        var product = _commerce.Products.Find(id);
        if (product != null)
        {
            _mapper.Map(dto, product);
            _commerce.Products.Update(product);
            return _commerce.SaveChangesAsync();
        }
        throw new Exception("Product not found");
    }

    public async Task UpdateStockAsync(int productId, int quantityChange)
    {
        var product = _commerce.Products.Find(productId);
        if (product != null)
        {
            product.StockQuantity += quantityChange;
            _commerce.Products.Update(product);
            await _commerce.SaveChangesAsync();
        }
    }
}
