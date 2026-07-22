using AutoMapper;
using ECommerce.Application.Common.Exceptions;
using ECommerce.Application.Features.Categories.DTOs;
using ECommerce.Application.Features.Categories.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler
    : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(
        ICategoryRepository categoryRepository,
        IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryResponse> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var existingCategory =
            await _categoryRepository.GetByNameAsync(request.Name);

        if (existingCategory is not null)
            throw new ConflictException("Category already exists.");

        var category = new Category
        {
            Name = request.Name,
            Description = request.Description,
            ParentCategoryId = request.ParentCategoryId
        };

        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();

        return _mapper.Map<CategoryResponse>(category);
    }
}