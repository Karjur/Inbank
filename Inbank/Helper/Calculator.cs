namespace Inbank.Helper
{
    public class Calculator
    {
        const int minAmount = 2000;
        const int maxAmount = 10000;
        const int minPeriod = 12;
        const int maxPeriod = 60;
        public string LoanApplication(string personalCode, double loanAmount, int loanPeriod)
        {
            double highestAmount = 2000;
            int highestPeriod = 12;
            double creditModifier = calculateCreditModifier(personalCode);
            if (creditModifier == 0) return "Person has debt. Can't give out a loan";
            for (int amount = minAmount; amount <= maxAmount; amount++) //Checks every possible loan amount and period between the constraints.
            {
                for (int period = minPeriod; period <= maxPeriod; period++) 
                {
                    double creditScore = (creditModifier / amount) * period;
                    if (creditScore > 1) 
                    {
                        if (amount > highestAmount) 
                        {
                            highestAmount = amount;
                            highestPeriod = period;
                        }
                    }
                }
            }
            if (highestAmount == 0) 
            {
                return "Sorry, we couldn't find a loan that meets your requirements.";
            }
            else 
            {
                return $"You can get a loan of {highestAmount} € for {highestPeriod} months.";
            }
        }
        private double calculateCreditModifier(string personalCode) //As i understood there is only 4 personal codes, so i just set the modifier based on the last number.
        {
            char secondToLastNr = FindSecondToLastChar(personalCode);
            double creditModifier = 0; //As we have 3 segments that are not in debt
            if(secondToLastNr == '7')
            {
                creditModifier = 100;
            }
            else if(secondToLastNr == '8')
            {
                creditModifier = 300;
            }
            else if(secondToLastNr == '9')
            {
                creditModifier = 1000;
            }
            return creditModifier;
        }

        private char FindSecondToLastChar(string personalCode)
        {
            char c = personalCode[personalCode.Length - 2];
            return c;
        }
    }
}