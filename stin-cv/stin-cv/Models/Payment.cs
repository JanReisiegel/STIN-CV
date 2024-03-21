namespace StinCVProject.Models
{
    public class Payment
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        public DateTime Date { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<string> Items { get; set; }

    }
    public enum PaymentType
    {
        Cash,
        Card,
    }
}
