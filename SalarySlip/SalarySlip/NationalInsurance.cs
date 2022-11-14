namespace SalarySlip;

public class NationalInsurance
{
    private const decimal MinimumSalaryLimit = 8060.00m;
    private const decimal ContributionRate = 0.12m;
    
    public decimal AnnualContribution { get; private set; }
    
    public NationalInsurance(decimal grossAnnualSalary)
    {
        var amountAboveMinimumLimit = grossAnnualSalary - MinimumSalaryLimit;
        
        AnnualContribution = amountAboveMinimumLimit <= 0 ? 0 : amountAboveMinimumLimit * ContributionRate;
    }
}