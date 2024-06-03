using Mentor.Web.Models;

namespace Mentor.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
