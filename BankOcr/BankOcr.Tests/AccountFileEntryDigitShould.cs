using FluentAssertions;
using Xunit;

namespace BankOcr.Tests;

public class AccountFileEntryDigitShould
{
    [Theory]
    [InlineAutoNSubstituteData(" _ ", "| |", "|_|", '0')]
    [InlineAutoNSubstituteData("   ", "  |", "  |", '1')]
    [InlineAutoNSubstituteData(" _ ", " _|", "|_ ", '2')]
    [InlineAutoNSubstituteData(" _ ", " _|", " _|", '3')]
    [InlineAutoNSubstituteData("   ", "|_|", "  |", '4')]
    [InlineAutoNSubstituteData(" _ ", "|_ ", " _|", '5')]
    [InlineAutoNSubstituteData(" _ ", "|_ ", "|_|", '6')]
    [InlineAutoNSubstituteData(" _ ", "  |", "  |", '7')]
    [InlineAutoNSubstituteData(" _ ", "|_|", "|_|", '8')]
    [InlineAutoNSubstituteData(" _ ", "|_|", " _|", '9')]
    public void Parse_Lines_Into_Digit(
        string line1,
        string line2,
        string line3,
        char expectedDigit)
    {
        AccountFileEntryDigit.Create(line1, line2, line3).Value.Should().Be(expectedDigit);
    }
    
    [Theory]
    [InlineAutoNSubstituteData(null, "   ", "   ")]
    [InlineAutoNSubstituteData("", "   ", "   ")]
    [InlineAutoNSubstituteData("1", "   ", "   ")]
    [InlineAutoNSubstituteData("12", "   ", "   ")]
    [InlineAutoNSubstituteData("1234", "   ", "   ")]
    public void Throw_When_Given_Invalid_Line1(
        string line1,
        string line2,
        string line3)
    {
        Action act = () => AccountFileEntryDigit.Create(line1, line2, line3);

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Account file entry digit (line1) must be exactly 3 characters.");
    }
    
    [Theory]
    [InlineAutoNSubstituteData("   ", null, "   ")]
    [InlineAutoNSubstituteData("   ", "", "   ")]
    [InlineAutoNSubstituteData("   ", "1", "   ")]
    [InlineAutoNSubstituteData("   ", "12", "   ")]
    [InlineAutoNSubstituteData("   ", "1234", "   ")]
    public void Throw_When_Given_Invalid_Line2(
        string line1,
        string line2,
        string line3)
    {
        Action act = () => AccountFileEntryDigit.Create(line1, line2, line3);

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Account file entry digit (line2) must be exactly 3 characters.");
    }
    
    [Theory]
    [InlineAutoNSubstituteData("   ", "   ", null)]
    [InlineAutoNSubstituteData("   ", "   ", "")]
    [InlineAutoNSubstituteData("   ", "   ", "1")]
    [InlineAutoNSubstituteData("   ", "   ", "12")]
    [InlineAutoNSubstituteData("   ", "   ", "1234")]
    public void Throw_When_Given_Invalid_Line3(
        string line1,
        string line2,
        string line3)
    {
        Action act = () => AccountFileEntryDigit.Create(line1, line2, line3);

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Account file entry digit (line3) must be exactly 3 characters.");
    }
}