using Microsoft.AspNetCore.Mvc;

namespace TestBLL.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
