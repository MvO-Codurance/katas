using System.Runtime.CompilerServices;

namespace BankOcr;

public class AccountFileEntryParser
{
    private const int EntryLineCount = 3;
    private const int EntryLineLength = 27;
    
    private readonly AccountFileEntryDigitParser _digitParser;

    public AccountFileEntryParser()
    {
        _digitParser = new AccountFileEntryDigitParser();
    }
    
    public string Parse(string[] accountFileEntryLines)
    {
        if (accountFileEntryLines == null) throw new ArgumentNullException(nameof(accountFileEntryLines));
        if (accountFileEntryLines.Length != EntryLineCount) throw new ArgumentException($"Account file entry must be exactly {EntryLineCount} lines.");

        var line1 = accountFileEntryLines[0];
        var line2 = accountFileEntryLines[1];
        var line3 = accountFileEntryLines[2];
        
        ValidateEntryLine(line1);
        ValidateEntryLine(line2);
        ValidateEntryLine(line3);

        var line1Digits = line1.Chunk(AccountFileEntryDigitParser.DigitLineLength).ToList();
        var line2Digits = line2.Chunk(AccountFileEntryDigitParser.DigitLineLength).ToList();
        var line3Digits = line3.Chunk(AccountFileEntryDigitParser.DigitLineLength).ToList();

        string result = string.Empty;
        for (int index = 0; index < line1Digits.Count(); index++)
        {
            result += _digitParser.Parse(
                new string(line1Digits[index]), 
                new string(line2Digits[index]), 
                new string(line3Digits[index]));
        }
        
        return result;
    }

    private static void ValidateEntryLine(
        string line, 
        [CallerArgumentExpression("line")] string lineParameterName = "")
    {
        if (string.IsNullOrEmpty(line) || line.Length != EntryLineLength)
        {
            throw new ArgumentException($"Account file entry line ({lineParameterName}) must be exactly {EntryLineLength} characters.");
        }
    }
}