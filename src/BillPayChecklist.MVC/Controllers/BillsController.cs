using BillPayChecklist.Application.Entities;
using BillPayChecklist.Application.Enums;
using BillPayChecklist.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BillPayChecklist.MVC.Controllers
{
    [Route("bills")]
    public class BillsController : Controller
    {
        private static List<BillViewModel> bills = new List<BillViewModel>()
        {
            new BillViewModel { Id = Guid.Parse("91046f47-b6bf-46d9-8c6e-77ff27aa9661"), Title = "Bill Ref #101", DueDay = 10, RefMonth = 9, Recurrent = false },
            new BillViewModel { Id = Guid.Parse("47f6ea7b-e1b2-4377-bb29-deae0ce329e0"), Title = "Bill Ref #207", DueDay = 5, RefMonth = 8, Recurrent = true },
            new BillViewModel { Id = Guid.Parse("cbaddf25-aab4-4d27-8cbb-14130ea5c015"), Title = "Bill Ref #305", DueDay = 8, RefMonth = 9, Recurrent = true },
        };

        private void setDueDaySelectList(int? id = null)
        {
            var dueDayList = Enumerable.Range(1, 31).Select(s => new SelectListItem { Value = $"{s}", Text = s.ToString("D2"), Selected = s == id }).ToList();

            dueDayList.Insert(0, new SelectListItem { Text = "Day" });

            ViewBag.DueDayList = dueDayList;
        }

        private void setMonthSelectList(int? id = null)
        {
            var monthList = Enumerable.Range(1, 12).Select(x => new SelectListItem { Value = $"{x}", Text = $"{(MonthEnum)x}", Selected = x == id }).ToList();

            monthList.Insert(0, new SelectListItem { Text = "Month" });

            ViewBag.MonthList = monthList;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(bills);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            setMonthSelectList();
            setDueDaySelectList();

            return View("CreateOrEdit", new BillViewModel());
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(Guid id)
        {
            var bill = bills.Find(b => b.Id == id);

            setMonthSelectList(bill!.RefMonth);
            setDueDaySelectList(bill!.DueDay);

            return View("CreateOrEdit", bill);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var bill = bills.Find(b => b.Id == id);

            return View(bill);
        }
    }
}