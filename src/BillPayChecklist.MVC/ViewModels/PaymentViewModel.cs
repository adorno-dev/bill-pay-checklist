using System.ComponentModel.DataAnnotations;

namespace BillPayChecklist.MVC.ViewModels
{
    public class PaymentViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public DateOnly PaymentDate { get; set; }
        [Required]
        public int RefMonth { get; set; }
        [Required]
        public decimal? Amount { get; set; }     
        public string? Comment { get; set; }

        [Required]
        public Guid BillId { get; set; }
        public BillViewModel? Bill { get; set; }
    }
}