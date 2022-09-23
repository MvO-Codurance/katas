using FluentAssertions;
using Xunit;

namespace Tennis.Tests;

public class TennisScoreCalculatorShould
{
    [Theory]
    [InlineAutoMoqData(4, 0, "Player1")]
    [InlineAutoMoqData(4, 1, "Player1")]
    [InlineAutoMoqData(4, 2, "Player1")]
    [InlineAutoMoqData(5, 3, "Player1")]
    [InlineAutoMoqData(6, 4, "Player1")]
    [InlineAutoMoqData(7, 5, "Player1")]
    [InlineAutoMoqData(0, 4, "Player2")]
    [InlineAutoMoqData(1, 4, "Player2")]
    [InlineAutoMoqData(2, 4, "Player2")]
    [InlineAutoMoqData(3, 5, "Player2")]
    [InlineAutoMoqData(4, 6, "Player2")]
    [InlineAutoMoqData(5, 7, "Player2")]
    public void ShowPlayerWinsWhenPlayerHas4PlusPointsAnd2PlusMorePointsThanOtherPlayer(int player1Points, int player2Points, string winningPlayer)
    {
        new TennisScoreCalculator().Score(player1Points, player2Points).Should().Be($"{winningPlayer} Wins");
    }
    
    [Theory]
    [InlineAutoMoqData(0, 0, "Love All")]
    [InlineAutoMoqData(1, 1, "Fifteen All")]
    [InlineAutoMoqData(2, 2, "Thirty All")]
    [InlineAutoMoqData(1, 0, "Fifteen Love")]
    [InlineAutoMoqData(0, 1, "Love Fifteen")]
    [InlineAutoMoqData(2, 0, "Thirty Love")]
    [InlineAutoMoqData(0, 2, "Love Thirty")]
    [InlineAutoMoqData(3, 0, "Forty Love")]
    [InlineAutoMoqData(0, 3, "Love Forty")]
    [InlineAutoMoqData(2, 1, "Thirty Fifteen")]
    [InlineAutoMoqData(1, 2, "Fifteen Thirty")]
    [InlineAutoMoqData(3, 2, "Forty Thirty")]
    [InlineAutoMoqData(2, 3, "Thirty Forty")]
    public void ShowCorrectInGameScore(int player1Points, int player2Points, string expectedScore)
    {
        new TennisScoreCalculator().Score(player1Points, player2Points).Should().Be(expectedScore);
    }
    
    [Theory]
    [InlineAutoMoqData(3, 3)]
    [InlineAutoMoqData(4, 4)]
    [InlineAutoMoqData(5, 5)]
    [InlineAutoMoqData(6, 6)]
    public void ShowDeuceWhenBothPlayersScoresAreEqualAndHaveScoredGreaterThan3Points(int player1Points, int player2Points)
    {
        new TennisScoreCalculator().Score(player1Points, player2Points).Should().Be("Deuce");
    }
    
    [Theory]
    [InlineAutoMoqData(4, 3, "Advantage Player1")]
    [InlineAutoMoqData(3, 4, "Advantage Player2")]
    [InlineAutoMoqData(5, 4, "Advantage Player1")]
    [InlineAutoMoqData(4, 5, "Advantage Player2")]
    [InlineAutoMoqData(6, 5, "Advantage Player1")]
    [InlineAutoMoqData(5, 6, "Advantage Player2")]
    public void ShowAdvantageWhenBothPlayersHave3PlusPointsAndOneHasOneMorePointThanTheOther(int player1Points, int player2Points, string expectedScore)
    {
        new TennisScoreCalculator().Score(player1Points, player2Points).Should().Be(expectedScore);
    }
}