using IdentityModel.Client;
using Resellio.Shared.Dtos;
using Resellio.Web.Models;

namespace Resellio.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
