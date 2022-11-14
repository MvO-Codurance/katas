using FluentAssertions;

namespace SalarySlip.Specs.Steps;

[Binding]
public class SalarySlipDefinitions
{
#pragma warning disable CS8618  // Non-nullable field '_employee' is uninitialized. Consider declaring the field as nullable
    private Employee _employee;
    private SalarySlipGenerator _generator;
    private SalarySlip _salarySlip;
#pragma warning restore CS8618
    
    [Given(@"an employee with a gross annual salary of (.*)")]
    public void GivenAnEmployeeWithAGrossAnnualSalaryOf(decimal grossAnnualSalary)
    {
        _employee = new Employee("12345", "John J Doe", grossAnnualSalary);
    }

    [When(@"we generate a salary slip for the employee")]
    public void WhenWeGenerateASalarySlipForTheEmployee()
    {
        _generator = new SalarySlipGenerator();
        _salarySlip = _generator.GenerateFor(_employee);
    }

    [Then(@"the salary slip should contain a gross monthly salary of (.*)")]
    public void ThenTheSalarySlipShouldContainAGrossMonthlySalaryOf(decimal grossMonthlySalary)
    {
        _salarySlip.GrossMonthlySalary.Should().Be(grossMonthlySalary);
    }

    [Then(@"national insurance contribution of (.*)")]
    public void ThenNationalInsuranceContributionOf(decimal nationalInsurance)
    {
        _salarySlip.NationalInsuranceContribution.Should().Be(nationalInsurance);
    }
}