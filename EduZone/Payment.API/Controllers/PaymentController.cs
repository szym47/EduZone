using Microsoft.AspNetCore.Mvc;
using MediatR;
using Payment.Application.Commands.ProcessPayment;

namespace Payment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
