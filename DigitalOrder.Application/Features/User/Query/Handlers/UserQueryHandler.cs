using AutoMapper;
using DigitalOrder.Application.Bases;
using DigitalOrder.Application.Features.User.Query.Models;
using DigitalOrder.Application.Features.User.Query.Results;
using DigitalOrder.Service.Abstracts;
using MediatR;

namespace DigitalOrder.Application.Features.User.Query.Handlers
{
    public class UserQueryHandler : ResponseHandler
        , IRequestHandler<GetUserByIdQuery, Response<GetUserResult>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<Response<GetUserResult>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            int userId = request.Id;
            var user = await _userService.GetUserByIdAsync(userId);

            if (user is null)
                return NotFound<GetUserResult>($"The user with Id: {userId} was not found");

            var userMapper = _mapper.Map<GetUserResult>(user);

            return Success(userMapper);
        }
    }
}
