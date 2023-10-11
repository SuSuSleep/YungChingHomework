using Microsoft.AspNetCore.Mvc;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.Service;
using YungChingHomework.Services;

namespace YungChingHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerAnalysisService _customerAnalysisService;
        public CustomerController(ICustomerService customerService, ICustomerAnalysisService _customerAnalysisService) 
        {
            this._customerService = customerService;
            this._customerAnalysisService = _customerAnalysisService;
        }
        [HttpGet]
        public IEnumerable<CustomerView> GetAll()
        {
            return this._customerService.GetCustomers();
        }

        [HttpGet("{Id}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public CustomerView? Get([FromRoute] long Id)
        {
            return this._customerService.GetCustomer(Id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public long Create([FromBody] NewCustomerInfo NewCustomer)
        {
            return this._customerService.CreateCustomer(NewCustomer);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] CustomerInfo UpdatedCustomer)
        {
            bool success = this._customerService.UpdateCustomer(UpdatedCustomer);
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
            bool success = this._customerService.DeleteCustomer(Id);
            if (success == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("ProductCash/{Id}", Name = "GetCustomerProductCash")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public CustomerProductCash? GetCustomerProductCash(long Id)
        {
            return this._customerAnalysisService.GetCustomerProductCash(Id);
        }
    }
}
