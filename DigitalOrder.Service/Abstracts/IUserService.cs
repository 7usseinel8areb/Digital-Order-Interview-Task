using DigitalOrder.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace DigitalOrder.Service.Abstracts
{
    public interface IUserService
    {
        Task<bool> IsUserExists(int id);

        Task<string?> CheckUserConflictsAsync(string email, string userName, CancellationToken cancellationToken);

        Task<IdentityResult> CreateUserAsync(User user, string password);

        Task<User?> GetUserByIdAsync(int id);

        Task<User?> GetUserByNameAsync(string userName);

        Task<IdentityResult> EditAsync(User user);

        Task<IdentityResult> DeleteUserAsync(User user);

        Task<IdentityResult> UpdatePassword(User user, string currentPassword, string newPassword);

        Task<SignInResult> CheckSignInAsync(User user, string password);
    }
}
