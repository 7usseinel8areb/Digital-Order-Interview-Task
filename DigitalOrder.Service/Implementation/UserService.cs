using DigitalOrder.Core.Entities.Identity;
using DigitalOrder.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitalOrder.Service.Implementation
{
    internal class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> CheckSignInAsync(User user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }

        public async Task<string?> CheckUserConflictsAsync(string email, string userName, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.Users
                .Where(u => u.Email == email || u.UserName == userName)
                .Select(u => new { u.Email, u.UserName })
                .FirstOrDefaultAsync(cancellationToken);

            return existingUser switch
            {
                { Email: var e } when e == email => "Email already exists, please try with another one",
                { UserName: var u } when u == userName => "UserName already exists, please try with another one",
                _ => null
            };
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> EditAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User?> GetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<bool> IsUserExists(int id)
        {
            return await GetUserByIdAsync(id) != null;
        }

        public async Task<IdentityResult> UpdatePassword(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }
    }
}
