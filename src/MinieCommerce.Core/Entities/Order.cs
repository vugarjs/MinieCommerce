using MinieCommerce.Core.Entities.Common;
using MinieCommerce.Core.Enums.Status;

namespace MinieCommerce.Core.Entities;

internal class Order : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
