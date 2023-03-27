using Inbank.Model;
using Inbank.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Inbank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        
        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GetLoanDecision([FromQuery] Person person) //Takes in the values and uses a helper class that calculates the loan.
        {
            Calculator calculator = new Calculator();
            string? personalCode = person.personalCode;
            double loanAmount = person.loanAmount;
            int loanPeriod = person.loanPeriod;
            string loanDecision = calculator.LoanApplication(personalCode, loanAmount, loanPeriod);
            _context.Add(person);
                 _context.SaveChanges();
            return Ok(loanDecision);
        }
    }
}