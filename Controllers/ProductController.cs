using Microsoft.AspNetCore.Mvc;
using YungChingHomework.DTOs.Infos;
using YungChingHomework.DTOs.ViewModels;
using YungChingHomework.Service;
using YungChingHomework.Services;

namespace YungChingHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet]
        public IEnumerable<ProductView> GetAll()
        {
            return this._productService.GetProducts();
        }

        [HttpGet("{Id}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ProductView? Get([FromRoute] long Id)
        {
            return this._productService.GetProduct(Id);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public long Create([FromBody] NewProductInfo NewProduct)
        {
            return this._productService.CreateProduct(NewProduct);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] ProductInfo UpdatedProduct)
        {
            bool success = this._productService.UpdateProduct(UpdatedProduct);
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
            bool success = this._productService.DeleteProduct(Id);
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
