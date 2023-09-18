using Microsoft.AspNetCore.Mvc;

namespace BillPayChecklist.MVC.Controllers
{
    [Route("payments")]
    public class PaymentsController : Controller
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