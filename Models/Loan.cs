namespace Andisbank.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int UserId { get; set; }
        public int LoanTypeId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public int TermMonths { get; set; }
        public double InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public double Balance { get; set; }
        public string Status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
