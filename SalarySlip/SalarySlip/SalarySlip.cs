namespace SalarySlip;

public class SalarySlip
{
    private readonly Employee _employee;
    private readonly NationalInsurance _nationalInsurance;
    private readonly TaxCalculator _taxCalculator;

    public string Id => _employee.Id;
    public string Name => _employee.Name;
    public decimal GrossMonthlySalary => ToMonthlyCurrency(_employee.GrossAnnualSalary);
    public decimal NationalInsuranceContribution => ToMonthlyCurrency(_nationalInsurance.AnnualContribution);
    public decimal TaxFreeAllowance => ToMonthlyCurrency(_taxCalculator.AnnualTaxFreeAllowance);
    public object TaxableIncome => ToMonthlyCurrency(_taxCalculator.AnnualTaxableIncome);

    public SalarySlip(
        Employee employee, 
        NationalInsurance nationalInsurance,
        TaxCalculator taxCalculator)
    {
        _employee = employee ?? throw new ArgumentNullException(nameof(employee));
        _nationalInsurance = nationalInsurance ?? throw new ArgumentNullException(nameof(nationalInsurance));
        _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
    }
    
    private static decimal ToMonthlyCurrency(decimal value)
    {
        return ToCurrency(value / 12);
    }
    
    private static decimal ToCurrency(decimal value)
    {
        return Math.Round(value, 2, MidpointRounding.ToEven);
    }
}