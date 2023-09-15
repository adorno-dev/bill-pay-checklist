namespace BillPayChecklist.Application.Entities
{
    public class Bill
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int DueDay { get; set; }
        public int RefMonth { get; set; }
        public bool Recurrent { get; set; }

        public ICollection<Payment>? Payments { get; set; }
    }
}