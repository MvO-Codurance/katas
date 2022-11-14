namespace SalarySlip;

public class TaxCalculator
{
    private const decimal LowRateThreshold = 11_000.00m;
    private const decimal MidRateThreshold = 43_000.00m;
    
    private const decimal LowRate = 0.20m;
    private const decimal MidRate = 0.40m;
    
    public decimal AnnualTaxFreeAllowance { get; }
    public decimal AnnualTaxableIncome { get; }
    public decimal AnnualTaxPayable { get; }

    public TaxCalculator(decimal grossAnnualSalary)
    {
        AnnualTaxFreeAllowance = CalculateAnnualTaxFreeAllowance(grossAnnualSalary);
        AnnualTaxableIncome = CalculateAnnualTaxableIncome(grossAnnualSalary);
        AnnualTaxPayable = CalculateAnnualTaxPayable(grossAnnualSalary);
    }

    private static decimal CalculateAnnualTaxFreeAllowance(decimal grossAnnualSalary)
    {
        return Math.Min(grossAnnualSalary, LowRateThreshold);
    }

    private static decimal CalculateAnnualTaxableIncome(decimal grossAnnualSalary)
    {
        var taxableIncome = grossAnnualSalary - LowRateThreshold;
        return Math.Max(taxableIncome, 0.00m);
    }

    private static decimal CalculateAnnualTaxPayable(decimal grossAnnualSalary)
    {
        /*
            | 0.00 >>>>>>>> | 11,000.00 >>>>>>>> | 43,000.00 >>>>>>>>
            |       0%      |       20%          |       40%  
        */
        
        var lowRateTaxableAmount = Math.Max(
            Math.Min(grossAnnualSalary, MidRateThreshold) - LowRateThreshold,
            0.00m);
        var lowRateTaxPayable = lowRateTaxableAmount * LowRate;

        var midRateTaxableAmount = Math.Max(
            grossAnnualSalary - MidRateThreshold,
            0.00m);
        var midRateTaxPayable = midRateTaxableAmount * MidRate;

        return lowRateTaxPayable + midRateTaxPayable;
    }
}