using System.Text.RegularExpressions;

namespace StringCalculator;

public class StringCalculator
{
    /// <summary>
    ///  A description of the regular expression:
    ///  
    ///  Beginning of line or string
    ///  <![CDATA[
    ///  Match expression but don't capture it. [(?:/{2})(?<CustomSep>.)\\n], zero or one repetitions
    ///      (?:/{2})(?<CustomSep>.)\n
    ///          Match expression but don't capture it. [/{2}]
    ///              /, exactly 2 repetitions
    ///          [CustomSep]: A named capture group. [.]
    ///              Any character
    ///          Literal \
    ///          n
    ///  [Numbers]: A named capture group. [.*]
    ///      Any character, any number of repetitions
    ///  End of line or string
    ///  ]]>
    /// </summary>
    private static Regex _numbersRegex = new Regex(
        "^(?:(?:/{2})(?<CustomSep>.)\\n)?(?<Numbers>.*)$",
        RegexOptions.IgnoreCase
        | RegexOptions.Singleline
        | RegexOptions.ExplicitCapture
        | RegexOptions.CultureInvariant
        | RegexOptions.Compiled
    );

    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        // get/parse the required separators and converted numbers from the original "numbers" string 
        var separators = GetSeparators(ref numbers);
        var convertedNumbers = GetNumbers(numbers, separators);

        // disallow negative numbers
        if (convertedNumbers.Any(x => x < 0))
        {
            throw new ArgumentException($"Negative numbers are not allowed: {string.Join(' ', convertedNumbers.Where(x => x < 0))}");
        }
        
        // ignore numbers > 1000
        convertedNumbers = convertedNumbers.Where(x => x <= 1000).ToList();
        
        return convertedNumbers.Sum();
    }

    private List<char> GetSeparators(ref string numbers)
    {
        var separators = new List<char> { ',', '\n' };

        Match match = _numbersRegex.Match(numbers);
        if (!match.Success)
        {
            throw new ArgumentException($"Could not parse numbers string: {numbers}");
        }

        Group customSepGroup = match.Groups["CustomSep"];
        if (customSepGroup.Success)
        {
            // only use the first character of the custom separator at this point
            separators.Add(customSepGroup.Value[0]);

            numbers = match.Groups["Numbers"].Value;
        }
        
        return separators;
    }
    
    private List<int> GetNumbers(string numbers, List<char> separators)
    {
        // split the numbers string on the separator(s)
        string[] individualNumbers = numbers.Split(separators.ToArray());

        // convert the split numbers to integers
        return individualNumbers
            .Select(x => Convert.ToInt32(x))
            .ToList();
    }
}