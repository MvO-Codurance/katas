using FluentAssertions;
using Xunit;

namespace TextProcessing.Tests;

public class TextProcessorShould
{
    const string TestText = "Hello, this is an example for you to practice. You should grab this text and make it as your test case.";
    
    [Fact]
    public void GivenTheTestText_List10WordsFromIt()
    {
        string[] individualWords = TestText.Replace(",", "").Replace(".", "").Split(' ');

        var analyseResult = new TextProcessor().Analyse(TestText);

        analyseResult.CommonWords.Should().HaveCount(10);

        foreach (string commonWord in analyseResult.CommonWords.Keys)
        {
            individualWords.Should().Contain(commonWord);
        }
    }
    
    [Fact]
    public void GivenTheTestText_YouAndThisOccurTwice()
    {
        var analyseResult = new TextProcessor().Analyse(TestText);

        analyseResult.CommonWords.ContainsKey("you").Should().BeTrue();
        analyseResult.CommonWords["you"].Should().Be(2);
        
        analyseResult.CommonWords.ContainsKey("this").Should().BeTrue();
        analyseResult.CommonWords["this"].Should().Be(2);
    }
    
    [Fact]
    public void GivenTheTestText_WordsOtherThanYouAndThisOccurOnce()
    {
        var analyseResult = new TextProcessor().Analyse(TestText);

        foreach (var commonWord in analyseResult.CommonWords.Keys)
        {
            if (!string.Equals(commonWord, "you", StringComparison.OrdinalIgnoreCase) && 
                !string.Equals(commonWord, "this", StringComparison.OrdinalIgnoreCase))
            {
                analyseResult.CommonWords[commonWord].Should().Be(1);   
            }
        }
    }
    
     [Fact]
     public void GivenTheTestText_ThereAre21WordsInTotal()
     {
         new TextProcessor().Analyse(TestText).WordCount.Should().Be(21);
     }
}