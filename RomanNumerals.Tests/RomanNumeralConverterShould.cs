using FluentAssertions;
using Xunit;

namespace RomanNumerals.Tests;

public class RomanNumeralConverterShould
{
    [Theory]
    [InlineAutoMoqData(1, "I")]
    [InlineAutoMoqData(2, "II")]
    [InlineAutoMoqData(3, "III")]
    [InlineAutoMoqData(4, "IV")]
    [InlineAutoMoqData(5, "V")]
    [InlineAutoMoqData(6, "VI")]
    [InlineAutoMoqData(7, "VII")]
    [InlineAutoMoqData(8, "VIII")]
    [InlineAutoMoqData(9, "IX")]
    [InlineAutoMoqData(10, "X")]
    [InlineAutoMoqData(20, "XX")]
    [InlineAutoMoqData(30, "XXX")]
    [InlineAutoMoqData(40, "XL")]
    [InlineAutoMoqData(50, "L")]
    [InlineAutoMoqData(60, "LX")]
    [InlineAutoMoqData(70, "LXX")]
    [InlineAutoMoqData(80, "LXXX")]
    [InlineAutoMoqData(90, "XC")]
    [InlineAutoMoqData(100, "C")]
    [InlineAutoMoqData(400, "CD")]
    [InlineAutoMoqData(500, "D")]
    [InlineAutoMoqData(900, "CM")]
    [InlineAutoMoqData(1000, "M")]
    [InlineAutoMoqData(3000, "MMM")]
    [InlineAutoMoqData(2022, "MMXXII")]
    [InlineAutoMoqData(2499, "MMCDXCIX")]
    public void ConvertFromArabicToRomanNumeral(int arabic, string romanNumeral)
    {
        new RomanNumeralConverter().RomanNumeralFor(arabic).Should().Be(romanNumeral);
    }
}