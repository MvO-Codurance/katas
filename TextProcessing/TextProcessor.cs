using System.Text.RegularExpressions;

namespace TextProcessing;

public class TextProcessor
{
    /// <summary>
    ///  A description of the regular expression:
    ///  
    ///  \b\w+\b
    ///      First or last character in a word
    ///      Alphanumeric, one or more repetitions
    ///      First or last character in a word
    /// </summary>
    private static readonly Regex WholeWordsRegex = new Regex(
        "\\b\\w+\\b",
        RegexOptions.ExplicitCapture
        | RegexOptions.CultureInvariant
        | RegexOptions.Compiled
    );
    
    public AnalyseResult Analyse(string text)
    {
        var commonWords = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        
        MatchCollection wholeWords = WholeWordsRegex.Matches(text);

        // count word occurrence
        foreach (Match match in wholeWords)
        {
            string word = match.Value;
            if (commonWords.ContainsKey(word))
            {
                commonWords[word]++;
            }
            else
            {
                commonWords.Add(word, 1);
            }
        }

        return new AnalyseResult(
            wholeWords.Count,
            // trim to give the top 10 in order of number of occurrences
            commonWords
                .OrderByDescending(kvp => kvp.Value)
                .Take(10)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
        );
    }

    public class AnalyseResult
    {
        public int WordCount { get; }
        public Dictionary<string, int> CommonWords { get; }

        public AnalyseResult(int wordCount, Dictionary<string, int> commonWords)
        {
            WordCount = wordCount;
            CommonWords = commonWords;
        }
    }
}