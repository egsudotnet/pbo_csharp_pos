using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POSApplication.Models;
using POSApplication.Services;

namespace POSApplication.Controllers
{
    public class BarangController : Controller
    {
        private readonly IBarangService _barangService;
        private readonly IKategoriService _kategoriService;

        [ActivatorUtilitiesConstructor]
        public BarangController(IBarangService barangService, 
                                IKategoriService kategoriService)
        {
            _barangService = barangService;
            _kategoriService = kategoriService;
        }

        // READ: GET /Barang
        public async Task<IActionResult> Index()
        {
            var barangs = await _barangService.GetAllAsync();
            return View(barangs);
        }

        // CREATE: GET /Barang/Create
        public async Task<IActionResult> Create()
        { 
         
            ViewBag.KategoriList = await GetSelectListAsync();
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

            ViewBag.KategoriList = await GetSelectListAsync();         
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
            
            // Kirim data kategori ke View         
            ViewBag.KategoriList = await GetSelectListAsync();

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
            
            // Kirim data kategori ke View  
            ViewBag.KategoriList = await GetSelectListAsync();

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

        private async Task<List<SelectListItem>> GetSelectListAsync()
        {
            // Ambil data kategori dari service
            var kategoriList = await _kategoriService.GetAllAsync();

            // Konversi ke SelectListItem
            var selectList = kategoriList.Select(k => new SelectListItem
            {
                Value = k.Id.ToString(),  // Properti ID kategori
                Text = k.Nama             // Properti nama kategori
            }).ToList();

            return selectList;  // Kembalikan hasil
        }


    }
    
}
