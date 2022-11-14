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
    [InlineAutoNSubstituteData(11000.00, 352.80)]
    [InlineAutoNSubstituteData(12000.00, 472.80)]
    [InlineAutoNSubstituteData(30000.00, 2632.80)]
    [InlineAutoNSubstituteData(43000.00, 4192.80)]
    public void Calculate_The_Correct_Annual_Contribution_On_Salaries_Above_8060_00_Below_43_000_00(
        decimal grossAnnualSalary,
        decimal expectedAnnualContribution)
    {
        new NationalInsurance(grossAnnualSalary).AnnualContribution.Should().Be(expectedAnnualContribution);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(45000.00, 4232.80)]
    public void Calculate_The_Correct_Annual_Contribution_On_Salaries_Above_43_000_00(
        decimal grossAnnualSalary,
        decimal expectedAnnualContribution)
    {
        new NationalInsurance(grossAnnualSalary).AnnualContribution.Should().Be(expectedAnnualContribution);
    }
}