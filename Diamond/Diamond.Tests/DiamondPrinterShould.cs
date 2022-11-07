using FluentAssertions;
using Xunit;

namespace Diamond.Tests;

public class DiamondPrinterShould
{
    [Fact]
    public void Given_A_Print_A()
    {
        new DiamondPrinter().Print('A').Should().Be("A");
    }
    
    [Fact]
    public void Given_B_Print_ABBA()
    {
        var expected = """
                        A
                       B B
                        A
                       """;
        
        new DiamondPrinter().Print('B').Should().Be(expected);
    }
    
    [Fact]
    public void Given_C_Print_ABBCCBBA()
    {
        var expected = """
                         A
                        B B
                       C   C
                        B B
                         A
                       """;
        
        new DiamondPrinter().Print('C').Should().Be(expected);
    }
    
    [Fact]
    public void Given_D_Print_ABBCCDDCCBBA()
    {
        var expected = """
                          A
                         B B
                        C   C
                       D     D
                        C   C
                         B B
                          A
                       """;
        
        new DiamondPrinter().Print('D').Should().Be(expected);
    }
    
    [Fact]
    public void Given_E_Print_ABBCCDDEEDDCCBBA()
    {
        var expected = """
                           A
                          B B
                         C   C
                        D     D
                       E       E
                        D     D
                         C   C
                          B B
                           A
                       """;
        
        new DiamondPrinter().Print('E').Should().Be(expected);
    }
    
    [Theory]
    [InlineAutoNSubstituteData('0')]
    [InlineAutoNSubstituteData('9')]
    [InlineAutoNSubstituteData('a')]
    [InlineAutoNSubstituteData('z')]
    [InlineAutoNSubstituteData('&')]
    public void Given_Invalid_Character_Then_Throws(char input)
    {
        Action act = () => new DiamondPrinter().Print(input);
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage("The given character must be a letter between A and Z.");
    }
}