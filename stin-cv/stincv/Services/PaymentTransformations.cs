using Newtonsoft.Json;
using stincv.Models;
using stincv.ViewModels;

namespace stincv.Services
{
    public static class PaymentTransformations
    {
        public static string transformXMLFromPayment(Payment payment)
        {
            try
            {
                return JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(payment)).OuterXml;
            }
            catch(JsonException e)
            {
                throw;
            }
        }

        public static Payment transformPaymentFromPaymentVM(PaymentVM paymentVM)
        {
            try
            {
                return new Payment
                {
                    Amount = paymentVM.Amount,
                    Currency = paymentVM.Currency,
                    Date = DateTime.Parse(paymentVM.Date),
                    PaymentType = paymentVM.PaymentType,
                    Items = new List<string>()
                };
            }
            catch(FormatException e)
            {
                throw new FormatException("DateTime must be in valid format. For example in format: yyyy-MM-dd", e);
            }
        }
    }
}
