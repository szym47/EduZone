using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Interfaces
{
    public interface ICreditCardServices
    {
        bool ValidateCardNumber(string cardNumber);
        string GetCardType(string cardNumber);
    }
}
