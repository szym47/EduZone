using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Payment.Domain.Interfaces;

namespace Payment.Application.Services
{
    public class CreditCardServices : ICreditCardServices
    {
        public bool ValidateCardNumber(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

            if (cardNumber.Length < 13)
                throw new Exception("Credit card number is too short");

            if (cardNumber.Length > 19)
                throw new Exception("Credit card number is too long");

            if (!cardNumber.All(char.IsDigit))
                throw new Exception("Credit card number has invalid characters");

            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = cardNumber[i] - '0';

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                alternate = !alternate;
            }

            if (sum % 10 == 0)
                return true;

            throw new Exception("Credit card number is invalid");
        }

        public string GetCardType(string cardNumber)
        {
            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

            if (Regex.IsMatch(cardNumber, @"^4(\d{12}|\d{15}|\d{18})$"))
                return "Visa";
            else if (Regex.IsMatch(cardNumber, @"^(5[1-5]\d{14}|2(2[2-9][1-9]|2[3-9]\d{2}|[3-6]\d{3}|7([01]\d{2}|20\d))\d{10})$"))
                return "MasterCard";
            else if (Regex.IsMatch(cardNumber, @"^3[47]\d{13}$"))
                return "American Express";
            else if (Regex.IsMatch(cardNumber, @"^(6011\d{12}|65\d{14}|64[4-9]\d{13}|622(1[2-9][6-9]|[2-8]\d{2}|9([01]\d|2[0-5]))\d{10})$"))
                return "Discover";
            else if (Regex.IsMatch(cardNumber, @"^(352[89]|35[3-8]\d)\d{12}$"))
                return "JCB";
            else if (Regex.IsMatch(cardNumber, @"^3(0[0-5]|[68]\d)\d{11}$"))
                return "Diners Club";
            else if (Regex.IsMatch(cardNumber, @"^(50|5[6-9]|6\d)\d{10,17}$"))
                return "Maestro";
            else
                throw new Exception("Unsupported card provider");
        }
    }

}
