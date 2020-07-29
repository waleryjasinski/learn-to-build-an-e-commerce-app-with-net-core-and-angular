using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;

    public ProductsController(
      IGenericRepository<Product> productRepo,
      IGenericRepository<ProductType> productTypeRepo,
      IGenericRepository<ProductBrand> productBrandRepo
    )
    {
      _productRepo = productRepo ?? throw new System.ArgumentNullException(nameof(productRepo));
      _productTypeRepo = productTypeRepo ?? throw new System.ArgumentNullException(nameof(productTypeRepo));
      _productBrandRepo = productBrandRepo ?? throw new System.ArgumentNullException(nameof(productBrandRepo));
    } 

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
      var products = await _productRepo.ListAllAsync();

      return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      var product = await _productRepo.GetByIdAsync(id);

      return Ok(product);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
      return Ok(await _productBrandRepo.ListAllAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
      return Ok(await _productTypeRepo.ListAllAsync());
    }
  }
}
