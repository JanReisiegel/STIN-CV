using stincv.Models;

namespace stincv.Services
{
    public interface IPaymentService
    {
        public string ProcessPayment(Payment payment);
    }
}
