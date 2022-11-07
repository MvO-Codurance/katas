namespace TicTacToe;

public class TicTacToeGame
{
    public Board Board { get; }
    public Player CurrentPlayer { get; private set; }

    private PlayResult _lastPlayResult;
    
    public TicTacToeGame()
    {
        Board = new Board();
        CurrentPlayer = Player.X;
    }

    public PlayResult Play(Coordinate coordinate)
    {
        if (HasGameAlreadyFinished())
        {
            return _lastPlayResult;
        }
        
        if (Board.HasSquareBeenPlayed(coordinate))
        {
            _lastPlayResult = PlayResult.Rejected;
            return _lastPlayResult;
        }
        
        Board.PlaySquare(coordinate, CurrentPlayer);

        if (Board.HasSomebodyWon())
        {
            _lastPlayResult = CurrentPlayer == Player.X ? PlayResult.PlayerXWins : PlayResult.PlayerOWins;
            return _lastPlayResult;
        }
        
        if (Board.IsDraw())
        {
            _lastPlayResult = PlayResult.Draw;
            return _lastPlayResult;
        }

        // toggle player
        CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
        
        // continue game
        _lastPlayResult = PlayResult.Accepted;
        return _lastPlayResult;
    }

    private bool HasGameAlreadyFinished()
    {
        return _lastPlayResult is PlayResult.Draw or PlayResult.PlayerXWins or PlayResult.PlayerOWins;
    }
}