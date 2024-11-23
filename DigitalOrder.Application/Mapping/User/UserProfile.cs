using AutoMapper;

namespace DigitalOrder.Application.Mapping.User
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapping();
            GetUserByIdMapping();
            UpdateUserMapping();
        }
    }
}
