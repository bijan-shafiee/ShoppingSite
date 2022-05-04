namespace _98market.Core.ZarinPal
{
    public class PaymentResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public string IssueTrackingNo { get; set; }
        public string Description { get; set; }

        public PaymentResult Succeeded(string description, string issueTrackingNo)
        {
            IssueTrackingNo = issueTrackingNo;
            Description = description;
            return this;
        }

        public PaymentResult Failed(string message)
        {
            Message = message;
            IsSuccessful = false;
            return this;
        }
    }
}