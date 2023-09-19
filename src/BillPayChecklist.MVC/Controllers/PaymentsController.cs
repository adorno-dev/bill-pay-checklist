using System.Threading.RateLimiting;
using BillPayChecklist.Application.Entities;
using BillPayChecklist.Application.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BillPayChecklist.MVC.Controllers
{
    [Route("payments")]
    public class PaymentsController : Controller
    {
        private static List<Bill> bills = new List<Bill>()
        {
            new Bill { Id = Guid.Parse("91046f47-b6bf-46d9-8c6e-77ff27aa9661"), Title = "Bill Ref #101", DueDay = 10, RefMonth = 9, Recurrent = true },
            new Bill { Id = Guid.Parse("47f6ea7b-e1b2-4377-bb29-deae0ce329e0"), Title = "Bill Ref #207", DueDay = 5, RefMonth = 8, Recurrent = true },
            new Bill { Id = Guid.Parse("cbaddf25-aab4-4d27-8cbb-14130ea5c015"), Title = "Bill Ref #305", DueDay = 8, RefMonth = 9, Recurrent = true },
        };

        private static List<Payment> payments = new List<Payment>()
        {
            new Payment 
            { 
                Id = Guid.Parse("4895b6cc-4a78-43ee-8aa5-4424a7a435f5"), 
                Bill = bills.Find(x => x.Id == Guid.Parse("91046f47-b6bf-46d9-8c6e-77ff27aa9661")),
                PaymentDate = new DateOnly(2023, 9, 18), 
                RefMonth = 9,
                Amount = 165.78M,
                BillId = Guid.Parse("91046f47-b6bf-46d9-8c6e-77ff27aa9661")
            },
            new Payment { 
                Id = Guid.Parse("ecd78c14-21d6-4b01-8578-48d29120e9cc"), 
                Bill = bills.Find(x => x.Id == Guid.Parse("47f6ea7b-e1b2-4377-bb29-deae0ce329e0")),
                PaymentDate = new DateOnly(2023, 8, 20), 
                RefMonth = 8,
                Amount = 201.78M,
                BillId = Guid.Parse("47f6ea7b-e1b2-4377-bb29-deae0ce329e0")
            },
            new Payment { 
                Id = Guid.Parse("0e1c1010-d534-4879-88ee-afc3f8a1df40"), 
                Bill = bills.Find(x => x.Id == Guid.Parse("cbaddf25-aab4-4d27-8cbb-14130ea5c015")),
                PaymentDate = new DateOnly(2023, 9, 13), 
                RefMonth = 9,
                Amount = 185.60M,
                BillId = Guid.Parse("cbaddf25-aab4-4d27-8cbb-14130ea5c015"),
                Comment = """
                This is a simple content.
                Please make sure this comment was rendered.
                """
            },
        };

        private void setBillSelectList(Guid? id = null)
        {
            var billList = bills.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Title, Selected = x.Id == id })
                                .ToList();

            billList.Insert(0, new SelectListItem { Text = "Choose..." });

            ViewBag.BillList = billList;
        }

        private void setMonthSelectList(int? id = null)
        {
            var monthList = Enumerable.Range(1, 12).Select(x => new SelectListItem { Value = $"{x}", Text = $"{(MonthEnum)x}", Selected = x == id }).ToList();

            monthList.Insert(0, new SelectListItem { Text = "Pending Months" });

            ViewBag.MonthList = monthList;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(payments);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            var payment = new Payment() { PaymentDate = DateOnly.FromDateTime(DateTime.Now) };
            
            setBillSelectList();
            setMonthSelectList();

            return View("CreateOrEdit", payment);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(Guid id)
        {
            var payment = payments.Find(b => b.Id == id);

            setBillSelectList(payment!.BillId);
            setMonthSelectList(payment!.RefMonth);

            return View("CreateOrEdit", payment);
        }
    }
}