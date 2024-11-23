using DigitalOrder.API.Base;
using DigitalOrder.Application.Features.User.Command.Models;
using DigitalOrder.Application.Features.User.Query.Models;
using DigitalOrder.Core.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOrder.API.Controllers
{
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        [HttpGet(Router.UserRoutes.GetById)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery(id));
            return NewResult(response);
        }

        [HttpDelete(Router.UserRoutes.Delete)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));
            return NewResult(response);
        }

        [HttpPut(Router.UserRoutes.Edit)]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);
            return NewResult(response);
        }

        [HttpPut(Router.UserRoutes.ChangePassword)]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);
            return NewResult(response);
        }
    }
}
