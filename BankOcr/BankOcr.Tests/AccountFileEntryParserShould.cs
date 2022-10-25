using FluentAssertions;
using Xunit;

namespace BankOcr.Tests;

public class AccountFileEntryParserShould
{
    [Theory]
    [InlineAutoNSubstituteData(" _ ", "| |", "|_|", "0")]
    [InlineAutoNSubstituteData("   ", "  |", "  |", "1")]
    [InlineAutoNSubstituteData(" _ ", " _|", "|_ ", "2")]
    [InlineAutoNSubstituteData(" _ ", " _|", " _|", "3")]
    [InlineAutoNSubstituteData("   ", "|_|", "  |", "4")]
    [InlineAutoNSubstituteData(" _ ", "|_ ", " _|", "5")]
    [InlineAutoNSubstituteData(" _ ", "|_ ", "|_|", "6")]
    [InlineAutoNSubstituteData(" _ ", "  |", "  |", "7")]
    [InlineAutoNSubstituteData(" _ ", "|_|", "|_|", "8")]
    [InlineAutoNSubstituteData(" _ ", "|_|", " _|", "9")]
    public void Parse_Single_Digit(
        string line1,
        string line2,
        string line3,
        string expectedResult)
    {
        new AccountFileEntryParser().ParseDigit(line1, line2, line3).Should().Be(expectedResult);
    }
    
    [Theory]
    [MemberData(nameof(SingleAccountFileEntries))]
    public void Parse_A_Single_Account_Number(
        string[] accountFileEntryLines,
        string expectedResult)
    {
        new AccountFileEntryParser().Parse(accountFileEntryLines).Should().Be(expectedResult);
    }
    
    public static IEnumerable<object[]> SingleAccountFileEntries =>
        new List<object[]>
        {
            new object[] { _123456789, "123456789" }
        };

    private static readonly string[] _123456789 = 
    {
        "    _  _     _  _  _  _  _ ",
        "  | _| _||_||_ |_   ||_||_|",
        "  ||_  _|  | _||_|  ||_| _|"
    };
}