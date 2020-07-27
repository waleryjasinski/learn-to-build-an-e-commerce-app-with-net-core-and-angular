using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    public ProductsController()
    {
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        //TODO: Implement Realistic Implementation
        return Ok("this will return list of products");
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        //TODO: Implement Realistic Implementation
        return Ok("this will return detail of product");
    }
  }
}