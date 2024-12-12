using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSApplication.Models;
using POSApplication.Services;

namespace POSApplication.Controllers
{
    public class BarangController : Controller
    {
        private readonly IBarangService _barangService;

        public BarangController(IBarangService barangService)
        {
            _barangService = barangService;
        }

        // READ: GET /Barang
        public async Task<IActionResult> Index()
        {
            var barangs = await _barangService.GetAllAsync();
            return View(barangs);
        }

        // CREATE: GET /Barang/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Barang barang)
        {
            if (ModelState.IsValid)
            {
                await _barangService.AddAsync(barang);
                return RedirectToAction(nameof(Index));
            }
            return View(barang);
        }

        // UPDATE: GET /Barang/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var barang = await _barangService.GetByIdAsync(id);
            if (barang == null)
            {
                return NotFound();
            }
            return View(barang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Barang barang)
        {
            if (ModelState.IsValid)
            {
                await _barangService.UpdateAsync(barang);
                return RedirectToAction(nameof(Index));
            }
            return View(barang);
        }

        // DELETE: GET /Barang/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var barang = await _barangService.GetByIdAsync(id);
            if (barang == null)
            {
                return NotFound();
            }
            return View(barang);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _barangService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
