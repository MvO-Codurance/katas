namespace PasswordValidation;

public class LengthPasswordValidator : IPasswordValidator
{
    private readonly int _minimumLength;

    public LengthPasswordValidator(int minimumLength)
    {
        _minimumLength = minimumLength;
    }
    
    public bool Validate(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < _minimumLength)
        {
            return false;
        }

        return true;
    }
}

public class UppercasePasswordValidator : IPasswordValidator
{
    public bool Validate(string password)
    {
        if (!password.Any(char.IsUpper))
        {
            return false;
        }

        return true;
    }
}

public class LowercasePasswordValidator : IPasswordValidator
{
    public bool Validate(string password)
    {
        if (!password.Any(char.IsLower))
        {
            return false;
        }

        return true;
    }
}

public class NumberPasswordValidator : IPasswordValidator
{
    public bool Validate(string password)
    {
        if (!password.Any(char.IsDigit))
        {
            return false;
        }

        return true;
    }
}

public class UnderscorePasswordValidator : IPasswordValidator
{
    public bool Validate(string password)
    {
        if (password.IndexOf('_') < 0)
        {
            return false;
        }

        return true;
    }
}
