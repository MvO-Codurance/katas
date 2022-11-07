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
        
        var lines =  BuildTopHalf(codeForInput);
        lines.AddRange(BuildBottomHalf(lines));
        
        return string.Join(Environment.NewLine, lines);
    }

    private static List<string> BuildTopHalf(int targetLetterCode)
    {
        List<string> result = new();
        var indent = targetLetterCode - CodeForA;   // the initial indent is the count of chars between the target letter and 'A'
        var gap = 0;                                // the gap always starts at zero as 'A' is always output on it's own
        var currentCode = CodeForA;                 // we always start at 'A'
        
        while (currentCode <= targetLetterCode)
        {
            result.Add(GetLine(currentCode, indent, gap));
            
            currentCode++;
            indent--;
            gap = GetNextGap(gap);
        }

        return result;
    }
    
    private static IEnumerable<string> BuildBottomHalf(IEnumerable<string> topHalf)
    {
        var bottomHalf = topHalf.ToList();
        bottomHalf.Reverse();
        return bottomHalf.Skip(1);
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
}