namespace PasswordValidation;

public class PasswordValidator
{
    public bool Validate(string password)
    {
        // length
        if (string.IsNullOrEmpty(password) || password.Length < 9)
        {
            return false;
        }
        
        // uppercase
        if (!password.Any(char.IsUpper))
        {
            return false;
        }
        
        // lowercase
        if (!password.Any(char.IsLower))
        {
            return false;
        }
        
        // number
        if (!password.Any(char.IsDigit))
        {
            return false;
        }
        
        // underscore
        if (password.IndexOf('_') < 0)
        {
            return false;
        }
        
        return true;
    }
}