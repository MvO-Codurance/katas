using System.Runtime.CompilerServices;

namespace BankOcr;

public class AccountFileEntryDigit
{
    public const int DigitLineLength = 3;
    public const char IllegalDigit = '?';

    public char Value { get; private set; }

    private AccountFileEntryDigit()
    {
    }
    
    public static AccountFileEntryDigit Create(string line1, string line2, string line3)
    {
        ValidateDigitLine(line1);
        ValidateDigitLine(line2);
        ValidateDigitLine(line3);

        char digit = line1 switch
        {
            " _ " when line2 == "| |" && line3 == "|_|" => '0',
            "   " when line2 == "  |" && line3 == "  |" => '1',
            " _ " when line2 == " _|" && line3 == "|_ " => '2',
            " _ " when line2 == " _|" && line3 == " _|" => '3',
            "   " when line2 == "|_|" && line3 == "  |" => '4',
            " _ " when line2 == "|_ " && line3 == " _|" => '5',
            " _ " when line2 == "|_ " && line3 == "|_|" => '6',
            " _ " when line2 == "  |" && line3 == "  |" => '7',
            " _ " when line2 == "|_|" && line3 == "|_|" => '8',
            " _ " when line2 == "|_|" && line3 == " _|" => '9',
            _ => IllegalDigit
        };

        return new AccountFileEntryDigit
        {
            Value = digit
        };
    }

    private static void ValidateDigitLine(
        string line, 
        [CallerArgumentExpression("line")] string lineParameterName = "")
    {
        if (string.IsNullOrEmpty(line) || line.Length != DigitLineLength)
        {
            throw new ArgumentException($"Account file entry digit ({lineParameterName}) must be exactly {DigitLineLength} characters.");
        }
    }
}