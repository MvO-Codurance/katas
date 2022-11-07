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
        var indent = codeForInput - CodeForA;   // the indent is a count of space chars between the target letter and 'A'
        var gap = 0;                            // the gap always starts at zero as 'A' is always output on it's own
        var currentCode = CodeForA;             // we always start at 'A'

        // start at 'A' and loop until we reach the target letter
        while (currentCode <= codeForInput)
        {
            result.AppendLine(GetLine(currentCode, indent, gap));
            
            currentCode++;
            indent--;               // the indent decreases by 1 for each line
            gap = GetNextGap(gap);  // the gap increases in a pattern of odd numbers, i.e. 1, 3, 5, 7, ...
        }
        
        // we've reached the target letter, the widest part of the diamond so now we reset
        // we incremented past the target letter and we don't want to output the target letter again, so decrease by 2
        currentCode -= 2;           
        indent += 2;
        gap -= 2;
        gap = GetPreviousGap(gap);
        
        // starting at the target letter - 1, loop until we reach 'A' again
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