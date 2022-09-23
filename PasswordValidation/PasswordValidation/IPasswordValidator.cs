namespace PasswordValidation;

public interface IPasswordValidator
{
    bool Validate(string password);
}