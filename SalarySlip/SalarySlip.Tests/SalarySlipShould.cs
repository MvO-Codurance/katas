using FluentAssertions;
using Xunit;

namespace SalarySlip.Tests;

public class SalarySlipShould
{
    [Theory]
    [InlineAutoNSubstituteData(5000.00, 416.67)]
    [InlineAutoNSubstituteData(6000.00, 500.00)]
    [InlineAutoNSubstituteData(9060.00, 755.00)]
    [InlineAutoNSubstituteData(11000.00, 916.67)]
    [InlineAutoNSubstituteData(12000.00, 1000.00)]
    [InlineAutoNSubstituteData(30000.00, 2500.00)]
    public void Calculate_Gross_Monthly_Salary(
        decimal grossAnnualSalary,
        decimal expectedGrossMonthlySalary,
        string employeeId,
        string employeeName)
    {
        var employee = new Employee(employeeId, employeeName, grossAnnualSalary);
        var nationalInsurance = new NationalInsurance(grossAnnualSalary);

        new SalarySlip(employee, nationalInsurance).GrossMonthlySalary.Should().Be(expectedGrossMonthlySalary);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(5000.00, 0.00)]
    [InlineAutoNSubstituteData(6000.00, 0.00)]
    [InlineAutoNSubstituteData(9060.00, 10.00)]
    [InlineAutoNSubstituteData(11000.00, 29.40)]
    [InlineAutoNSubstituteData(12000.00, 39.40)]
    [InlineAutoNSubstituteData(30000.00, 219.40)]
    public void Calculate_Monthly_Nation_Insurance_Contribution(
        decimal grossAnnualSalary,
        decimal expectedMonthlyContribution,
        string employeeId,
        string employeeName)
    {
        var employee = new Employee(employeeId, employeeName, grossAnnualSalary);
        var nationalInsurance = new NationalInsurance(grossAnnualSalary);

        new SalarySlip(employee, nationalInsurance).NationalInsuranceContribution.Should().Be(expectedMonthlyContribution);
    }
}