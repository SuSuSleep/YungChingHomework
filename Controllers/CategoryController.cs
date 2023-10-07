using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YungChingHomework.DBModels;

namespace YungChingHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet(Name = "GetCategory")]
        public Category? Get(long Id)
        {
            using var dbContext = new NorthwindContext();
            return dbContext.Categories.Where(c => c.CategoryId == Id).FirstOrDefault();
        }
    }
}
