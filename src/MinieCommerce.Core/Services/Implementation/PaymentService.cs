using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinieCommerce.Core.Context;
using MinieCommerce.Core.Dtos.PaymentDtos;
using MinieCommerce.Core.Entities;
using MinieCommerce.Core.Services.Interfaces;

namespace MinieCommerce.Core.Services.Implementation;

internal class PaymentService : IPaymentService
{
    private readonly IMapper _mapper;
    private readonly CommerceDb _commerceDb;

    public PaymentService(IMapper mapper, CommerceDb commerceDb)
    {
        _mapper = mapper;
        _commerceDb = commerceDb;
    }
    public async Task<PaymentReturnDto> GetPaymentByOrderIdAsync(int orderId)
    {
        var find = await _commerceDb.Payments
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.OrderId == orderId);

        if (find == null)
        {
            throw new Exception($"Payment with OrderId {orderId} not found.");
        }

        var paymentReturnDto = _mapper.Map<PaymentReturnDto>(find);
        return paymentReturnDto;
    }

    public async Task<bool> ProcessPaymentAsync(CreatePaymentDto dto)
    {
        var payment = _mapper.Map<Payment>(dto);
        _commerceDb.Payments.Add(payment);
        await _commerceDb.SaveChangesAsync();
        return true;
    }
}
