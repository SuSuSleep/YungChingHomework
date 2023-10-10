using Microsoft.AspNetCore.Mvc;
using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Services;

namespace YungChingHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        [HttpGet]
        public IEnumerable<OrderView> GetAll()
        {
            return this._orderService.GetOrders(new OrderSearchCondition());
        }

        [HttpGet("{Id}", Name = "GetOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public OrderView? Get([FromRoute] long Id)
        {
            return this._orderService.GetOrder(Id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public long Create([FromBody] NewOrderInfo NewOrder)
        {
            return this._orderService.CreateOrder(NewOrder);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] OrderInfo UpdatedOrder)
        {
            bool success = this._orderService.UpdateOrder(UpdatedOrder);
            if (success == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] long Id)
        {
            bool success = this._orderService.DeleteOrder(Id);
            if (success == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
