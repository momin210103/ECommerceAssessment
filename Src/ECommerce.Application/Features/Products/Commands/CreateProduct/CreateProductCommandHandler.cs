using AutoMapper;
using ECommerce.Application.Features.Products.DTOs;
using ECommerce.Application.Features.Products.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductResponse> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        var exists = await _repository.GetByNameAsync(request.Name);

        if (exists is not null)
            throw new Exception("Product already exists.");

        var categoryExists = await _repository.CategoryExistsAsync(request.CategoryId);

        if (!categoryExists)
            throw new Exception("Category not found.");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.StockQuantity,
            CategoryId = request.CategoryId
        };

        await _repository.AddAsync(product);
        await _repository.SaveChangesAsync();

        product = await _repository.GetByIdAsync(product.Id);

        return _mapper.Map<ProductResponse>(product);
    }
}