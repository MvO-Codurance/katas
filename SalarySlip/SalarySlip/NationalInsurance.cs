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
        var lowRatePayable = CalculateLowRatePayable(grossAnnualSalary);
        var highRatePayable = CalculateHighRatePayable(grossAnnualSalary);

        return lowRatePayable + highRatePayable;
    }

    private static decimal CalculateLowRatePayable(decimal grossAnnualSalary)
    {
        decimal taxPayable = 0;
        if (grossAnnualSalary <= LowRateThreshold) return taxPayable;
        
        var taxableAmount = Math.Min(grossAnnualSalary, HighRateThreshold) - LowRateThreshold;
        taxPayable = taxableAmount * LowRate;
        
        return taxPayable;
    }

    private static decimal CalculateHighRatePayable(decimal grossAnnualSalary)
    {
        decimal taxPayable = 0;
        if (grossAnnualSalary <= HighRateThreshold) return taxPayable;
        
        var taxableAmount = grossAnnualSalary - HighRateThreshold;
        taxPayable = taxableAmount * HighRate;
        
        return taxPayable;
    }
}