using Microsoft.AspNetCore.Mvc;

namespace BillPayChecklist.MVC.Controllers
{
    [Route("payments")]
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}