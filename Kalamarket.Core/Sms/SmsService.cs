using System;
using System.Collections.Generic;
using System.Linq;
using _98market.Core.Sms.Sms;
using Microsoft.Extensions.Configuration;
using SmsIrRestful;

namespace _98market.Core.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string number, string message)
        {
            Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi("4E436D47786E5A6E7A57624D5359542F7348496471423142474F6B635977367770387036774E494435334D3D");
            var result = api.Send("", number, message);
        }

    }
}