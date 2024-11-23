using DigitalOrder.Application.Bases;
using DigitalOrder.Application.Features.Product.Query.Results;
using MediatR;

namespace DigitalOrder.Application.Features.Product.Query.Models
{
    public class GetProductByIdQuery : IRequest<Response<GetSingleProductResponse>>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
