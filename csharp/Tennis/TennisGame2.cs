using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Points;
        private int _player2Points;

        private string p1res = "";
        private string p2res = "";
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            if (_player1Points == _player2Points)
            {
                return GetEqualScore(_player1Points);
            }
            
            if (_player1Points < 4 && _player2Points < 4)
            {
                return $"{GetPointsScore(_player1Points)}-{GetPointsScore(_player2Points)}";
            }

            return GetAdvantageOrWinScore();
        }

        public void WonPoint(string playerName)
        {
            if (string.Equals(playerName, _player1Name, StringComparison.OrdinalIgnoreCase))
                _player1Points++;
            else if (string.Equals(playerName, _player2Name, StringComparison.OrdinalIgnoreCase))
                _player2Points++;
            else
                throw new ArgumentException($"Unknown player named {playerName}.");
        }

        private string GetEqualScore(int points)
        {
            var score = points switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };

            return score;
        }

        private string GetPointsScore(int points)
        {
            var score = points switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => string.Empty
            };

            return score;
        }
        
        private string GetAdvantageOrWinScore()
        {
            var differenceInScore = _player1Points - _player2Points;
            var score = differenceInScore switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2"
            };

            return score;
        }
    }
}

