using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSApplication.Models;
using POSApplication.Services;

namespace POSApplication.Controllers
{
public class PenjualanController : Controller
{
    private readonly IPenjualanService _penjualanService;
    private readonly PboPosContext _context;

    public PenjualanController(IPenjualanService penjualanService, PboPosContext context)
    {
        _penjualanService = penjualanService;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Barangs = await _context.Barangs.ToListAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Penjualan penjualan, List<DetailPenjualan> detailPenjualans)
    {
        if (ModelState.IsValid)
        {
            var result = await _penjualanService.AddPenjualanAsync(penjualan, detailPenjualans);
            if (result)
            {
                return RedirectToAction("Index", "Penjualan");
            }
        }
        return View(penjualan);
    }
}

}
