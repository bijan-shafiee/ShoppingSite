namespace _98market.Core.Sms.Sms
{
    public interface ISmsService
    {
        int Send(string phone, string message);
    }
}