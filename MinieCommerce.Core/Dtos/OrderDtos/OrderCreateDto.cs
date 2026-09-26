using MinieCommerce.Core.Entities;
using MinieCommerce.Core.Enums.Status;

namespace MinieCommerce.Core.Dtos.OrderDtos;

internal class OrderCreateDto
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
}
