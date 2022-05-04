namespace _98market.Core.Sms.Sms
{
    public interface ISmsService
    {
        void Send(string number, string message);
    }
}