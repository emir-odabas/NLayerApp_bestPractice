using Microsoft.AspNetCore.Mvc;

namespace NLayer.Web.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
