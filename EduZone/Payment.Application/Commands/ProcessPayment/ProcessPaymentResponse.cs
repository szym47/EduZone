using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Commands.ProcessPayment
{
    public class ProcessPaymentResponse
    {
        public bool Success { get; set; }
        public Guid? TransactionId { get; set; }
        public string? Status { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
