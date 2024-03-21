using stincv.Models;

namespace stincv.Services
{
    public class CardPaymentService : IPaymentService
    {
        public string ProcessPayment(Payment payment)
        {
            return $"{payment.Amount}/{payment.Currency}";
        }
    }
}
