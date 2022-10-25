using System.Runtime.CompilerServices;

namespace BankOcr;

public class AccountFileEntryDigitParser
{
    public const int DigitLineLength = 3;
    
    public string Parse(string line1, string line2, string line3)
    {
        ValidateDigitLine(line1);
        ValidateDigitLine(line2);
        ValidateDigitLine(line3);
        
        return line1 switch
        {
            " _ " when line2 == "| |" && line3 == "|_|" => 0.ToString(),
            "   " when line2 == "  |" && line3 == "  |" => 1.ToString(),
            " _ " when line2 == " _|" && line3 == "|_ " => 2.ToString(),
            " _ " when line2 == " _|" && line3 == " _|" => 3.ToString(),
            "   " when line2 == "|_|" && line3 == "  |" => 4.ToString(),
            " _ " when line2 == "|_ " && line3 == " _|" => 5.ToString(),
            " _ " when line2 == "|_ " && line3 == "|_|" => 6.ToString(),
            " _ " when line2 == "  |" && line3 == "  |" => 7.ToString(),
            " _ " when line2 == "|_|" && line3 == "|_|" => 8.ToString(),
            " _ " when line2 == "|_|" && line3 == " _|" => 9.ToString(),
            _ => "?"
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