namespace BankOcr;

public class AccountFileEntryParser
{
    private const int EntryLineCount = 3;
    private const int EntryLineLength = 27;
    private const int DigitLineLength = 3;
    
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

        var line1Digits = line1.Chunk(DigitLineLength).ToList();
        var line2Digits = line2.Chunk(DigitLineLength).ToList();
        var line3Digits = line3.Chunk(DigitLineLength).ToList();

        string result = string.Empty;
        for (int index = 0; index < line1Digits.Count(); index++)
        {
            result += ParseDigit(
                new string(line1Digits[index]), 
                new string(line2Digits[index]), 
                new string(line3Digits[index]));
        }
        
        return result;
    }

    public string ParseDigit(string line1, string line2, string line3)
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

    private static void ValidateEntryLine(string line)
    {
        if (line.Length != EntryLineLength)
        {
            throw new ArgumentException($"Account file entry line must be exactly {EntryLineLength} characters: '{line}' is {line.Length} characters.");
        }
    }
    
    private static void ValidateDigitLine(string line)
    {
        if (line.Length != DigitLineLength)
        {
            throw new ArgumentException($"Account file entry digit must be exactly {DigitLineLength} characters: '{line}' is {line.Length} characters.");
        }
    }
}