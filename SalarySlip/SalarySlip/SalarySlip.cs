namespace SalarySlip;

public class SalarySlip
{
    private readonly Employee _employee;
    private readonly NationalInsurance _nationalInsurance;

    public string Id => _employee.Id;
    public string Name => _employee.Name;
    public decimal GrossMonthlySalary => ToMonthlyCurrency(_employee.GrossAnnualSalary);
    public decimal NationalInsuranceContribution => ToMonthlyCurrency(_nationalInsurance.AnnualContribution);

    public SalarySlip(
        Employee employee, 
        NationalInsurance nationalInsurance)
    {
        _employee = employee ?? throw new ArgumentNullException(nameof(employee));
        _nationalInsurance = nationalInsurance ?? throw new ArgumentNullException(nameof(nationalInsurance));
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