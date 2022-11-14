using FluentAssertions;
using Xunit;

namespace SalarySlip.Tests;

public class TaxCalculatorShould
{
    [Theory]
    [InlineAutoNSubstituteData(5000.00, 5000.00)]
    [InlineAutoNSubstituteData(9060.00, 9060.00)]
    [InlineAutoNSubstituteData(11000.00, 11000.00)]
    [InlineAutoNSubstituteData(12000.00, 11000.00)]
    public void Calculate_The_Annual_Tax_Free_Allowance(
        decimal grossAnnualSalary,
        decimal expectedTaxableIncome)
    {
        new TaxCalculator(grossAnnualSalary).AnnualTaxFreeAllowance.Should().Be(expectedTaxableIncome);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(5000.00, 0.00)]
    [InlineAutoNSubstituteData(11000.00, 0.00)]
    [InlineAutoNSubstituteData(12000.00, 1000.00)]
    [InlineAutoNSubstituteData(30000.00, 19000.00)]
    public void Calculate_The_Annual_Taxable_Income(
        decimal grossAnnualSalary,
        decimal expectedTaxableIncome)
    {
        new TaxCalculator(grossAnnualSalary).AnnualTaxableIncome.Should().Be(expectedTaxableIncome);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(5000.00, 0.00)]
    [InlineAutoNSubstituteData(11000.00, 0.00)]
    [InlineAutoNSubstituteData(12000.00, 200.00)]
    [InlineAutoNSubstituteData(30000.00, 3800.00)]
    public void Calculate_The_Annual_Tax_Payable(
        decimal grossAnnualSalary,
        decimal expectedTaxPayable)
    {
        new TaxCalculator(grossAnnualSalary).AnnualTaxPayable.Should().Be(expectedTaxPayable);
    }
}