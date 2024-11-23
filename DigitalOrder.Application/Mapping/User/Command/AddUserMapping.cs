using DigitalOrder.Application.Features.User.Command.Models;
using IdentityUser = DigitalOrder.Core.Entities.Identity;

namespace DigitalOrder.Application.Mapping.User
{
    public partial class UserProfile
    {
        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, IdentityUser.User>();
            //.ForMember(dest => dest.,opt => opt.MapFrom( src => src.))
        }
    }
}
