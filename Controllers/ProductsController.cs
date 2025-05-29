using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
      Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var product = await _service.GetByIdAsync(id);
      return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto dto)
    {
      await _service.AddAsync(dto);
      return CreatedAtAction(nameof(GetById), new { id = dto.Name }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductDto dto)
    {
      await _service.UpdateAsync(id, dto);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _service.DeleteAsync(id);
      return NoContent();
    }
  }
}
