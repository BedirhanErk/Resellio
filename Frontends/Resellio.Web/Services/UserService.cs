using Resellio.Web.Models;
using Resellio.Web.Services.Interfaces;

namespace Resellio.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _signUpClient;
        private readonly HttpClient _userClient;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _signUpClient = httpClientFactory.CreateClient("SignupClient");
            _userClient = httpClientFactory.CreateClient("UserClient");
        }

        public async Task<bool> Signup(SignupInput signupInput)
        {
            var response = await _signUpClient.PostAsJsonAsync("/api/user/signup", signupInput);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }

        public async Task<UserViewModel> GetUser()
        {
            return await _userClient.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
        }
    }
}
