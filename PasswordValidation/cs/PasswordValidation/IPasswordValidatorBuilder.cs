namespace PasswordValidation;

public interface IPasswordValidatorBuilder
{
    IPasswordValidatorBuilder Add(IPasswordValidator validator);
    
    CompositePasswordValidator Build();
}