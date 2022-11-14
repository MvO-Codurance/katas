namespace SalarySlip;

public class TaxCalculator
{
    private const decimal LowTaxRateThreshold = 11_000.00m;
    private const decimal MidTaxRateThreshold = 43_000.00m;
    private const decimal HighTaxRateThreshold = 150_000.00m;
    
    private const decimal HighRateTaxFreeAllowanceThreshold = 100_000.00m;
    
    private const decimal LowTaxRate = 0.20m;
    private const decimal MidTaxRate = 0.40m;
    private const decimal HighTaxRate = 0.45m;
    
    public decimal AnnualTaxFreeAllowance { get; }
    public decimal AnnualTaxableIncome { get; }
    public decimal AnnualTaxPayable { get; }

    public TaxCalculator(decimal grossAnnualSalary)
    {
        AnnualTaxFreeAllowance = CalculateAnnualTaxFreeAllowance(grossAnnualSalary);
        AnnualTaxableIncome = CalculateAnnualTaxableIncome(grossAnnualSalary);
        AnnualTaxPayable = CalculateAnnualTaxPayable(grossAnnualSalary);
    }

    private decimal CalculateAnnualTaxFreeAllowance(decimal grossAnnualSalary)
    {
        var taxFreeAllowance = LowTaxRateThreshold;
        
        // decrease tax free allowance by £1 for every £2 earned over the high threshold
        var amountEarnedOverHighRateThreshold = grossAnnualSalary - HighRateTaxFreeAllowanceThreshold;
        if (amountEarnedOverHighRateThreshold > 0)
        {
            var amountToDecreaseTaxFreeAllowance = amountEarnedOverHighRateThreshold / 2;
            taxFreeAllowance -= amountToDecreaseTaxFreeAllowance;
            if (taxFreeAllowance < 0)
            {
                taxFreeAllowance = 0;
            }
        }

        return Math.Min(grossAnnualSalary, taxFreeAllowance);
    }

    private decimal CalculateAnnualTaxableIncome(decimal grossAnnualSalary)
    {
        var taxableIncome = grossAnnualSalary - AnnualTaxFreeAllowance;
        return Math.Max(taxableIncome, 0.00m);
    }

    private decimal CalculateAnnualTaxPayable(decimal grossAnnualSalary)
    {
        /*
            | 0.00 >>>>>>>> | 11,000.00 >>>>>>>> | 43,000.00 >>>>>>>>
            |       0%      |       20%          |       40%  
        */

        // adjust the mid rate threshold by the amount that the tax free allowance was reduced
        // because of earnings over HighRateThreshold
        var adjustedMidRateThreshold = MidTaxRateThreshold - (LowTaxRateThreshold - AnnualTaxFreeAllowance);
        
        var lowRateTaxableAmount = Math.Max(
            Math.Min(grossAnnualSalary, adjustedMidRateThreshold) - AnnualTaxFreeAllowance,
            0.00m);
        var lowRateTaxPayable = lowRateTaxableAmount * LowTaxRate;

        var midRateTaxableAmount = Math.Max(
            Math.Min(grossAnnualSalary, HighTaxRateThreshold) - adjustedMidRateThreshold,
            0.00m);
        var midRateTaxPayable = midRateTaxableAmount * MidTaxRate;
        
        var highRateTaxableAmount = Math.Max(
            grossAnnualSalary - HighTaxRateThreshold,
            0.00m);
        var highRateTaxPayable = highRateTaxableAmount * HighTaxRate;
        
        return lowRateTaxPayable + midRateTaxPayable + highRateTaxPayable;
    }
}