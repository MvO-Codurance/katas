using FluentAssertions;
using Xunit;

namespace PasswordValidation.Tests;

public class CompositePasswordValidatorShould
{
    [Fact]
    public void ReturnValidWhenUsingTheTestPasswordValidator()
    {
        var validators = new List<IPasswordValidator>
        {
            new TestPasswordValidator()
        };
        var validator = new CompositePasswordValidator(validators);
        validator.Validate("Ab1_xxxxx").Should().BeTrue();
    }
}