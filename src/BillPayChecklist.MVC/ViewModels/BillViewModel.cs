namespace BillPayChecklist.MVC.ViewModels
{
    public class BillViewModel
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public int DueDay { get; set; }
        public int RefMonth { get; set; }
        public bool Recurrent { get; set; }

        public ICollection<PaymentViewModel>? Payments { get; set; }
    }
}