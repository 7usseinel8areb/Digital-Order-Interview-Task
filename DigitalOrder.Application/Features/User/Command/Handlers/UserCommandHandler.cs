using AutoMapper;
using DigitalOrder.Application.Bases;
using DigitalOrder.Application.Features.User.Command.Models;
using DigitalOrder.Service.Abstracts;
using MediatR;
using IdentityEntities = DigitalOrder.Core.Entities.Identity;

namespace DigitalOrder.Application.Features.User.Command.Handlers
{
    public class UserCommandHandler : ResponseHandler
        , IRequestHandler<AddUserCommand, Response<string>>
        , IRequestHandler<UpdateUserCommand, Response<string>>
        , IRequestHandler<DeleteUserCommand, Response<string>>
        , IRequestHandler<ChangePasswordCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // Check if email or username already exists
            string? userConflictMessage = await _userService.CheckUserConflictsAsync(request.Email, request.UserName, cancellationToken);

            if (userConflictMessage != null)
                return BadRequest<string>(userConflictMessage);

            var userMapper = _mapper.Map<IdentityEntities.User>(request);

            //Create the user
            var userCreateResult = await _userService.CreateUserAsync(userMapper, request.Password);

            return userCreateResult.Succeeded ? Created<string>("User was created successfully")
                : BadRequest<string>(string.Join(", ", userCreateResult.Errors.Select(e => e.Description))); ;
        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            int userId = request.Id;

            //Chek if user exists
            var user = await _userService.GetUserByIdAsync(userId);

            if (user is null)
                return NotFound<string>($"The user with Id: {userId} was not found to be updated");

            var userMapper = _mapper.Map(request, user);

            var result = await _userService.EditAsync(userMapper);

            return result.Succeeded ? Success("User was updates successfully") : BadRequest<string>("Update field");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            int userId = request.Id;

            var user = await _userService.GetUserByIdAsync(userId);

            if (user is null)
                return NotFound<string>($"The user with Id: {userId} was not found to be deleted");

            var result = await _userService.DeleteUserAsync(user);

            return result.Succeeded ? Delete<string>($"The user with id: {userId} was deleted successfully") : BadRequest<string>("Delete field");
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var userId = request.Id;

            var user = await _userService.GetUserByIdAsync(userId);

            if (user is null)
                return NotFound<string>($"The user with Id: {userId} was not found to change the password");

            var result = await _userService.UpdatePassword(user, request.CurrentPassword, request.NewPassword);

            return result.Succeeded ? Delete<string>($"The user with id: {userId} password changed successfully") : BadRequest<string>("Change password field");

        }
    }
}
