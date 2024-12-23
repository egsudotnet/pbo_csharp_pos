
using Microsoft.AspNetCore.Mvc;
using POSApplication.Models;
using POSApplication.Services;

// [Route("[controller]/[action]")]
// // // [Route("api/[controller]")]
[ApiController]
[Route("api/[controller]")]
public class BarangWithApiController : Controller
{
    private readonly IBarangService _barangService;

    public BarangWithApiController(IBarangService barangService)
    {
        _barangService = barangService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _barangService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _barangService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Create([FromForm] Barang model)
    {
        _barangService.AddAsync(model);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update([FromForm] Barang model)
    {
        _barangService.UpdateAsync(model);
        return Ok();
    }

    [HttpPost("{id}")]
    public IActionResult Delete(int id)
    {
        _barangService.DeleteAsync(id);
        return Ok();
    }
}
