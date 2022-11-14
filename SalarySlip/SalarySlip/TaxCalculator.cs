namespace SalarySlip;

public class TaxCalculator
{
    private const decimal TaxFreeAllowance = 11_000.00m;
    private const decimal TaxRate = 0.20m;
    
    public decimal AnnualTaxFreeAllowance { get; }
    public decimal AnnualTaxableIncome { get; }
    public decimal AnnualTaxPayable { get; }

    public TaxCalculator(decimal grossAnnualSalary)
    {
        AnnualTaxFreeAllowance = Math.Min(grossAnnualSalary, TaxFreeAllowance);

        var taxableIncome = grossAnnualSalary - TaxFreeAllowance;
        AnnualTaxableIncome = Math.Max(taxableIncome, 0.00m);

        AnnualTaxPayable = AnnualTaxableIncome * TaxRate;
    }
}