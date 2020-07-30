using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  public class BuggyController : BaseApiController
  {
    private readonly StoreContext _context;
    public BuggyController(StoreContext context)
    {
      _context = context;
    }


    [HttpGet("NotFound")]
    public IActionResult GetNotFoundRequest()
    {
      var thing = _context.Products.Find(-1);
      if (thing == null)
      {
        return NotFound(new ApiResponse(404));
      }
      return Ok();
    }


    [HttpGet("ServerError")]
    public IActionResult GetServerError()
    {
      var thing = _context.Products.Find(-1);
      var error = thing.ToString();
      return Ok();
    }


    [HttpGet("BadRequest")]
    public IActionResult GetBadRequest()
    {
      return BadRequest(new ApiResponse(400));
    }



    [HttpGet("BadRequest/{id}")]
    public IActionResult GetNotFoundRequest(int id)
    {
      return Ok();
    }


    [HttpGet("maths")]
    public IActionResult GetDivideByZeroError()
    {
      var zero = 0;
      var error = 10/zero; 
      return Ok();
    }
  }
}