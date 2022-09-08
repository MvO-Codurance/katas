namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _player1Points;
        private int _player2Points;

        private string p1res = "";
        private string p2res = "";
        private string _player1Name;
        private string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (_player1Points == _player2Points && _player1Points < 3)
            {
                if (_player1Points == 0)
                    score = "Love";
                if (_player1Points == 1)
                    score = "Fifteen";
                if (_player1Points == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (_player1Points == _player2Points && _player1Points > 2)
                score = "Deuce";

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

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            _player1Points++;
        }

        private void P2Score()
        {
            _player2Points++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

