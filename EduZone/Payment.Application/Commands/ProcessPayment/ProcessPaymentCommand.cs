using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Commands.ProcessPayment
{
    public class ProcessPaymentCommand : IRequest<ProcessPaymentResponse>
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
