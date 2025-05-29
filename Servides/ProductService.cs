using AutoMapper;
using backend.DTOs;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _repo;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repo, IMapper mapper)
    {
      _repo = repo;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
      var products = await _repo.GetAllAsync();
      return _mapper.Map<IEnumerable<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
      var product = await _repo.GetByIdAsync(id);
      return product == null ? null : _mapper.Map<ProductDto>(product);
    }

    public async Task AddAsync(ProductDto dto)
    {
      var product = _mapper.Map<Product>(dto);
      await _repo.AddAsync(product);
    }

    public async Task UpdateAsync(int id, ProductDto dto)
    {
      var product = await _repo.GetByIdAsync(id);
      if (product == null) return;
      _mapper.Map(dto, product);
      await _repo.UpdateAsync(product);
    }

    public async Task DeleteAsync(int id)
    {
      var product = await _repo.GetByIdAsync(id);
      if (product == null) return;
      await _repo.DeleteAsync(product);
    }
  }
}
