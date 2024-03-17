using Microsoft.AspNetCore.Mvc;

namespace Project.PL.Controllers
{
    public class AdminBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
