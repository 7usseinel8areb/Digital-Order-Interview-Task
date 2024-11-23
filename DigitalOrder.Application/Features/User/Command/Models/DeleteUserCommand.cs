using DigitalOrder.Application.Bases;
using MediatR;

namespace DigitalOrder.Application.Features.User.Command.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
