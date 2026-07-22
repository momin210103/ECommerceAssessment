using ECommerce.Application.Features.Products.DTOs;
using MediatR;

namespace ECommerce.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<List<ProductResponse>>
{
}