using MinieCommerce.Core.Dtos.PaymentDtos;

namespace MinieCommerce.Core.Services.Interfaces;

internal interface IPaymentService
{
    Task<PaymentReturnDto> GetPaymentByOrderIdAsync(int orderId);
    Task<bool> ProcessPaymentAsync(CreatePaymentDto dto);

}
