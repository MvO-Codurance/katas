namespace SalarySlip;

public class NationalInsurance
{
    private const decimal LowRateThreshold = 8060.00m;
    private const decimal HighRateThreshold = 43_000.00m;
    
    private const decimal LowRate = 0.12m;
    private const decimal HighRate = 0.02m;
    
    public decimal AnnualContribution { get; private set; }
    
    public NationalInsurance(decimal grossAnnualSalary)
    {
        AnnualContribution = CalculateAnnualContribution(grossAnnualSalary);
    }
    
    private static decimal CalculateAnnualContribution(decimal grossAnnualSalary)
    {
        /*
            | 0.00 >>>>>>>> | 8,060.00 >>>>>>>> | 43,000.00 >>>>>>>>
            |       0%      |       20%         |       2%  
        */
        
        var lowRateAmount = Math.Max(
            Math.Min(grossAnnualSalary, HighRateThreshold) - LowRateThreshold,
            0.00m);
        var lowRatePayable = lowRateAmount * LowRate;

        var highRateAmount = Math.Max(
            grossAnnualSalary - HighRateThreshold,
            0.00m);
        var highRatePayable = highRateAmount * HighRate;

        return lowRatePayable + highRatePayable;
    }
}