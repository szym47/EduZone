
using EduZone.Domain.Exceptions.CreditCard;
using System.Text.RegularExpressions;

namespace EduZone.Application.Services
{
    public interface ICreditCardService
    {
        public Boolean ValidateCardNumber(string cardNumber);

        public string GetCardType(string cardNumber);
    }
}
