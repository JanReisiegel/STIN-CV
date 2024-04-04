using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stincv.Models;
using stincv.Services;
using stincv.ViewModels;

namespace stincv.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly PaymentProcessingHandler _paymentProcessingHandler;

        public PaymentController()
        {
            _paymentProcessingHandler = new PaymentProcessingHandler();
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello World");
        }

        [HttpGet("time")]
        public IActionResult Time()
        {
            return Ok(DateTime.Now.ToString());
        }

        [HttpPost("pay/string")]
        public IActionResult ProcessPayment([FromBody]string payload)
        {
            try
            {
                var payment = PaymentTransformations.transformPaymentFromString(payload);
                return Ok(_paymentProcessingHandler.ProcessPayment(payment));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status418ImATeapot, e.Message);
            }
        }
    }
}
