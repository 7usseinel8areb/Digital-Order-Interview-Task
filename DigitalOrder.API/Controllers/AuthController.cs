using DigitalOrder.API.Base;
using DigitalOrder.Application.Features.Authentication.Command.Models;
using DigitalOrder.Application.Features.User.Command.Models;
using DigitalOrder.Core.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace DigitalOrder.API.Controllers
{
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost(Router.AuthRoutes.Register)]
        public async Task<IActionResult> Register(AddUserCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);
            return NewResult(response);
        }

        [HttpPost(Router.AuthRoutes.SignIn)]
        public async Task<IActionResult> SignInUser(SignInCommand signInCommand)
        {
            var response = await _mediator.Send(signInCommand);
            return NewResult(response);
        }
    }
}
