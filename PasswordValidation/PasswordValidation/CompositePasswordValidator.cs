namespace PasswordValidation;

public class CompositePasswordValidator : IPasswordValidator
{
    private readonly IEnumerable<IPasswordValidator> _validators;

    public CompositePasswordValidator(IEnumerable<IPasswordValidator> validators)
    {
        _validators = validators;
    }

    public bool Validate(string password)
    {
        foreach (var validator in _validators)
        {
            if (!validator.Validate(password))
            {
                return false;
            }
        }

        return true;
    }
}