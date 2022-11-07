using System.Text;

namespace Diamond;

public class DiamondPrinter
{
    private const int CodeForA = 'A';
    private const int CodeForZ = 'Z';
    
    public string Print(char input)
    {
        int codeForInput = input;

        if (codeForInput is < CodeForA or > CodeForZ)
        {
            throw new ArgumentException("The given character must be a letter between A and Z.");
        }

        if (codeForInput == CodeForA)
        {
            return "A";
        }
        
        var result = new StringBuilder();
        var indent = codeForInput - CodeForA;
        var gap = 0;
        var currentCode = CodeForA;

        while (currentCode <= codeForInput)
        {
            result.AppendLine(GetLine(currentCode, indent, gap));
            
            currentCode++;
            indent--;
            gap = GetNextGap(gap);
        }
        
        currentCode -= 2;
        indent += 2;
        gap -= 2;
        gap = GetPreviousGap(gap);
        while (currentCode >= CodeForA)
        {
            var line = GetLine(currentCode, indent, gap);
            
            if (currentCode == CodeForA)
            {
                result.Append(line);
            }
            else
            {
                result.AppendLine(line);   
            }
            
            currentCode--;
            indent++;
            gap = GetPreviousGap(gap);
        }

        return result.ToString();
    }

    private static string GetLine(int letterCode, int indent, int gap)
    {
        if (letterCode == CodeForA)
        {
            return $"{Space(indent)}{(char)letterCode}";
        }
        
        return $"{Space(indent)}{(char)letterCode}{Space(gap)}{(char)letterCode}";
    }

    private static string Space(int count)
    {
        return new string(' ', count);
    }
    
    private static int GetNextGap(int gap)
    {
        return gap == 0 ? gap + 1 : gap + 2;
    }

    private static int GetPreviousGap(int gap)
    {
        return gap == 1 ? gap - 1 : gap - 2;
    }
}