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
            if (payment.PaymentType == PaymentType.Cash)
            {
                return Ok(CardPay(payment.Amount, payment.Currency));
            }
            else if (payment.PaymentType == PaymentType.Card)
            {
                return Ok(CashPay(payment.Amount, payment.Currency));
            }
            return Ok(payment);
        }
        private string CardPay(double castka, string mena)
        {
            return ("Nevim jak mam platit");
        }
        private string CashPay(double amount, string currency)
        {
            return $"Zaplaceno {amount} {currency}";
        }
    }
    
}
