namespace Andisbank.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
    }
}
