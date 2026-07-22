using AutoMapper;
using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Application.Features.Payments.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetAllPayments;

public class GetAllPaymentsQueryHandler
    : IRequestHandler<GetAllPaymentsQuery, List<PaymentResponse>>
{
    private readonly IPaymentRepository _repository;
    private readonly IMapper _mapper;

    public GetAllPaymentsQueryHandler(
        IPaymentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<PaymentResponse>> Handle(
        GetAllPaymentsQuery request,
        CancellationToken cancellationToken)
    {
        var payments = await _repository.GetAllAsync();

        return _mapper.Map<List<PaymentResponse>>(payments);
    }
}