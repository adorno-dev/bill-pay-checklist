using Microsoft.AspNetCore.Mvc;

namespace BillPayChecklist.MVC.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}