namespace _98market.Core.ZarinPal
{
    public class PaymentResponse
    {
        public int Status { get; set; }
        public string Authority { get; set; }
        public string Fullname { get; set; }
        public string PersonNumber { get; set; }
        public int ItemCount { get; set; }
        public string Address { get; set; }
        public string Amount { get; set; }
    }
}