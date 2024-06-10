using Resellio.Web.Models.PhotoStock;

namespace Resellio.Web.Services.Interfaces
{
    public interface IPhotoStockService
    {
        public Task<PhotoViewModel> UploadPhoto(IFormFile photo);
        public Task<bool> DeletePhoto(string photoUrl);
    }
}
