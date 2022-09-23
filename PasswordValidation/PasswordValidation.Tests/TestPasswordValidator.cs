namespace PasswordValidation.Tests;

public class TestPasswordValidator : IPasswordValidator
{
    public bool Validate(string password)
    {
        return true;
    }
}