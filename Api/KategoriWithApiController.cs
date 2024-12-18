// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Web.Handler;


// // // [Route("kategori")]
// // // [ApiController]
 

using Microsoft.AspNetCore.Mvc;
using POSApplication.Models;
using POSApplication.Services;


[ApiController]
[Route("api/[controller]")]

// // // [Route("api/kategori")] 
public class KategoriWithApiController : ControllerBase
{
    private readonly IKategoriService _kategoriService;

    public KategoriWithApiController(IKategoriService kategoriService)
    {
        _kategoriService = kategoriService;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var data = await _kategoriService.GetAllAsync();
        return Ok(data);
    }

    [HttpPost()]
    public async Task<IActionResult> Add([FromBody] Kategori kategori)
    {
        await _kategoriService.AddAsync(kategori);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Kategori kategori)
    {
        kategori.Id = id;
        await _kategoriService.UpdateAsync(kategori);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _kategoriService.DeleteAsync(id);
        return Ok();
    }
}
