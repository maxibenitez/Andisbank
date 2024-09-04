namespace Andisbank.Models
{
    public class Simulation
    {
        public string SimulationId { get; set; }
        public int UserId { get; set; }
        public int LoanTypeId { get; set; }
        public double Amount { get; set; }
        public string Currency {  get; set; }
        public int TermMonths { get; set; }
        public double InterestRate { get; set; }
        public double MonthlyPayment { get; set; }
        public double TotalPayment { get; set; }
    }
}
