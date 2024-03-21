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
                string result = PaymentTransformations.transformXMLFromPayment(payment);
                return result;
            }
            catch(JsonException e)
            {
                throw;
            }
        }
    }
}
