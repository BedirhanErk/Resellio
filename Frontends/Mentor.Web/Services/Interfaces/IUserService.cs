using Resellio.Web.Models;

namespace Resellio.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
