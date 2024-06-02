using System.ComponentModel.DataAnnotations;

namespace Mentor.Web.Models
{
    public class SignInInput
    {
        [Display(Name = "Email")]
        public string Email { get; set; }   

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool IsRemember { get; set; }
    }
}
