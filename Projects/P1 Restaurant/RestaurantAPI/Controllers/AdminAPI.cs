using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    public class AdminAPI : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
