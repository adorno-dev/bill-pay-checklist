using System.ComponentModel.DataAnnotations;

namespace BillPayChecklist.MVC.ViewModels
{
    public class BillViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int DueDay { get; set; }
        [Required]
        public int RefMonth { get; set; }
        public bool Recurrent { get; set; }

        public ICollection<PaymentViewModel>? Payments { get; set; }
    }
}