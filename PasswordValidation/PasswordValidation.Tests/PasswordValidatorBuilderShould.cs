using FluentAssertions;
using Xunit;

namespace PasswordValidation.Tests;

public class PasswordValidatorBuilderShould
{
    [Fact]
    public void ReturnAPasswordValidatorFromBuild()
    {
        new PasswordValidatorBuilder().Build().Should().NotBeNull();
    }
    
    [Fact]
    public void ReturnThePasswordValidatorBuilderFromAdd()
    {
        var builder = new PasswordValidatorBuilder();
        builder.Add(new TestPasswordValidator()).Should().Be(builder);
    }
    
    [Theory]
    [InlineAutoMoqData("Ab1_xxxxx", true, "password is 9 characters in length")]
    [InlineAutoMoqData("Ab1_", false, "password is < 9 characters in length")]
    [InlineAutoMoqData("ab1_xxxxx", false, "password does not contain an uppercase character")]
    [InlineAutoMoqData("AB1_XXXXX", false, "password does not contain an lowercase character")]
    [InlineAutoMoqData("Abc_xxxxx", false, "password does not contain a number character")]
    [InlineAutoMoqData("Ab1-xxxxx", false, "password does not contain an underscore character")]
    public void BuildAValidatorToCorrectlyValidateIteration1Passwords(string password, bool expectedValidity, string reason)
    {
        CompositePasswordValidator validator = new PasswordValidatorBuilder()
            .Add(new LengthPasswordValidator(9))
            .Add(new UppercasePasswordValidator())
            .Add(new LowercasePasswordValidator())
            .Add(new NumberPasswordValidator())
            .Add(new UnderscorePasswordValidator())
            .Build();
        
        validator.Validate(password).Should().Be(expectedValidity, reason);
    }
    
    [Theory]
    [InlineAutoMoqData("Ab1_xxx", true, "password is 7 characters in length")]
    [InlineAutoMoqData("Ab1_", false, "password is < 7 characters in length")]
    [InlineAutoMoqData("ab1_xxx", false, "password does not contain an uppercase character")]
    [InlineAutoMoqData("AB1_XXX", false, "password does not contain an lowercase character")]
    [InlineAutoMoqData("Abc_xxx", false, "password does not contain a number character")]
    public void BuildAValidatorToCorrectlyValidateIteration2APasswords(string password, bool expectedValidity, string reason)
    {
        CompositePasswordValidator validator = new PasswordValidatorBuilder()
            .Add(new LengthPasswordValidator(7))
            .Add(new UppercasePasswordValidator())
            .Add(new LowercasePasswordValidator())
            .Add(new NumberPasswordValidator())
            .Build();
        
        validator.Validate(password).Should().Be(expectedValidity, reason);
    }
    
    [Theory]
    [InlineAutoMoqData("Ab1_xxxxxxxxxxxxx", true, "password is 17 characters in length")]
    [InlineAutoMoqData("Ab1_", false, "password is < 17 characters in length")]
    [InlineAutoMoqData("ab1_xxxxxxxxxxxxx", false, "password does not contain an uppercase character")]
    [InlineAutoMoqData("AB1_XXXXXXXXXXXXX", false, "password does not contain an lowercase character")]
    [InlineAutoMoqData("Ab1-XXXXXXXXXXXXX", false, "password does not contain an underscore character")]
    public void BuildAValidatorToCorrectlyValidateIteration2BPasswords(string password, bool expectedValidity, string reason)
    {
        CompositePasswordValidator validator = new PasswordValidatorBuilder()
            .Add(new LengthPasswordValidator(7))
            .Add(new UppercasePasswordValidator())
            .Add(new LowercasePasswordValidator())
            .Add(new UnderscorePasswordValidator())
            .Build();
        
        validator.Validate(password).Should().Be(expectedValidity, reason);
    }
}