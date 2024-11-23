using DigitalOrder.Application.Features.User.Command.Models;
using IdentityEntity = DigitalOrder.Core.Entities.Identity;

namespace DigitalOrder.Application.Mapping.User
{
    public partial class UserProfile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, IdentityEntity.User>();
        }
    }
}
