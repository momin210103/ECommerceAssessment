using AutoMapper;
using ECommerce.Application.Features.Categories.DTOs;
using ECommerce.Application.Features.Categories.Interfaces;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler
    : IRequestHandler<UpdateCategoryCommand, CategoryResponse>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(
        ICategoryRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CategoryResponse> Handle(
        UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var category = await _repository.GetByIdAsync(request.Id);

        if (category is null)
            throw new KeyNotFoundException("Category not found.");

        var duplicate = await _repository.GetByNameAsync(request.Name);

        if (duplicate is not null && duplicate.Id != request.Id)
            throw new Exception("Category name already exists.");

        category.Name = request.Name;
        category.Description = request.Description;

        await _repository.UpdateAsync(category);
        await _repository.SaveChangesAsync();

        return _mapper.Map<CategoryResponse>(category);
    }
}