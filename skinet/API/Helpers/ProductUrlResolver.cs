using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
  public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
  {
    private readonly IConfiguration _config;
    public ProductUrlResolver(IConfiguration config)
    {
      _config = config ?? throw new System.ArgumentNullException(nameof(config));
    }

    public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
    {
      
      if (!string.IsNullOrEmpty(source.PictureUrl))
      {
        return _config.GetValue<string>("ApiUrl") + source.PictureUrl;
      }
      
      return null;
    }
  }
}