using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using _98market.Core.Sms.Sms;
using Microsoft.Extensions.Configuration;
//using SmsIrRestful;

namespace _98market.Core.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _configuration;

        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int Send(string phone, string message)
        {
            if (string.IsNullOrWhiteSpace(phone)) return -1;
            var resulCode = -1;

            var client = new HttpClient();
            var formContext = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"Username","bijan98shafiee" },
                  {"Passwod","Shafiee98" },
                { "PhoneNumber","50002200889117" },

            { "MessageBody",message},
            { "RecNumber",phone},
            { "SmsClass","1"},
            });


            var url = "https://RayganSMS.com/SendMessageWithPost.ashx";
            var response = client.PostAsync(url, formContext).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrWhiteSpace(result))
                {
                    resulCode = int.Parse(result);
                }

            }
            return resulCode;
        }

    }

   
}

