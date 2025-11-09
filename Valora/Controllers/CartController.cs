using Microsoft.AspNetCore.Mvc;

namespace Valora.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
