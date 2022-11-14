using AutoFixture;
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
    [InlineAutoNSubstituteData(45000.00, 3750.00)]
    public void Calculate_Gross_Monthly_Salary(
        decimal grossAnnualSalary,
        decimal expectedGrossMonthlySalary)
    {
        GetSalarySlip(grossAnnualSalary).GrossMonthlySalary.Should().Be(expectedGrossMonthlySalary);
    }

    [Theory]
    [InlineAutoNSubstituteData(5000.00, 0.00)]
    [InlineAutoNSubstituteData(6000.00, 0.00)]
    [InlineAutoNSubstituteData(9060.00, 10.00)]
    [InlineAutoNSubstituteData(11000.00, 29.40)]
    [InlineAutoNSubstituteData(12000.00, 39.40)]
    [InlineAutoNSubstituteData(30000.00, 219.40)]
    [InlineAutoNSubstituteData(45000.00, 352.73)]
    public void Calculate_Monthly_National_Insurance_Contribution(
        decimal grossAnnualSalary,
        decimal expectedMonthlyContribution)
    {
        GetSalarySlip(grossAnnualSalary).NationalInsuranceContribution.Should().Be(expectedMonthlyContribution);
    }

    [Theory]
    [InlineAutoNSubstituteData(5000.00, 416.67)]
    [InlineAutoNSubstituteData(6000.00, 500.00)]
    [InlineAutoNSubstituteData(9060.00, 755.00)]
    [InlineAutoNSubstituteData(11000.00, 916.67)]
    [InlineAutoNSubstituteData(12000.00, 916.67)]
    [InlineAutoNSubstituteData(30000.00, 916.67)]
    [InlineAutoNSubstituteData(45000.00, 916.67)]
    public void Calculate_Monthly_Tax_Free_Allowance(
        decimal grossAnnualSalary,
        decimal expectedMonthlyAllowance)
    {
        GetSalarySlip(grossAnnualSalary).TaxFreeAllowance.Should().Be(expectedMonthlyAllowance);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(5000.00, 0.00)]
    [InlineAutoNSubstituteData(11000.00, 0.00)]
    [InlineAutoNSubstituteData(12000.00, 83.33)]
    [InlineAutoNSubstituteData(30000.00, 1583.33)]
    [InlineAutoNSubstituteData(45000.00, 2833.33)]
    public void Calculate_Monthly_Taxable_Income(
        decimal grossAnnualSalary,
        decimal expectedMonthlyTaxableIncome)
    {
        GetSalarySlip(grossAnnualSalary).TaxableIncome.Should().Be(expectedMonthlyTaxableIncome);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(5000.00, 0.00)]
    [InlineAutoNSubstituteData(11000.00, 0.00)]
    [InlineAutoNSubstituteData(12000.00, 16.67)]
    [InlineAutoNSubstituteData(30000.00, 316.67)]
    [InlineAutoNSubstituteData(45000.00, 600.00)]
    public void Calculate_Monthly_Tax_Payable(
        decimal grossAnnualSalary,
        decimal expectedMonthlyTaxPayable)
    {
        GetSalarySlip(grossAnnualSalary).TaxPayable.Should().Be(expectedMonthlyTaxPayable);
    }

    private static SalarySlip GetSalarySlip(decimal grossAnnualSalary)
    {
        var fixture = new Fixture();
        var employee = new Employee(fixture.Create<string>(), fixture.Create<string>(), grossAnnualSalary);
        var nationalInsurance = new NationalInsurance(grossAnnualSalary);
        var taxCalculator = new TaxCalculator(grossAnnualSalary);
        
        return new SalarySlip(employee, nationalInsurance, taxCalculator);
    }
}