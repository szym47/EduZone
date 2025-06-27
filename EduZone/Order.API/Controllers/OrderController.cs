using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Commands;
using Order.Domain.Models;
using Order.Domain.Queries;

namespace Order.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST /order/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrder), new { orderId }, orderId);
        }

        // POST /order/cancel
        [HttpPost("cancel")]
        public async Task<IActionResult> CancelOrder([FromBody] CancelOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        // GET /order/{orderId}
        [HttpGet("{orderId:int}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = orderId });
            return order is null ? NotFound() : Ok(order);
        }

        // GET /order
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }
    }
}
