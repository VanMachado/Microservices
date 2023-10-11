using Microsoft.AspNetCore.Identity;

namespace GeekShooping.IdentityServer.Infra
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
