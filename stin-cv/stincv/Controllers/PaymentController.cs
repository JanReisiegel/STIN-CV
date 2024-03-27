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
        public ActionResult<string> Hello()
        {
            return "Hello World";
        }

        [HttpGet("time")]
        public ActionResult<string> Time()
        {
            return DateTime.Now.ToString();
        }

        [HttpPost("pay/json")]
        public ActionResult<string> ProcessPayment([FromBody] PaymentVM paload)
        {
            try
            {
                var payment = PaymentTransformations.transformPaymentFromPaymentVM(paload);
                return _paymentProcessingHandler.ProcessPayment(payment);
            }
            catch(Exception e)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                return result;
            }
        }
        [HttpPost("pay/string")]
        public ActionResult<string> ProcessPayment([FromBody]string payload)
        {
            try
            {
                var payment = PaymentTransformations.transformPaymentFromString(payload);
                return _paymentProcessingHandler.ProcessPayment(payment);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
