using Newtonsoft.Json;
using StinCVProject.Models;

namespace stin_cv.Services
{
    public class CashPaymentService : IPaymentService
    {
        PaymentTranformation paymentTransformations = new PaymentTranformation();
        public string ProcessPayment(Payment payment)
        {
            try
            {
                return paymentTransformations.transformXMLFromPayment(payment);
            }
            catch (JsonException jsonProcessingException)
            {
                return "Error Processing JSON: " + jsonProcessingException.Message;
            }
        }
    }
}
