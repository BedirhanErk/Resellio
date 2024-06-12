using IdentityModel.Client;
using Resellio.Shared.Dtos;
using Resellio.Web.Models;

namespace Resellio.Web.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> Login(LoginInput loginInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
