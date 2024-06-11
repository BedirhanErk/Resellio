using Microsoft.AspNetCore.Identity;

namespace Resellio.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }
    }
}
