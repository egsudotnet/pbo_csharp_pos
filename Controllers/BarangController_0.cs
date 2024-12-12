// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using POSApplication.Models;
// using POSApplication.Services;

// namespace POSApplication.Controllers
// {
//     public class BarangController : Controller
//     {
//         private readonly PboPosContext _context;

//         public BarangController(PboPosContext context)
//         {
//             _context = context;
//         }

//         // READ: GET /Barang
//         public async Task<IActionResult> Index()
//         {
//             var barangs = await _context.Barangs.ToListAsync();
//             return View(barangs);
//         }

  
//     }
// }
