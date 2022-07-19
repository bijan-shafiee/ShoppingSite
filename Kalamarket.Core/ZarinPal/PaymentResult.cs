namespace _98market.Core.ZarinPal
{
    public class PaymentResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string IssueTrackingNo { get; set; }
        public string Description { get; set; }
        public string CartId { get; set; }

        public PaymentResult Succeeded(string description, string issueTrackingNo, string cartId)
        {
            IssueTrackingNo = issueTrackingNo;
            IsSuccessful = true;
            Description = description;
            CartId = cartId;
            return this;
        }

        public PaymentResult Failed(string message, string cartId)
        {
            Message = message;
            IsSuccessful = false;
            CartId = cartId;
            return this;
        }
    }
}