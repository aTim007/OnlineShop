using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class ShopController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }



    }
}
