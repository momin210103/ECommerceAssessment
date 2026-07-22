using ECommerce.Application.Features.Payments.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Payments.Queries.GetAllPayments;

public class GetAllPaymentsQuery : IRequest<List<PaymentResponse>>
{
}