using Mentor.Services.Payment.Models;
using Mentor.Shared.ControllerBases;
using Mentor.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Mentor.Services.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : CustomBaseController
    {
        [HttpPost]
        public IActionResult ReceivePayment(PaymentInfo payment)
        {
            return CreateActionResultInstance(Response<NoContent>.Success(200));
        }
    }
}
