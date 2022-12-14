namespace BankOcr;

public class AccountFile
{
    public List<AccountFileEntry> Entries { get; private set; }

    private AccountFile()
    {
        Entries = new();
    }
    
    public static AccountFile Read(Stream stream)
    {
        AccountFile result = new();
        List<string> linesBuffer = new(3);
        string? line;
        int fileLineNumberForEntry = 1;
        
        using var reader = new StreamReader(stream);
        while ((line = reader.ReadLine()) != null)
        {
            if (string.IsNullOrEmpty(line))
            {
                fileLineNumberForEntry++;
                continue;
            }
            
            linesBuffer.Add(line);

            if (linesBuffer.Count == AccountFileEntry.EntryLinesCount)
            {
                try
                {
                    var entry = AccountFileEntry.Create(linesBuffer.ToArray());
                    result.Entries.Add(entry);
                    fileLineNumberForEntry += AccountFileEntry.EntryLinesCount;
                }
                catch (Exception ex)
                {
                    throw new AccountFileReadException(
                        fileLineNumberForEntry,
                        $"Could not read file. Invalid entry starting at line {fileLineNumberForEntry}.",
                        ex);
                }

                linesBuffer.Clear();
            }
        }
        
        return result;
    }

    public void CreateResultFile(string outputPath)
    {
        using Stream stream = File.OpenWrite(outputPath);
        using StreamWriter writer = new StreamWriter(stream);
        
        try
        {
            foreach (var entry in Entries)
            {
                writer.Write($"{entry.AccountNumber}");
            
                if (entry.AccountNumber.Contains(AccountFileEntryDigit.IllegalDigit))
                {
                    writer.Write(" ILL");
                }
                else if (!entry.IsChecksumValid())
                {
                    writer.Write(" ERR");
                }
            
                writer.WriteLine();
            }
        }
        finally
        {
            writer.Flush();
            writer.Close();
        }
    }
}