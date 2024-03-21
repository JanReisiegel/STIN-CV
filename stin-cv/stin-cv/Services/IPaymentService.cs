using StinCVProject.Models;

namespace stin_cv.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(Payment payment);
    }
}
