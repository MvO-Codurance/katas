namespace SalarySlip;

public class SalarySlipGenerator
{
    public SalarySlip GenerateFor(Employee employee)
    {
        decimal grossMonthlySalary = ToCurrency(employee.GrossAnnualSalary / 12);
        
        return new SalarySlip(employee.Id, employee.Name, grossMonthlySalary);
    }

    private static decimal ToCurrency(decimal value)
    {
        return Math.Round(value, 2, MidpointRounding.ToEven);
    }
}