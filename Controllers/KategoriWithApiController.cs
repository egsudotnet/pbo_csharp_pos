using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POSApplication.Models;
using POSApplication.Services;

namespace POSApplication.Controllers
{
    public class KategoriWithApiController : Controller
    {      
        
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }    
}
