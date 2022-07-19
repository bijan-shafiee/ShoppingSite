namespace _98market.Core.ZarinPal
{
    public class PaymentRequest
    {
        public string CallbackURL { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Amount { get; set; }
        public string MerchantID { get; set; }
    }
}