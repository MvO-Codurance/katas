using System.Runtime.CompilerServices;

namespace BankOcr;

public class AccountFileEntry
{
    private const int EntryLineLength = 27;
    
    public  const int EntryLinesCount = 3;

    public string AccountNumber => new string(AccountNumberDigits.Select(x => x.Value).ToArray());
    
    public List<AccountFileEntryDigit> AccountNumberDigits { get; private set; }

    private AccountFileEntry()
    {
        AccountNumberDigits = new();
    }
    
    public static AccountFileEntry Create(string[] accountFileEntryLines)
    {
        if (accountFileEntryLines == null) throw new ArgumentNullException(nameof(accountFileEntryLines));
        if (accountFileEntryLines.Length != EntryLinesCount) throw new ArgumentException($"Account file entry must be exactly {EntryLinesCount} lines.");

        var line1 = accountFileEntryLines[0];
        var line2 = accountFileEntryLines[1];
        var line3 = accountFileEntryLines[2];
        
        ValidateEntryLine(line1);
        ValidateEntryLine(line2);
        ValidateEntryLine(line3);

        var line1Digits = line1.Chunk(AccountFileEntryDigit.DigitLineLength).ToList();
        var line2Digits = line2.Chunk(AccountFileEntryDigit.DigitLineLength).ToList();
        var line3Digits = line3.Chunk(AccountFileEntryDigit.DigitLineLength).ToList();

        AccountFileEntry result = new();
        for (int index = 0; index < line1Digits.Count(); index++)
        {
            var digit = AccountFileEntryDigit.Create(
                new string(line1Digits[index]), 
                new string(line2Digits[index]), 
                new string(line3Digits[index])); 
            
            result.AccountNumberDigits.Add(digit);
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