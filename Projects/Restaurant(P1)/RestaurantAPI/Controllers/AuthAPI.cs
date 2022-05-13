using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    public class AuthAPI : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
