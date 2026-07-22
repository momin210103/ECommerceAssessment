using AutoMapper;
using ECommerce.Application.Features.Categories.DTOs;
using ECommerce.Application.Features.Categories.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse?>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(
        ICategoryRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryResponse?> Handle(
        GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
            return null;

        return _mapper.Map<CategoryResponse>(category);
    }
    
}