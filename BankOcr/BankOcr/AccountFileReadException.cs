namespace BankOcr;

public class AccountFileReadException : Exception
{
    public int LineNumber { get; private set; }
    
    public AccountFileReadException()
    {
    }

    public AccountFileReadException(string message)
        : base(message)
    {
    }

    public AccountFileReadException(string message, Exception inner)
        : base(message, inner)
    {
    }
    
    public AccountFileReadException(int lineNumber, string message, Exception inner)
        : base(message, inner)
    {
        LineNumber = lineNumber;
    }
}