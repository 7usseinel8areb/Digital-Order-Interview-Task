using DigitalOrder.Application.Features.User.Query.Results;
using IdentityEntity = DigitalOrder.Core.Entities.Identity;

namespace DigitalOrder.Application.Mapping.User
{
    public partial class UserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<IdentityEntity.User, GetUserResult>();
        }
    }
}
