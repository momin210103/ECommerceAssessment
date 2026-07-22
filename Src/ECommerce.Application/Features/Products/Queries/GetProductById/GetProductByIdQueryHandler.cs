using AutoMapper;
using ECommerce.Application.Features.Products.DTOs;
using ECommerce.Application.Features.Products.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, ProductResponse?>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductResponse?> Handle(
        GetProductByIdQuery request,
        CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product is null)
            return null;

        return _mapper.Map<ProductResponse>(product);
    }
}