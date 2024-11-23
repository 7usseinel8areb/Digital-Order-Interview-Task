using DigitalOrder.Application.Bases;
using MediatR;

namespace DigitalOrder.Application.Features.Product.Command.Models
{
    public class DeleteProductCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
