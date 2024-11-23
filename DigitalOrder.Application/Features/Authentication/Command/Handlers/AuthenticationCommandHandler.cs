using DigitalOrder.Application.Bases;
using DigitalOrder.Application.Features.Authentication.Command.Models;
using DigitalOrder.Service.Abstracts;
using MediatR;

namespace DigitalOrder.Application.Features.Authentication.Command.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler
        , IRequestHandler<SignInCommand, Response<string>>
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthenticationCommandHandler(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByNameAsync(request.UserName);
            string failureMessage = @"InCorrect username or password!";

            if (user is null)
                return BadRequest<string>(failureMessage);

            var canSignIn = await _userService.CheckSignInAsync(user, request.Password);

            if (!canSignIn.Succeeded)
                return BadRequest<string>(failureMessage);

            var accessToken = await _tokenService.GetJWTTokent(user);

            return Success(accessToken);
        }
    }
}
