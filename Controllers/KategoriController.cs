using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSApplication.Models;
using POSApplication.Services;

namespace POSApplication.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        // READ: GET /Kategori
        public async Task<IActionResult> Index()
        {
            var kategoris = await _kategoriService.GetAllAsync();
            return View(kategoris);
        }

        // CREATE: GET /Kategori/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                await _kategoriService.AddAsync(kategori);
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // UPDATE: GET /Kategori/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var kategori = await _kategoriService.GetByIdAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                await _kategoriService.UpdateAsync(kategori);
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // DELETE: GET /Kategori/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var kategori = await _kategoriService.GetByIdAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _kategoriService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
