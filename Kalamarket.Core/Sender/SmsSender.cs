

using Kavenegar;

namespace _98market.Core.Sender
{
    public static class SmsSender
    {
        public static void VerifySend(string to, string token)
        {
            var sender = "10008663";
            var receptor = to;
            var message = token;
            var api = new KavenegarApi("41464C6B54464132463634366D676C4E664E385A784733776366425451577458506E7A7457344F57414D6B3D");
            api.Send(sender, to, message);

        }
    }
}
