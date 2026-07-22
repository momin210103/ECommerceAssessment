using ECommerce.Application.Features.Orders.Commands.CreateOrder;
using ECommerce.Application.Features.Orders.Commands.DeleteOrder;
using ECommerce.Application.Features.Orders.Commands.UpdateOrderStatus;
using ECommerce.Application.Features.Orders.DTOs;
using ECommerce.Application.Features.Orders.Queries.GetAllOrders;
using ECommerce.Application.Features.Orders.Queries.GetOrderById;
using ECommerce.Application.Features.Payments.Commands.CreatePayment;
using ECommerce.Application.Features.Payments.Commands.UpdatePaymentStatus;
using ECommerce.Application.Features.Payments.DTOs;
using ECommerce.Application.Features.Payments.Queries.GetAllPayments;
using ECommerce.Application.Features.Payments.Queries.GetPaymentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePaymentRequest request)
    {
        var command = new CreatePaymentCommand
        {
            OrderId = request.OrderId,
            Provider = request.Provider
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPaymentsQuery());

        return Ok(result);
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetPaymentByIdQuery(id));

        if (result is null)
            return NotFound();

        return Ok(result);
    }
    [HttpPut("{id:guid}/status")]
    public async Task<IActionResult> UpdateStatus(
        Guid id,
        [FromBody] UpdatePaymentStatusRequest request)
    {
        var command = new UpdatePaymentStatusCommand
        {
            Id = id,
            Status = request.Status,
            TransactionId = request.TransactionId
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}