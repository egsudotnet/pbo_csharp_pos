
using Microsoft.AspNetCore.Mvc;
using POSApplication.Models;
using POSApplication.Services;

[Route("[controller]/[action]")]
public class BarangController : Controller
{
    private readonly IBarangService _barangService;

    public BarangController(IBarangService barangService)
    {
        _barangService = barangService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _barangService.GetAllAsync();
        return Json(result);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = _barangService.GetByIdAsync(id);
        return Json(result);
    }

    [HttpPost]
    public IActionResult Create([FromForm] Barang model)
    {
        _barangService.AddAsync(model);
        return Ok();
    }

    [HttpPost]
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
