using AutoMapper;
using MinieCommerce.Core.Dtos.OrderDtos;
using MinieCommerce.Core.Dtos.PaymentDtos;
using MinieCommerce.Core.Dtos.ProductDtos;
using MinieCommerce.Core.Entities;

namespace MinieCommerce.Core.Mappers;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductReturnDto>();
        CreateMap<ProductCreateDto, Product>();

        CreateMap<ProductCreateDto, ProductReturnDto>();

        CreateMap<Order, OrderReturnDto>();
        CreateMap<OrderCreateDto, Order>();

        CreateMap<Order, OrderUpdateDto>();
        CreateMap<OrderUpdateDto, Order>();

        CreateMap<Payment, PaymentReturnDto>();
        CreateMap<CreatePaymentDto, PaymentReturnDto>();
    }
}
