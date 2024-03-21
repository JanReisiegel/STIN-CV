using StinCVProject.Models;

namespace stin_cv.Services
{
    public class CashPaymentService : IPaymentService
    {
        public void ProcessPayment(Payment payment)
        {
            try
            {
                paymentServiceProcessing.pay(paymentTransformations.transformXMLFromPayment(payment));
            }
            catch (JsonProcessingException jsonProcessingException)
            {
                //handle here
            }
        }
    }
}
