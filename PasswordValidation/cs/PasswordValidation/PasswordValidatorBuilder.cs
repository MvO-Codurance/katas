namespace PasswordValidation;

public class PasswordValidatorBuilder : IPasswordValidatorBuilder
{
    private readonly List<IPasswordValidator> _validators = new List<IPasswordValidator>();
    
    public IPasswordValidatorBuilder Add(IPasswordValidator validator)
    {
        _validators.Add(validator);
        return this;
    }

    public CompositePasswordValidator Build()
    {
        return new CompositePasswordValidator(_validators);
    }
}