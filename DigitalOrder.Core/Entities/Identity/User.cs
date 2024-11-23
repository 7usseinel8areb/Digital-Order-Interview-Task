using Microsoft.AspNetCore.Identity;

namespace DigitalOrder.Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
