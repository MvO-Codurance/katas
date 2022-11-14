namespace SalarySlip;

public class SalarySlipGenerator
{
    public SalarySlip GenerateFor(Employee employee)
    {
        var nationalInsurance = new NationalInsurance(employee.GrossAnnualSalary);
        return new SalarySlip(employee, nationalInsurance);
    }
}