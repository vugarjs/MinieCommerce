using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinieCommerce.Core.Context;
using MinieCommerce.Core.Dtos.OrderDtos;
using MinieCommerce.Core.Enums.Status;
using MinieCommerce.Core.Services.Interfaces;

namespace MinieCommerce.Core.Services.Implementation;

internal class OrderService : IOrderService
{
    private readonly IMapper _mapper;
    private readonly CommerceDb _commerce;
    public OrderService(IMapper mapper, CommerceDb commerce)
    {
        _mapper = mapper;
        _commerce = commerce;
    }
    public async Task CancelOrderAsync(int orderId)
    {
        var order = await _commerce.Orders.FindAsync(orderId);
        //    
        if (order is null)
            throw new Exception("Order not found.");

        order.Status = OrderStatus.Cancelled;

        await _commerce.SaveChangesAsync();
    }
    public async Task CreateOrderAsync(OrderCreateDto dto)
    {
        var order = _mapper.Map<Entities.Order>(dto);
        if (order is not null)
        {
            await _commerce.Orders.AddAsync(order);
            await _commerce.SaveChangesAsync();
        }
        else
        {
            throw new Exception("order is not right.");
        }
    }

    public async Task<OrderReturnDto> GetOrderDetailsAsync(int orderId)
    {
        var order = await _commerce.Orders.AsNoTracking().SingleOrDefaultAsync(o => o.Id == orderId);

        var ordermap = _mapper.Map<OrderReturnDto>(order);

        if (ordermap is null)
            throw new Exception("Order not found.");

        return ordermap;
    }

    public async Task<List<OrderReturnDto>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await _commerce.Orders.AsNoTracking().Where(o => o.UserId == userId).ToListAsync();
        return orders.Select(o => _mapper.Map<OrderReturnDto>(o)).ToList();
    }

    public async Task UpdateOrderStatusAsync(int orderId, OrderStatus status)
    {
        var order = await _commerce.Orders.FindAsync(orderId);

        if (order is null)
            throw new Exception("Order not found.");

        order.Status = status;

        await _commerce.SaveChangesAsync();
    }
}
