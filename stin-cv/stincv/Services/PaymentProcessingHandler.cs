using stincv.Models;

namespace stincv.Services
{
    public class PaymentProcessingHandler
    {
        private Dictionary<string, IPaymentService> paymentProcessors;
        public PaymentProcessingHandler()
        {
            paymentProcessors = new Dictionary<string, IPaymentService>();
            paymentProcessors.Add("CARD", new CardPaymentService());
            paymentProcessors.Add("CASH", new CashPaymentService());
        }

        public string ProcessPayment(Payment payment)
        {
            try
            {
                return paymentProcessors[payment.PaymentType].ProcessPayment(payment);
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
