using System.ComponentModel;
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
        public TimeSpan ReadingTime => CalculateReadingTime();

        public AnalyseResult(int wordCount, Dictionary<string, int> commonWords)
        {
            WordCount = wordCount;
            CommonWords = commonWords;
        }

        private TimeSpan CalculateReadingTime()
        {
            // Divide total word count by 200. The number before the decimal is your minutes.
            // Take the decimal points and multiply that number by .60. That will give you your seconds.
            const decimal readingRate = 200m; // words per minute
            decimal timeCalculation = WordCount / readingRate;
            int minutes = Convert.ToInt32(Math.Truncate(timeCalculation)); // minutes is the portion before the decimal point
            int seconds = Convert.ToInt32(Math.Floor((timeCalculation - minutes) * 0.60m * 100)); // seconds is the portion after the decimal point

            return new TimeSpan(0, minutes, seconds);
        }
    }
}