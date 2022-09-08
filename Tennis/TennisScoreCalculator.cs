namespace Tennis;

public class TennisScoreCalculator
{
    public string Score(int player1Points, int player2Points)
    {
        if (IsWinningScore(player1Points, player2Points))
        {
            return $"{LeadingPlayer(player1Points, player2Points)} Wins";   
        }
        
        if (IsEqualScore(player1Points, player2Points))
        {
            return (player1Points >= 3) ? "Deuce" : $"{TranslatePlayerPoints(player1Points)} All";
        }
        
        if (IsAdvantageScore(player1Points, player2Points))
        {
            return $"Advantage {LeadingPlayer(player1Points, player2Points)}";
        }
        
        return $"{TranslatePlayerPoints(player1Points)} {TranslatePlayerPoints(player2Points)}";;
    }

    private bool IsWinningScore(int player1Points, int player2Points)
    {
        return (player1Points >= 4 && (player1Points - player2Points) >= 2) ||
               (player2Points >= 4 && (player2Points - player1Points) >= 2);
    }

    private bool IsEqualScore(int player1Points, int player2Points)
    {
        return player1Points == player2Points;
    }

    private bool IsAdvantageScore(int player1Points, int player2Points)
    {
        return player1Points >= 3 && player2Points >= 3 &&
               ((player1Points - player2Points == 1) || (player2Points - player1Points == 1));
    }

    private string TranslatePlayerPoints(int points)
    {
        return points switch
        {
            1 => "Fifteen",
            2 => "Thirty",
            3 => "Forty",
            _ => "Love"
        };
    }

    private string LeadingPlayer(int player1Points, int player2Points)
    {
        return player1Points > player2Points ? "Player1" : "Player2";
    }
}