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
    [InlineAutoNSubstituteData(45000.00, 11000.00)]
    [InlineAutoNSubstituteData(101_000.00, 10_500.00)]
    [InlineAutoNSubstituteData(111_000.00, 5_500.00)]
    [InlineAutoNSubstituteData(122_000.00, 0.00)]
    [InlineAutoNSubstituteData(150_000.00, 0.00)]
    [InlineAutoNSubstituteData(160_000.00, 0.00)]
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
    [InlineAutoNSubstituteData(45000.00, 34000.00)]
    [InlineAutoNSubstituteData(101_000.00, 90_500.00)]
    [InlineAutoNSubstituteData(111_000.00, 105_500.00)]
    [InlineAutoNSubstituteData(122_000.00, 122_000.00)]
    [InlineAutoNSubstituteData(150_000.00, 150_000.00)]
    [InlineAutoNSubstituteData(160_000.00, 160_000.00)]
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
    [InlineAutoNSubstituteData(45000.00, 7200.00)]
    [InlineAutoNSubstituteData(101_000.00, 29_800.00)]
    [InlineAutoNSubstituteData(111_000.00, 35_800.00)]
    [InlineAutoNSubstituteData(122_000.00, 42_400.00)]
    [InlineAutoNSubstituteData(150_000.00, 53_600.00)]
    [InlineAutoNSubstituteData(160_000.00, 58_100.00)]
    public void Calculate_The_Annual_Tax_Payable(
        decimal grossAnnualSalary,
        decimal expectedTaxPayable)
    {
        new TaxCalculator(grossAnnualSalary).AnnualTaxPayable.Should().Be(expectedTaxPayable);
    }
}