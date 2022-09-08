using System;
using System.ComponentModel;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Score = 0;
        private int _player2Score = 0;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (string.Equals(playerName, _player1Name, StringComparison.OrdinalIgnoreCase))
                _player1Score++;
            else if (string.Equals(playerName, _player2Name, StringComparison.OrdinalIgnoreCase))
                _player2Score++;
            else
                throw new ArgumentException($"Unknown player named {playerName}.");
        }

        public string GetScore()
        {
            var score = string.Empty;
            
            if (_player1Score == _player2Score)
            {
                score = GetEqualScore();
            }
            else if (_player1Score >= 4 || _player2Score >= 4)
            {
                score = GetAdvantageOrWinScore();
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1) tempScore = _player1Score;
                    else { score += "-"; tempScore = _player2Score; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }

        private string GetEqualScore()
        {
            var score = _player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };

            return score;
        }

        private string GetAdvantageOrWinScore()
        {
            var differenceInScore = _player1Score - _player2Score;
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

