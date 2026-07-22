using AutoMapper;
using ECommerce.Application.Features.Orders.DTOs;
using ECommerce.Application.Features.Orders.Interfaces;
using ECommerce.Application.Features.Products.Interfaces;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Enums;
using MediatR;

namespace ECommerce.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler
    : IRequestHandler<CreateOrderCommand, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<OrderResponse> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        var productIds = request.Items
            .Select(x => x.ProductId)
            .ToList();

        var products = await _productRepository
            .GetProductsByIdsAsync(productIds);

        if (products.Count != productIds.Count)
            throw new Exception("One or more products were not found.");

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            OrderNumber = await _orderRepository.GenerateOrderNumberAsync(),
            Status = OrderStatus.Pending,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        decimal totalAmount = 0;

        foreach (var item in request.Items)
        {
            var product = products.First(x => x.Id == item.ProductId);

            if (product.Stock < item.Quantity)
                throw new Exception($"{product.Name} is out of stock.");

            product.Stock -= item.Quantity;
            await _productRepository.UpdateAsync(product);

            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Quantity = item.Quantity,
                UnitPrice = product.Price,
                TotalPrice = product.Price * item.Quantity,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            totalAmount += orderItem.TotalPrice;

            order.OrderItems.Add(orderItem);
        }

        order.TotalAmount = totalAmount;

        await _orderRepository.AddAsync(order);

        await _orderRepository.SaveChangesAsync();

        var createdOrder = await _orderRepository.GetByIdAsync(order.Id);

        return _mapper.Map<OrderResponse>(createdOrder);
    }
}