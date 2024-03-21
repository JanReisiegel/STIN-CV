using Newtonsoft.Json;
using stincv.Models;
using stincv.ViewModels;

namespace stincv.Services
{
    public static class PaymentTransformations
    {
        public static string transformXMLFromPayment(PaymentVM payment)
        {
            try
            {
                return JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(payment), "Payment").OuterXml;
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

        public static PaymentVM transformPaymentVMFromPayment(Payment payment)
        {
            return new PaymentVM
            {
                Amount = payment.Amount,
                Currency = payment.Currency,
                Date = payment.Date.ToString("yyyy-MM-dd"),
                PaymentType = payment.PaymentType,
                Items = payment.Items
            };
        }
    }
}
