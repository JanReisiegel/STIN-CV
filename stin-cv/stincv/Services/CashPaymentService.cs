using stincv.Models;
using System.Text.Json;

namespace stincv.Services
{
    public class CashPaymentService : IPaymentService
    {
        public string ProcessPayment(Payment payment)
        {
            try
            {
                var paymentVM = PaymentTransformations.transformPaymentVMFromPayment(payment);
                string result = PaymentTransformations.transformXMLFromPayment(paymentVM);
                return result;
            }
            catch(JsonException e)
            {
                throw;
            }
        }
    }
}
