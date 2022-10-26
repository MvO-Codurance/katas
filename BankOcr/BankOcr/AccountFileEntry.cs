using System.Runtime.CompilerServices;

namespace BankOcr;

public class AccountFileEntry
{
    private const int EntryLineLength = 27;
    
    public  const int EntryLinesCount = 3;

    private readonly List<AccountFileEntryDigit> _accountNumberDigits;
    
    public string AccountNumber => new string(_accountNumberDigits.Select(x => x.Value).ToArray());
    
    private AccountFileEntry()
    {
        _accountNumberDigits = new();
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
            
            result._accountNumberDigits.Add(digit);
        }
        
        return result;
    }

    public bool IsChecksumValid()
    {
        /*
            account number:  3  4  5  8  8  2  8  6  5
            position names:  d9 d8 d7 d6 d5 d4 d3 d2 d1
            
            checksum calculation:
            ((1*d1) + (2*d2) + (3*d3) + ... + (9*d9)) mod 11 == 0
        */
        
        var d1 = char.GetNumericValue(_accountNumberDigits[8].Value);
        var d2 = char.GetNumericValue(_accountNumberDigits[7].Value);
        var d3 = char.GetNumericValue(_accountNumberDigits[6].Value);
        var d4 = char.GetNumericValue(_accountNumberDigits[5].Value);
        var d5 = char.GetNumericValue(_accountNumberDigits[4].Value);
        var d6 = char.GetNumericValue(_accountNumberDigits[3].Value);
        var d7 = char.GetNumericValue(_accountNumberDigits[2].Value);
        var d8 = char.GetNumericValue(_accountNumberDigits[1].Value);
        var d9 = char.GetNumericValue(_accountNumberDigits[0].Value);

        var sum = (1*d1) + (2*d2) + (3*d3) + (4*d4) + (5*d5) + (6*d6) + (7*d7) + (8*d8) + (9*d9);
        var checksum = sum % 11;
        return (checksum == 0);
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