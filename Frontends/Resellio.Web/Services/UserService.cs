using Resellio.Web.Helpers;
using Resellio.Web.Models;
using Resellio.Web.Services.Interfaces;

namespace Resellio.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _signUpClient;
        private readonly HttpClient _userClient;
        private readonly IPhotoStockService _photoStockService;
        private readonly PhotoHelper _photoHelper;

        public UserService(IHttpClientFactory httpClientFactory, IPhotoStockService photoStockService, PhotoHelper photoHelper)
        {
            _signUpClient = httpClientFactory.CreateClient("SignupClient");
            _userClient = httpClientFactory.CreateClient("UserClient");
            _photoStockService = photoStockService;
            _photoHelper = photoHelper;
        }

        public async Task<bool> Signup(SignupInput signupInput)
        {
            var response = await _signUpClient.PostAsJsonAsync("/api/user/signup", signupInput);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }

        public async Task<UserUpdateInput> GetUser()
        {
            var user = await _userClient.GetFromJsonAsync<UserUpdateInput>("/api/user/getuser");

            user.PictureUrl = _photoHelper.GetPhotoUrl(user.Picture);

            return user;
        }

        public async Task<bool> UpdateUser(UserUpdateInput userUpdateInput)
        {
            var resultPhoto = await _photoStockService.UploadPhoto(userUpdateInput.PhotoFormFile);

            if (resultPhoto != null)
            {
                await _photoStockService.DeletePhoto(userUpdateInput.Picture);
                userUpdateInput.Picture = resultPhoto.Url;
            }

            var response = await _userClient.PostAsJsonAsync("/api/user/updateuser", userUpdateInput);

            return response.IsSuccessStatusCode;
        }
    }
}
