namespace stincv.Models
{
    public class Payment
    {
        public double Amount { get; set; }
        public string Currency { get; set; } = "";
        public DateTime Date { get; set; }
        public string PaymentType { get; set; } = "";
        public List<string> Items { get; set; } = new List<string>();
    }
}
