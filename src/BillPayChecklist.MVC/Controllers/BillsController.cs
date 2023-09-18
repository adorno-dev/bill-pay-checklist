using BillPayChecklist.Application.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BillPayChecklist.MVC.Controllers
{
    [Route("bills")]
    public class BillsController : Controller
    {
        private static List<Bill> bills = new List<Bill>()
        {
            new Bill { Id = Guid.Parse("91046f47-b6bf-46d9-8c6e-77ff27aa9661"), Title = "Bill Ref #101", DueDay = 10, RefMonth = 9, Recurrent = true },
            new Bill { Id = Guid.Parse("47f6ea7b-e1b2-4377-bb29-deae0ce329e0"), Title = "Bill Ref #207", DueDay = 5, RefMonth = 8, Recurrent = true },
            new Bill { Id = Guid.Parse("cbaddf25-aab4-4d27-8cbb-14130ea5c015"), Title = "Bill Ref #305", DueDay = 8, RefMonth = 9, Recurrent = true },
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(bills);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            var bill = new Bill();
            // bill.Title = "";
            // bill.DueDay = 1;
            // bill.RefMonth = 9;
            // bill.Recurrent = false;

            return View("CreateOrEdit", bill);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(Guid id)
        {
            return View("CreateOrEdit", bills.Find(b => b.Id == id));
        }
    }
}