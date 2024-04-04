using Newtonsoft.Json;
using stincv.Models;
using stincv.ViewModels;

namespace stincv.Services
{
    public static class PaymentTransformations
    {
        public static string transformXMLFromPayment(PaymentVM payment)
        {
            return JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(payment), "Payment").OuterXml;
        }

        public static Payment transformPaymentFromString(string payload)
        {
            try
            {
                return JsonConvert.DeserializeObject<Payment>(payload);
            }
            catch(JsonSerializationException e)
            {
                throw;
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
