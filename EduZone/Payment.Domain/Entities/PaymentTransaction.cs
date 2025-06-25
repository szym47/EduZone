using Payment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Entities
{
    public class PaymentTransaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
