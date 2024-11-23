using DigitalOrder.Core.Entities.Identity;

namespace DigitalOrder.Service.Abstracts
{
    public interface ITokenService
    {
        Task<string> GetJWTTokent(User user);
    }
}
