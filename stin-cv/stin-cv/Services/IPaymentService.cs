using StinCVProject.Models;

namespace stin_cv.Services
{
    public interface IPaymentService
    {
        string ProcessPayment(Payment payment);
    }
}
