namespace SalarySlip;

public class TaxCalculator
{
    private const decimal LowTaxRateThreshold = 11_000.00m;
    private const decimal MidTaxRateThreshold = 43_000.00m;
    private const decimal HighTaxRateThreshold = 150_000.00m;
    
    private const decimal LowRateTaxFreeAllowanceThreshold = 11_000.00m;
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
        var taxFreeAllowance = LowRateTaxFreeAllowanceThreshold;
        
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
        var lowRateTaxPayable = CalculateLowRateTaxPayable(grossAnnualSalary);
        var midRateTaxPayable = CalculateMidRateTaxPayable(grossAnnualSalary);
        var highRateTaxPayable = CalculateHighRateTaxPayable(grossAnnualSalary);

        return lowRateTaxPayable + midRateTaxPayable + highRateTaxPayable;
    }

    private decimal CalculateLowRateTaxPayable(decimal grossAnnualSalary)
    {
        decimal taxPayable = 0;
        if (grossAnnualSalary <= LowTaxRateThreshold) return taxPayable;
        
        var taxFreeDifference = LowRateTaxFreeAllowanceThreshold - AnnualTaxFreeAllowance;
        var taxableAmount = Math.Min(grossAnnualSalary, MidTaxRateThreshold);
        taxableAmount = taxableAmount - AnnualTaxFreeAllowance - taxFreeDifference;
        taxPayable = taxableAmount * LowTaxRate;

        return taxPayable;
    }

    private decimal CalculateMidRateTaxPayable(decimal grossAnnualSalary)
    {
        decimal taxPayable = 0;
        if (grossAnnualSalary <= MidTaxRateThreshold) return taxPayable;
        
        var taxFreeDifference = LowRateTaxFreeAllowanceThreshold - AnnualTaxFreeAllowance;
        var taxableAmount = Math.Min(grossAnnualSalary, HighTaxRateThreshold);
        taxableAmount -= MidTaxRateThreshold;
        taxableAmount += taxFreeDifference;
        
        taxPayable = taxableAmount * MidTaxRate;
        
        return taxPayable;
    }

    private decimal CalculateHighRateTaxPayable(decimal grossAnnualSalary)
    {
        decimal taxPayable = 0;
        if (grossAnnualSalary <= HighTaxRateThreshold) return taxPayable;
        
        var taxableAmount = grossAnnualSalary - HighTaxRateThreshold;
        taxPayable = taxableAmount * HighTaxRate;
        
        return taxPayable;
    }
}