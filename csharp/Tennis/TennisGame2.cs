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
            var score = "";
            
            if (_player1Points == _player2Points)
            {
                score = GetEqualScore(_player1Points);
            }
            
            if (_player1Points > 0 && _player2Points == 0)
            {
                if (_player1Points == 1)
                    p1res = "Fifteen";
                if (_player1Points == 2)
                    p1res = "Thirty";
                if (_player1Points == 3)
                    p1res = "Forty";

                p2res = "Love";
                score = p1res + "-" + p2res;
            }
            if (_player2Points > 0 && _player1Points == 0)
            {
                if (_player2Points == 1)
                    p2res = "Fifteen";
                if (_player2Points == 2)
                    p2res = "Thirty";
                if (_player2Points == 3)
                    p2res = "Forty";

                p1res = "Love";
                score = p1res + "-" + p2res;
            }

            if (_player1Points > _player2Points && _player1Points < 4)
            {
                if (_player1Points == 2)
                    p1res = "Thirty";
                if (_player1Points == 3)
                    p1res = "Forty";
                if (_player2Points == 1)
                    p2res = "Fifteen";
                if (_player2Points == 2)
                    p2res = "Thirty";
                score = p1res + "-" + p2res;
            }
            if (_player2Points > _player1Points && _player2Points < 4)
            {
                if (_player2Points == 2)
                    p2res = "Thirty";
                if (_player2Points == 3)
                    p2res = "Forty";
                if (_player1Points == 1)
                    p1res = "Fifteen";
                if (_player1Points == 2)
                    p1res = "Thirty";
                score = p1res + "-" + p2res;
            }

            if (_player1Points > _player2Points && _player2Points >= 3)
            {
                score = "Advantage player1";
            }

            if (_player2Points > _player1Points && _player1Points >= 3)
            {
                score = "Advantage player2";
            }

            if (_player1Points >= 4 && _player2Points >= 0 && (_player1Points - _player2Points) >= 2)
            {
                score = "Win for player1";
            }
            if (_player2Points >= 4 && _player1Points >= 0 && (_player2Points - _player1Points) >= 2)
            {
                score = "Win for player2";
            }
            return score;
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
    }
}

