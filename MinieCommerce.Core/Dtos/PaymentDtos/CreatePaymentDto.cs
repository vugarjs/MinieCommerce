using MinieCommerce.Core.Entities;
using MinieCommerce.Core.Enums.Roles;
using MinieCommerce.Core.Enums.Status;

namespace MinieCommerce.Core.Dtos.PaymentDtos;

internal class CreatePaymentDto
{
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public decimal Amount { get; set; }
    public PaymentMethod Method { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus Status { get; set; }
}
