using Andisbank.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Andisbank.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class LoanController : ControllerBase
    {
        [HttpGet("loans")]
        public IActionResult GetLoans()
        {
            Log.Information("Request to get all loans");
            return Ok(loans);
        }

        [HttpGet("loans/details/{loanId}")]
        public IActionResult GetLoanDetails(int loanId)
        {
            Log.Information("Request to get loan details for LoanId: {LoanId}", loanId);

            // Obtener el préstamo por ID
            var loan = loans.FirstOrDefault(l => l.LoanId == loanId);

            if (loan == null)
            {
                Log.Warning("Loan with LoanId: {LoanId} not found", loanId);
                return NotFound("Préstamo no encontrado");
            }

            // Retornar préstamo
            Log.Debug("Loan details retrieved for LoanId: {LoanId}", loanId);
            return Ok(loan);
        }

        [HttpPost("loans/apply")]
        public IActionResult LoanApplication([FromBody] Application application)
        {
            if (!ModelState.IsValid)
            {
                Log.Warning("Invalid loan application data received");
                return BadRequest("Faltan datos");
            }

            Log.Information("Loan application submitted successfully for UserId: {UserId}", application.UserId);
            return Ok("Aplicación a préstamo exitosa");
        }

        [HttpGet("loans/user/{userId}")]
        public IActionResult GetUserLoans(int userId)
        {
            Log.Information("Request to get loans for UserId: {UserId}", userId);

            // Obtener el usuario por ID
            var user = users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                Log.Warning("User with UserId: {UserId} not found", userId);
                return NotFound("Usuario no encontrado");
            }

            // Filtrar los préstamos por UserId
            var userLoans = loans.Where(l => l.UserId == userId).ToList();

            if (userLoans.Count == 0)
            {
                Log.Information("UserId: {UserId} has no loans", userId);
                return NotFound("El usuario no tiene préstamos");
            }

            // Retornar préstamos asociados al usuario
            Log.Debug("Loans retrieved for UserId: {UserId}", userId);
            return Ok(userLoans);
        }

        [HttpPatch("loans/payments")]
        public IActionResult LoanPayment([FromBody] Payment payment)
        {
            if (!ModelState.IsValid)
            {
                Log.Warning("Invalid payment data received");
                return BadRequest("Faltan datos");
            }

            Log.Information("Payment successful for LoanId: {LoanId}", payment.LoanId);
            return Ok("Pago realizado con éxito");
        }

        [HttpPost("loans/simulate")]
        public IActionResult LoanSimulate([FromBody] Simulation simulation)
        {
            if (!ModelState.IsValid)
            {
                Log.Warning("Invalid simulation data received");
                return BadRequest("Faltan datos");
            }

            Log.Information("Loan simulation completed successfully for amount: {Amount}", simulation.Amount);
            return Ok("Simulación exitosa");
        }

        // Datos mock de usuarios
        private static List<User> users = new List<User>
        {
            new User
            {
                UserId = 12345,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "+123456789",
                Address = "123 Main St, Springfield, USA"
            },
            new User
            {
                UserId = 67890,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Phone = "+987654321",
                Address = "456 Elm St, Springfield, USA"
            },
            new User
            {
                UserId = 11223,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                Phone = "+564738291",
                Address = "789 Oak St, Springfield, USA"
            },
            new User
            {
                UserId = 33445,
                FirstName = "Bob",
                LastName = "Williams",
                Email = "bob.williams@example.com",
                Phone = "+345672189",
                Address = "101 Pine St, Springfield, USA"
            }
        };

        // Datos mock de préstamos
        private static List<Loan> loans = new List<Loan>
        {
            new Loan
            {
                LoanId = 1,
                UserId = 12345,
                LoanTypeId = 1,
                Amount = 15000,
                Currency = "USD",
                TermMonths = 36,
                InterestRate = 5.5,
                MonthlyPayment = 452.12,
                Balance = 13500,
                Status = "active",
                startDate = DateTime.Parse("2024-09-04T00:00:00Z"),
                endDate = DateTime.Parse("2027-09-04T00:00:00Z")
            },
            new Loan
            {
                LoanId = 2,
                UserId = 67890,
                LoanTypeId = 2,
                Amount = 200000,
                Currency = "USD",
                TermMonths = 240,
                InterestRate = 3.5,
                MonthlyPayment = 1164.12,
                Balance = 198500,
                Status = "active",
                startDate = DateTime.Parse("2024-09-10T00:00:00Z"),
                endDate = DateTime.Parse("2044-09-10T00:00:00Z")
            },
            new Loan
            {
                LoanId = 3,
                UserId = 11223,
                LoanTypeId = 3,
                Amount = 25000,
                Currency = "USD",
                TermMonths = 60,
                InterestRate = 4.2,
                MonthlyPayment = 463.25,
                Balance = 24800,
                Status = "active",
                startDate = DateTime.Parse("2024-10-01T00:00:00Z"),
                endDate = DateTime.Parse("2029-10-01T00:00:00Z")
            },
            new Loan
            {
                LoanId = 4,
                UserId = 33445,
                LoanTypeId = 4,
                Amount = 50000,
                Currency = "USD",
                TermMonths = 120,
                InterestRate = 6.0,
                MonthlyPayment = 555.56,
                Balance = 49500,
                Status = "active",
                startDate = DateTime.Parse("2024-08-01T00:00:00Z"),
                endDate = DateTime.Parse("2034-08-01T00:00:00Z")
            }
        };
    }
}
