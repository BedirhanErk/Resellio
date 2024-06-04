using Mentor.Web.Models.PhotoStock;

namespace Mentor.Web.Services.Interfaces
{
    public interface IPhotoStockService
    {
        public Task<PhotoViewModel> UploadPhoto(IFormFile photo);
        public Task<bool> DeletePhoto(string photoUrl);
    }
}
