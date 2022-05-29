using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _98market.Core
{
    public class EmailOrPhoneNumberAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("این مقدار نمیتواند خالی باشد");
            string valueAsString = value.ToString();

            const string emailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            bool isValidEmail = Regex.IsMatch(valueAsString, emailRegex);

            if (isValidEmail)
            {
                return ValidationResult.Success;
            }

            const string usaPhoneNumbersRegex = @"[0]{1}[9]{1}[0-9]{9}";
            bool isValidPhone = Regex.IsMatch(valueAsString, usaPhoneNumbersRegex);

            if (isValidPhone)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("شماره تلفن یا ایمیل وارد شده درست نمیباشد");
        }
    }
}
