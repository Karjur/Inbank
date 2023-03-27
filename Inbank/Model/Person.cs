using System.ComponentModel.DataAnnotations.Schema;

namespace Inbank.Model
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? personalCode { get; init; }
        public double loanAmount { get ; set; }
        public int loanPeriod { get; set; } 
    }
}