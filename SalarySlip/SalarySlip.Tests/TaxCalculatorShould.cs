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
        decimal expectedTaxFreeAllowance)
    {
        new TaxCalculator(grossAnnualSalary).AnnualTaxFreeAllowance.Should().Be(expectedTaxFreeAllowance);
    }
}