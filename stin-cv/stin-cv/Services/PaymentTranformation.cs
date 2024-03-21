using Newtonsoft.Json;
using StinCVProject.Models;
using System.Text.Json.Serialization;

namespace stin_cv.Services
{
    public class PaymentTranformation
    {
        public string transformXMLFromPayment(Payment payment)
        {
            try
            {
                return JsonConvert.SerializeObject(payment);
            }
            catch(JsonException jsonException)
            {
                throw new JsonException("Error Serialize JSON", jsonException);
            }
        }
        public Payment transformPaymentFromXML(string payment)
        {
            Payment result;
            try
            {
                result = JsonConvert.DeserializeObject<Payment>(payment) ?? new Payment();
            }
            catch(JsonException jsonException)
            {
                throw new JsonException("Error Deserialize JSON", jsonException);
            }
            return result;
        }
    }
}
