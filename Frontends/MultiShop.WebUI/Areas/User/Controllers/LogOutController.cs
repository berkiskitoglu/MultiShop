using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
