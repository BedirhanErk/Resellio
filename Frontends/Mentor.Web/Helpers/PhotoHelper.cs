using Mentor.Web.Models;
using Microsoft.Extensions.Options;

namespace Mentor.Web.Helpers
{
    public class PhotoHelper
    {
        private readonly ServiceApiSettings _serviceApiSettings;

        public PhotoHelper(IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public string GetPhotoUrl(string photoUrl)
        {
            return $"{_serviceApiSettings.PhotoStockUri}/photos/{photoUrl}";
        }
    }
}
