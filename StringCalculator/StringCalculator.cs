namespace StringCalculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        var separators = GetSeparators(ref numbers);

        // split the numbers string on the separator(s)
        string[] individualNumbers = numbers.Split(separators.ToArray());
        
        // convert the split numbers to integers
        List<int> convertedNumbers = individualNumbers
            .Select(x => Convert.ToInt32(x))
            .ToList();

        // disallow negative numbers
        if (convertedNumbers.Any(x => x < 0))
        {
            throw new ArgumentException($"negatives are not allowed: {string.Join(' ', convertedNumbers.Where(x => x < 0))}");
        }
        
        // ignore numbers > 1000
        convertedNumbers = convertedNumbers.Where(x => x <= 1000).ToList();
        
        return convertedNumbers.Sum();
    }

    private List<char> GetSeparators(ref string numbers)
    {
        var separators = new List<char> { ',', '\n' };

        // check for custom separator
        if (numbers.StartsWith("//"))
        {
            int customSepPosition = 2;
            separators.Add(numbers[customSepPosition]);
            numbers = numbers.Substring(numbers.IndexOf('\n') + 1);

            //int customSepStartPosition = 2;
            //int customSepEndPosition = numbers.IndexOf('\n', customSepStartPosition);
            //string customSep = numbers.Substring(customSepStartPosition, customSepEndPosition);
            //separators.Add(customSep);
        }

        return separators;
    }
}