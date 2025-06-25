using Payment.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Interfaces;
using Payment.Domain.Entities;
using Payment.Domain.Enums;

namespace Payment.Application.Commands.ProcessPayment
{
    public class ProcessPaymentHandler : IRequestHandler<ProcessPaymentCommand, ProcessPaymentResponse>
    {
        private readonly ICreditCardServices _cardServices;

        public ProcessPaymentHandler(ICreditCardServices cardServices)
        {
            _cardServices = cardServices;
        }

        public Task<ProcessPaymentResponse> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isValid = _cardServices.ValidateCardNumber(request.CardNumber);
                var cardType = _cardServices.GetCardType(request.CardNumber);

                var transaction = new PaymentTransaction
                {
                    Id = Guid.NewGuid(),
                    Amount = request.Amount,
                    CardNumber = request.CardNumber,
                    CardType = cardType,
                    Status = PaymentStatus.Success,
                    CreatedAt = DateTime.UtcNow
                };

                return Task.FromResult(new ProcessPaymentResponse
                {
                    Success = true,
                    TransactionId = transaction.Id,
                    Status = transaction.Status.ToString()
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new ProcessPaymentResponse
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
