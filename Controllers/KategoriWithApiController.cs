using Microsoft.AspNetCore.Mvc;

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
