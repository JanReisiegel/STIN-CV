using StinCVProject.Models;

namespace stin_cv.Services
{
    public class CardPaymentService : IPaymentService
    {
        public void ProcessPayment(Payment payment)
        {
            string toPay = payment.Amount + "/" + payment.Currency;
            paymentServiceProcessing.pay(toPay);
        }
    }
}
