using StinCVProject.Models;

namespace stin_cv.Services
{
    public class CardPaymentService : IPaymentService
    {
        public string ProcessPayment(Payment payment)
        {
            string toPay = payment.Amount + "/" + payment.Currency;
            return toPay;
        }
    }
}
