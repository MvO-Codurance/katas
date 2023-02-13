using FluentAssertions;
using Xunit;

namespace PasswordValidation.Tests;

public class PasswordValidatorsShould
{
    [Theory]
    [InlineAutoMoqData("Ab1_", false, "password is < 9 characters in length")]
    [InlineAutoMoqData("Ab1_xxxxx", true, "password is 9 characters in length")]
    public void CorrectlyValidateLength(string password, bool expectedValidity, string reason)
    {
        new LengthPasswordValidator(9).Validate(password).Should().Be(expectedValidity, reason);
    }
    
    [Theory]
    [InlineAutoMoqData("ab1_", false, "password does not contain an uppercase character")]
    [InlineAutoMoqData("Ab1_xxxxx", true, "password contains an uppercase character")]
    public void CorrectlyValidateUpperCase(string password, bool expectedValidity, string reason)
    {
        new UppercasePasswordValidator().Validate(password).Should().Be(expectedValidity, reason);
    }

    [Theory]
    [InlineAutoMoqData("AB1_", false, "password does not contain an lowercase character")]
    [InlineAutoMoqData("Ab1_xxxxx", true, "password contains an lowercase character")]
    public void CorrectlyValidateLowerCase(string password, bool expectedValidity, string reason)
    {
        new LowercasePasswordValidator().Validate(password).Should().Be(expectedValidity, reason);
    }
    
    [Theory]
    [InlineAutoMoqData("Ab_", false, "password does not contain a number character")]
    [InlineAutoMoqData("Ab1_xxxxx", true, "password contains a number character")]
    public void CorrectlyValidateNumber(string password, bool expectedValidity, string reason)
    {
        new NumberPasswordValidator().Validate(password).Should().Be(expectedValidity, reason);
    }
    
    [Theory]
    [InlineAutoMoqData("Abc123", false, "password does not contain an underscore character")]
    [InlineAutoMoqData("Ab1_xxxxx", true, "password contains an underscore character")]
    public void CorrectlyValidateUnderscore(string password, bool expectedValidity, string reason)
    {
        new UnderscorePasswordValidator().Validate(password).Should().Be(expectedValidity, reason);
    }
}