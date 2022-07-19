namespace _98market.Core.ZarinPal
{
    public interface IZarinPalFactory
    {
        string Prefix { get; set; }

        PaymentResponse CreatePaymentRequest(int amount, string description,
            int cartId);

        VerificationResponse CreateVerificationRequest(string authority, string price);
    }
}