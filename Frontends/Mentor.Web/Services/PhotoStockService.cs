using Mentor.Web.Models.PhotoStock;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class PhotoStockService : IPhotoStockService
    {
        public Task<PhotoViewModel> UploadPhoto(IFormFile photo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePhoto(string photoUrl)
        {
            throw new NotImplementedException();
        }
    }
}
