using Microsoft.AspNetCore.Mvc;

namespace POSApplication.Controllers
{
    public class BarangWithApiController : Controller
    {      
        
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }    
}
