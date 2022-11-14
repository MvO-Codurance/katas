using FluentAssertions;

namespace SalarySlip.Specs.Steps;

[Binding]
public class SalarySlipDefinitions
{
    private Employee? _employee;
    private SalarySlipGenerator? _generator;
    private SalarySlip? _salarySlip;
    
    [Given(@"an employee with a gross annual salary of (.*)")]
    public void GivenAnEmployeeWithAGrossAnnualSalaryOf(decimal grossAnnualSalary)
    {
        _employee = new Employee("12345", "John J Doe", grossAnnualSalary);
    }

    [When(@"we generate a salary slip for the employee")]
    public void WhenWeGenerateASalarySlipForTheEmployee()
    {
        _generator = new SalarySlipGenerator();
        _salarySlip = _generator.GenerateFor(_employee!);
    }

    [Then(@"the salary slip should contain a gross monthly salary of (.*)")]
    public void ThenTheSalarySlipShouldContainAGrossMonthlySalaryOf(decimal grossMonthlySalary)
    {
        _salarySlip!.GrossMonthlySalary.Should().Be(grossMonthlySalary);
    }
}