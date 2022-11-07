using System.Text;

namespace Diamond;

public class DiamondPrinter
{
    public string Print(char input)
    {
        const int codeForA = (int)'A';
        const int codeForZ = (int)'Z';
        
        int codeForInput = (int)input;

        if (codeForA > codeForInput || codeForInput > codeForZ)
        {
            throw new ArgumentException("The given character must be a letter between A and Z.");
        }

        if (codeForInput == codeForA)
        {
            return "A";
        }
        
        var result = new StringBuilder();
        int indent = codeForInput - codeForA;
        int gap = 0;
        int currentCode = codeForA;

        while (currentCode <= codeForInput)
        {
            if (currentCode == codeForA)
            {
                result.AppendLine($"{new string(' ', indent)}{(char)currentCode}");
            }
            else
            {
                result.AppendLine($"{new string(' ', indent)}{(char)currentCode}{new string(' ', gap)}{(char)currentCode}");   
            }
            
            currentCode++;
            indent--;
            gap = gap == 0 ? gap + 1 : gap + 2;
        }
        
        currentCode -= 2;
        indent += 2;
        gap -= 2;
        gap = GetPreviousGap(gap);
        while (currentCode >= codeForA)
        {
            if (currentCode == codeForA)
            {
                result.Append($"{new string(' ', indent)}{(char)currentCode}");
            }
            else
            {
                result.AppendLine($"{new string(' ', indent)}{(char)currentCode}{new string(' ', gap)}{(char)currentCode}");   
            }
            
            currentCode--;
            indent++;
            gap = GetPreviousGap(gap);
        }

        return result.ToString();
    }

    private static int GetPreviousGap(int gap)
    {
        return gap == 1 ? gap - 1 : gap - 2;
    }
}