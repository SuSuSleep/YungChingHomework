using Microsoft.AspNetCore.Mvc;
using YungChingHomework.DTOs.Conditions;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Services;

namespace YungChingHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }
        [HttpGet]
        public IEnumerable<OrderDetailView> GetAll()
        {
            return _orderDetailService.GetOrderDetails(new OrderDetailSearchCondition());
        }

        [HttpGet("{Id}", Name = "GetOrderDetail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public OrderDetailView? Get([FromRoute] long Id)
        {
            return _orderDetailService.GetOrderDetail(Id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public long Create([FromBody] NewOrderDetailInfo NewOrderDetail)
        {
            return _orderDetailService.CreateOrderDetail(NewOrderDetail);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] OrderDetailInfo UpdatedOrderDetail)
        {
            bool success = _orderDetailService.UpdateOrderDetail(UpdatedOrderDetail);
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
            bool success = _orderDetailService.DeleteOrderDetail(Id);
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
