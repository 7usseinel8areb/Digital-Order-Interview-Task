using DigitalOrder.Application.Bases;
using MediatR;

namespace DigitalOrder.Application.Features.Authentication.Command.Models
{
    public class SignInCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
