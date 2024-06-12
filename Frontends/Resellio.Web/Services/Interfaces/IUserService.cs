using Resellio.Web.Models;

namespace Resellio.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Signup(SignupInput signupInput);
        Task<UserViewModel> GetUser();
    }
}
