using AutoMapper;
using ECommerce.Application.Features.Products.DTOs;
using ECommerce.Application.Features.Products.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand, ProductResponse>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductResponse> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            throw new Exception("Product not found.");

        var categoryExists = await _repository.CategoryExistsAsync(request.CategoryId);

        if (!categoryExists)
            throw new Exception("Category not found.");

        var duplicate = await _repository.GetByNameAsync(request.Name);

        if (duplicate is not null && duplicate.Id != request.Id)
            throw new Exception("Product name already exists.");

        product.Name = request.Name;
        product.SKU = request.SKU;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Stock = request.Stock;
        product.Status = request.Status;
        product.CategoryId = request.CategoryId;

        await _repository.UpdateAsync(product);
        await _repository.SaveChangesAsync();

        product = await _repository.GetByIdAsync(product.Id);

        return _mapper.Map<ProductResponse>(product);
    }
}