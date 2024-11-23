using DigitalOrder.Application.Bases;
using MediatR;

namespace DigitalOrder.Application.Features.User.Command.Models
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmNewPassword { get; set; }
    }
}
