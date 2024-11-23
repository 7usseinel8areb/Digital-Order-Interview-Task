using DigitalOrder.Application.Bases;
using DigitalOrder.Application.Features.User.Query.Results;
using MediatR;

namespace DigitalOrder.Application.Features.User.Query.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserResult>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
