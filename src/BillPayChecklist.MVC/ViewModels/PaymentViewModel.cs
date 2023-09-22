namespace BillPayChecklist.MVC.ViewModels
{
    public class PaymentViewModel
    {
        public Guid? Id { get; set; }
        public DateOnly PaymentDate { get; set; }
        public int RefMonth { get; set; }
        public decimal? Amount { get; set; }     
        public string? Comment { get; set; }

        public Guid BillId { get; set; }
        public BillViewModel? Bill { get; set; }
    }
}