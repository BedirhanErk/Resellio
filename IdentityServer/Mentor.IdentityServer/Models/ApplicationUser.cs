using Microsoft.AspNetCore.Identity;

namespace Resellio.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
