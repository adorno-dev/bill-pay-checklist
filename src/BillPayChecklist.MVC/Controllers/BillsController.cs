using Microsoft.AspNetCore.Mvc;

namespace BillPayChecklist.MVC.Controllers
{
    [Route("bills")]
    public class BillsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
    }
}