using AutoMapper;
using ECommerce.Application.Features.Products.DTOs;
using ECommerce.Application.Features.Products.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryHandler
    : IRequestHandler<GetAllProductsQuery, List<ProductResponse>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductResponse>> Handle(
        GetAllProductsQuery request,
        CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();

        return _mapper.Map<List<ProductResponse>>(products);
    }
}