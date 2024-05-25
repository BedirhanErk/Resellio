using Microsoft.AspNetCore.Identity;

namespace Mentor.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
