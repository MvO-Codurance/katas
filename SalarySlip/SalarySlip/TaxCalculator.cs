namespace SalarySlip;

public class TaxCalculator
{
    private const decimal TaxFreeAllowance = 11_000.00m;
    
    public decimal AnnualTaxFreeAllowance { get; }

    public TaxCalculator(decimal grossAnnualSalary)
    {
        AnnualTaxFreeAllowance = Math.Min(grossAnnualSalary, TaxFreeAllowance);
    }
}