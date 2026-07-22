using AutoMapper;
using ECommerce.Application.Features.Orders.Interfaces;
using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Application.Features.Payments.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Payments.Commands.CreatePayment;

public class CreatePaymentCommandHandler
    : IRequestHandler<CreatePaymentCommand, PaymentResponse>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public CreatePaymentCommandHandler(
        IPaymentRepository paymentRepository,
        IOrderRepository orderRepository,
        IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<PaymentResponse> Handle(
        CreatePaymentCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);

        if (order is null)
            throw new KeyNotFoundException("Order not found.");

        var existingPayment = await _paymentRepository.GetByOrderIdAsync(request.OrderId);

        if (existingPayment is not null)
            throw new InvalidOperationException("Payment already exists for this order.");

        var payment = new Payment
        {
            OrderId = order.Id,
            Provider = request.Provider,
            Status = PaymentStatus.Pending,
            Amount = order.TotalAmount,
            TransactionId = Guid.NewGuid().ToString("N"),
            PaidAt = null
        };

        await _paymentRepository.AddAsync(payment);
        await _paymentRepository.SaveChangesAsync();

        payment = await _paymentRepository.GetByIdAsync(payment.Id)
                  ?? throw new Exception("Failed to retrieve payment.");

        return _mapper.Map<PaymentResponse>(payment);
    }
}