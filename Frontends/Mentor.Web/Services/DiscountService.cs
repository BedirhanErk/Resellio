using Mentor.Web.Models.Discount;
using Mentor.Web.Services.Interfaces;

namespace Mentor.Web.Services
{
    public class DiscountService : IDiscountService
    {
        public Task<DiscountViewModel> GetDiscount(string discountCode)
        {
            throw new NotImplementedException();
        }
    }
}
