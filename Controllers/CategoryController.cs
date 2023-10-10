using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YungChingHomework.DBModels;

namespace YungChingHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            using var dbContext = new NorthwindContext();
            return dbContext.Categories.ToList();
        }

        [HttpGet("{id}", Name = "GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Category? Get([FromRoute] long id)
        {
            using var dbContext = new NorthwindContext();
            return dbContext.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Category newCategory)
        {
            using var dbContext = new NorthwindContext();
            long currentMaxId = dbContext.Categories.Max(c => c.CategoryId);
            newCategory.CategoryId = currentMaxId + 1;
            dbContext.Categories.Add(newCategory);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody] Category newCategory)
        {
            using var dbContext = new NorthwindContext();
            var category = dbContext.Categories.Where(c => c.CategoryId.Equals(newCategory.CategoryId)).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            category.CategoryName = newCategory.CategoryName;
            category.Description = newCategory.Description;
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] long id)
        {
            using var dbContext = new NorthwindContext();
            var category = dbContext.Categories.Where(c => c.CategoryId.Equals(id)).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
