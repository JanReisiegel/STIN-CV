using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stin_cv.Services;
using StinCVProject.Models;

namespace StinCVProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private PaymentProcessingHandler paymentServiceProcessing;

        public PaymentController(PaymentProcessingHandler paymentServiceProcessing)
        {
            this.paymentServiceProcessing = paymentServiceProcessing;
        }

        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello world from PaymentController");
        }

        [HttpGet("time")]
        public IActionResult Time()
        {
            return Ok(DateTime.Now);
        }

        [HttpPost("pay")]
        public IActionResult Pay([FromBody] Payment payment)
        {
            try
            {
                return Ok(paymentServiceProcessing.ProcessPayment(payment));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
    
}
