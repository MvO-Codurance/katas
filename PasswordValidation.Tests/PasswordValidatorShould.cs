using FluentAssertions;
using Xunit;

namespace PasswordValidation.Tests;

public class PasswordValidatorShould
{
    [Fact]
    public void ReturnValidForAValidPassword()
    {
        new PasswordValidator().Validate("Ab1_xxxxx").Should().BeTrue();
    }
    
    [Theory]
    [InlineAutoMoqData("Ab1_", "password is <= 8 characters in length")]
    [InlineAutoMoqData("ab1_xxxxx", "password does not contain an uppercase character")]
    [InlineAutoMoqData("AB1_XXXXX", "password does not contain an lowercase character")]
    [InlineAutoMoqData("Abc_xxxxx", "password does not contain a number character")]
    [InlineAutoMoqData("Ab1-xxxxx", "password does not contain an underscore character")]
    public void ReturnInvalidForAnInvalidPassword(string password, string reason)
    {
        new PasswordValidator().Validate(password).Should().BeFalse(reason);
    }
}