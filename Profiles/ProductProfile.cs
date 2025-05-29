using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
  public class ProductProfile : Profile
  {
    public ProductProfile()
    {
      CreateMap<Product, ProductDto>().ReverseMap();
    }
  }
}
