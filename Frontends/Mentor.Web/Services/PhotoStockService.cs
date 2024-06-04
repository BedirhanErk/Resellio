using Mentor.Web.Models.PhotoStock;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class PhotoStockService : IPhotoStockService
    {
        private readonly HttpClient _httpClient;

        public PhotoStockService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PhotoViewModel> UploadPhoto(IFormFile photo)
        {
            if (photo == null || photo.Length <= 0)
                return null;

            var randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName); 

            using var ms = new MemoryStream();
            await photo.CopyToAsync(ms);

            var multipartContent = new MultipartFormDataContent();
            multipartContent.Add(new ByteArrayContent(ms.ToArray()), "photo", randomFileName);

            var response = await _httpClient.PostAsync("photo", multipartContent);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseSuccess = await response.Content.ReadFromJsonAsync<PhotoViewModel>();

            return responseSuccess;
        }

        public async Task<bool> DeletePhoto(string photoUrl)
        {
            var response = await _httpClient.DeleteAsync($"photo?photoUrl={photoUrl}");

            return response.IsSuccessStatusCode;
        }
    }
}
