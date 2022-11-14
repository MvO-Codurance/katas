using FluentAssertions;
using Xunit;

namespace SalarySlip.Tests;

public class NationalInsuranceShould
{
    [Theory]
    [InlineAutoNSubstituteData(5000.00)]
    [InlineAutoNSubstituteData(8060.00)]
    public void Calculate_Zero_Annual_Contribution_For_Salaries_8060_00_And_Below(decimal grossAnnualSalary)
    {
        new NationalInsurance(grossAnnualSalary).AnnualContribution.Should().Be(0);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(11000.00, 29.40 * 12)]
    [InlineAutoNSubstituteData(12000.00, 39.40 * 12)]
    [InlineAutoNSubstituteData(30000.00, 219.40 * 12)]
    public void Calculate_The_Correct_Annual_Contribution_On_Salaries_Above_8060_00(
        decimal grossAnnualSalary,
        decimal expectedAnnualContribution)
    {
        new NationalInsurance(grossAnnualSalary).AnnualContribution.Should().Be(expectedAnnualContribution);
    }
}