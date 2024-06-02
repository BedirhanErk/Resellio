using IdentityModel.Client;
using Mentor.Shared.Dtos;
using Mentor.Web.Models;

namespace Mentor.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
