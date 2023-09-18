using BillPayChecklist.Application.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BillPayChecklist.MVC.Controllers
{
    [Route("payments")]
    public class PaymentsController : Controller
    {
        private static List<Payment> payments = new List<Payment>()
        {
            new Payment 
            { 
                Id = Guid.Parse("4895b6cc-4a78-43ee-8aa5-4424a7a435f5"), 
                Bill = new () 
                { 
                    Id = Guid.Parse("91046f47-b6bf-46d9-8c6e-77ff27aa9661"), 
                    Title = "Bill Ref #101", 
                    DueDay = 10, 
                    RefMonth = 9, 
                    Recurrent = true 
                },
                PaymentDate = new DateOnly(2023, 9, 18), 
                RefMonth = 9,
                Amount = 165.78M
            },
            new Payment { 
                Id = Guid.Parse("ecd78c14-21d6-4b01-8578-48d29120e9cc"), 
                Bill = new () 
                { 
                    Id = Guid.Parse("47f6ea7b-e1b2-4377-bb29-deae0ce329e0"), 
                    Title = "Bill Ref #207", 
                    DueDay = 5, 
                    RefMonth = 8, 
                    Recurrent = true 
                },
                PaymentDate = new DateOnly(2023, 8, 20), 
                RefMonth = 8,
                Amount = 201.78M
            },
            new Payment { 
                Id = Guid.Parse("0e1c1010-d534-4879-88ee-afc3f8a1df40"), 
                Bill = new () 
                { 
                    Id = Guid.Parse("cbaddf25-aab4-4d27-8cbb-14130ea5c015"), 
                    Title = "Bill Ref #305", 
                    DueDay = 8, 
                    RefMonth = 9, 
                    Recurrent = true 
                },
                PaymentDate = new DateOnly(2023, 9, 13), 
                RefMonth = 9,
                Amount = 185.60M
            },
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(payments);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("CreateOrEdit");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(Guid id)
        {
            return View("CreateOrEdit");
        }
    }
}