using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
  public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
  {
    public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
    :base( c => 
      (!brandId.HasValue || c.ProductBrandId == brandId) && 
      (!typeId.HasValue || c.ProductTypeId == typeId)
    )
    {
      AddInclude(p => p.ProductType);
      AddInclude(p => p.ProductBrand);
      AddOrderBy(p => p.Name);
      if (!string.IsNullOrEmpty(sort))
      {
        switch (sort)
        {
            case "priceAsc":
              AddOrderBy(p => p.Price);
              break;
            case "proceDesc":
              AddOrderByDescending(p => p.Price);
              break;              
            default:
               AddOrderBy(p => p.Name);
               break;
        }
      }
    }

    public ProductsWithTypesAndBrandsSpecification(int id)
    : base(p => p.Id == id)
    {
      AddInclude(p => p.ProductType);
      AddInclude(p => p.ProductBrand);
    }
  }
}