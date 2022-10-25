using FluentAssertions;
using Xunit;

namespace BankOcr.Tests;

public class AccountFileEntryParserShould
{
    [Fact]
    public void Parse_A_Single_Account_Number()
    {
        string[] accountFileEntryLines =  
        {
            "    _  _     _  _  _  _  _ ",
            "  | _| _||_||_ |_   ||_||_|",
            "  ||_  _|  | _||_|  ||_| _|"
        };
        string expectedResult = "123456789";
        
        new AccountFileEntryParser().Parse(accountFileEntryLines).Should().Be(expectedResult);
    }
    
    [Fact]
    public void Throw_When_Given_Null_Entry_Lines()
    {
        Action act = () => new AccountFileEntryParser().Parse(null);

        act.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("accountFileEntryLines");
    }
    
    [Theory]
    [MemberData(nameof(InvalidAccountFileEntryLineCount))]
    public void Throw_When_Given_Invalid_Entry(string[] accountFileEntryLines)
    {
        Action act = () => new AccountFileEntryParser().Parse(accountFileEntryLines);

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage("Account file entry must be exactly 3 lines.");
    }
    
    [Theory]
    [MemberData(nameof(InvalidAccountFileEntryLineLength))]
    public void Throw_When_Given_Invalid_Entry_Line_Length(
        string[] accountFileEntryLines,
        string invalidLineName)
    {
        Action act = () => new AccountFileEntryParser().Parse(accountFileEntryLines);

        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"Account file entry line ({invalidLineName}) must be exactly 27 characters.");
    }
    
    public static IEnumerable<object[]> InvalidAccountFileEntryLineCount =>
        new List<object[]>
        {
            new object[] { new[] { "1" } },
            new object[] { new[] { "1", "2" } },
            new object[] { new[] { "1", "2", "3", "4" } }
        }; 
    
    public static IEnumerable<object[]> InvalidAccountFileEntryLineLength
    {
        get
        {
            var stringWith27Chars = string.Join("", Enumerable.Repeat("X", 27));
            var notStringWith27Chars = "not 27 characters";
            
            return new List<object[]>
            {
                new object[] { new[] { notStringWith27Chars, stringWith27Chars, stringWith27Chars }, "line1" },
                new object[] { new[] { stringWith27Chars, notStringWith27Chars, stringWith27Chars }, "line2" },
                new object[] { new[] { stringWith27Chars, stringWith27Chars, notStringWith27Chars }, "line3" }
            };
        }
    }
}