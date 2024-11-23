using DigitalOrder.Application.Bases;
using DigitalOrder.Application.Features.Product.Query.Results;
using MediatR;

namespace DigitalOrder.Application.Features.Product.Query.Models
{
    public class GetAllProductsQuery : IRequest<Response<List<GetSingleProductResponse>>>
    {

    }
}
