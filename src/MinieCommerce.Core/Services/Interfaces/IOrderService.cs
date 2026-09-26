using MinieCommerce.Core.Dtos.OrderDtos;
using MinieCommerce.Core.Enums.Status;

namespace MinieCommerce.Core.Services.Interfaces;

internal interface IOrderService
{
    Task<OrderReturnDto> GetOrderDetailsAsync(int orderId);
    Task<List<OrderReturnDto>> GetOrdersByUserIdAsync(int userId);
    Task CreateOrderAsync(OrderCreateDto dto);
    Task UpdateOrderStatusAsync(int orderId, OrderStatus status);
    Task CancelOrderAsync(int orderId);
}
