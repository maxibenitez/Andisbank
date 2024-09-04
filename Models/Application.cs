namespace Andisbank.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public int LoanTypeId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public int TermMonths { get; set; }
        public double InterestRate { get; set; }
        public string Purpose { get; set; }
        public string Collateral { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
