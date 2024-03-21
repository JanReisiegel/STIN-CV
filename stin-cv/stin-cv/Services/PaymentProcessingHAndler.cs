using StinCVProject.Models;

namespace stin_cv.Services
{
    public class PaymentProcessingHandler
    {
        private Dictionary<PaymentType, IPaymentService> _paymentServices;

        public PaymentProcessingHandler(CardPaymentService cardPayment, CashPaymentService cashPayment)
        {
            _paymentServices = new Dictionary<PaymentType, IPaymentService>
            {
                { PaymentType.Card, cardPayment },
                { PaymentType.Cash, cashPayment }
            };
        }

        public string ProcessPayment(Payment payment)
        {
            return _paymentServices[payment.PaymentType].ProcessPayment(payment);
        }
    }
}
