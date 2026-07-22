using AutoMapper;
using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Application.Features.Payments.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetPaymentById;

public class GetPaymentByIdQueryHandler
    : IRequestHandler<GetPaymentByIdQuery, PaymentResponse?>
{
    private readonly IPaymentRepository _repository;
    private readonly IMapper _mapper;

    public GetPaymentByIdQueryHandler(
        IPaymentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaymentResponse?> Handle(
        GetPaymentByIdQuery request,
        CancellationToken cancellationToken)
    {
        var payment = await _repository.GetByIdAsync(request.Id);

        if (payment is null)
            return null;

        return _mapper.Map<PaymentResponse>(payment);
    }
}