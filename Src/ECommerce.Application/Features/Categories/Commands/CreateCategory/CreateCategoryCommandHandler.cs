using AutoMapper;
using ECommerce.Application.Features.Categories.DTOs;
using ECommerce.Application.Features.Categories.Interfaces;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
    private readonly ICategoryRepository _repository;
    private readonly IMapper _mapper;
    public CreateCategoryCommandHandler(
        ICategoryRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var exists = await _repository.GetByNameAsync(request.Name);

        if (exists != null)
            throw new Exception("Category already exists.");

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        await _repository.AddAsync(category);
        await _repository.SaveChangesAsync();

        return _mapper.Map<CategoryResponse>(category);
    }
}