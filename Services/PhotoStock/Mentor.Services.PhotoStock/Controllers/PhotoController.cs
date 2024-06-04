using Mentor.Services.PhotoStock.Dtos;
using Mentor.Shared.ControllerBases;
using Mentor.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                await photo.CopyToAsync(stream, cancellationToken);

                PhotoDto photoDto = new() { Url = photo.FileName };

                return CreateActionResultInstance(Response<PhotoDto>.Success(photoDto, 200));
            }

            return CreateActionResultInstance(Response<PhotoDto>.Fail("Photo is empty", 400));
        }

        [HttpDelete]
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);

            if (!System.IO.File.Exists(path))
                return CreateActionResultInstance(Response<NoContent>.Fail("Photo not found", 404));

            System.IO.File.Delete(path);

            return CreateActionResultInstance(Response<NoContent>.Success(204));
        }
    }
}
