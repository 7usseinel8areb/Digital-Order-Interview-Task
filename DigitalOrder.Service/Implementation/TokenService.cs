using DigitalOrder.Core.Entities.Identity;
using DigitalOrder.Core.Helper;
using DigitalOrder.Service.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalOrder.Service.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;
        public TokenService(IConfiguration configuration, JwtSettings jwtSettings)
        {
            _configuration = configuration;
            _jwtSettings = jwtSettings;
        }

        public Task<string> GetJWTTokent(User user)
        {

            var audience = _jwtSettings.Audience;
            var issuer = _jwtSettings.Issuer;
            var secretKey = _jwtSettings.SecretKey;

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>()
            {
                new(nameof(UserClaimModel.UserName),user.UserName),
                new(nameof(UserClaimModel.Email),user.Email),
                new(nameof(UserClaimModel.PhoneNumber),user.PhoneNumber)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Task.FromResult(accessToken);
        }
    }
}
