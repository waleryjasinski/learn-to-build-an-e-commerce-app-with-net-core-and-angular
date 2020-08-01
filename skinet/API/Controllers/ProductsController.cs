using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Specification;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{

  public class ProductsController : BaseApiController
  {
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<ProductType> _productTypeRepo;

    public ProductsController(
      IGenericRepository<Product> productRepo,
      IGenericRepository<ProductType> productTypeRepo,
      IGenericRepository<ProductBrand> productBrandRepo,
      IMapper mapper
    )
    {
      _productRepo = productRepo ?? throw new System.ArgumentNullException(nameof(productRepo));
      _productTypeRepo = productTypeRepo ?? throw new System.ArgumentNullException(nameof(productTypeRepo));
      _productBrandRepo = productBrandRepo ?? throw new System.ArgumentNullException(nameof(productBrandRepo));
      _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort = null, int? brandId = null, int? typeId = null)
    {
      var spec = new ProductsWithTypesAndBrandsSpecification(sort, brandId, typeId);
      var products = await _productRepo.ListAsync(spec);

      return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
      var spec = new ProductsWithTypesAndBrandsSpecification(id);
      var product = await _productRepo.GetEntityWithSpec(spec);

      return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
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
