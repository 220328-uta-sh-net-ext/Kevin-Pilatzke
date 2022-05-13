using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    public class UserAPI : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
