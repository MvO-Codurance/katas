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

        if (ColumnWin() || RowWin() || BottomLeftTopRightWin() || TopLeftBottomRightWin())
        {
            _lastPlayResult = CurrentPlayer == Player.X ? PlayResult.PlayerXWins : PlayResult.PlayerOWins;
            return _lastPlayResult;
        }
        
        if (IsDraw())
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

    private bool ColumnWin()
    {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++)
        {
            if (IsWinningSequence(new Coordinate(columnIndex, 0), new Coordinate(columnIndex, 1), new Coordinate(columnIndex, 2)))
            {
                return true;
            }    
        }

        return false;
    }

    private bool RowWin()
    {
        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            if (IsWinningSequence(new Coordinate(0, rowIndex), new Coordinate(1, rowIndex), new Coordinate(2, rowIndex)))
            {
                return true;
            }
        }

        return false;
    }

    private bool BottomLeftTopRightWin()
    {
        return IsWinningSequence(new Coordinate(0, 0), new Coordinate(1, 1), new Coordinate(2, 2));
    }

    private bool TopLeftBottomRightWin()
    {
        return IsWinningSequence(new Coordinate(0, 2), new Coordinate(1, 1), new Coordinate(2, 0));
    }

    private bool IsWinningSequence(Coordinate square1, Coordinate square2, Coordinate square3)
    {
        return Board.HasSquareBeenPlayed(square1) && 
               Board.HasSquareBeenPlayed(square2) &&
               Board.HasSquareBeenPlayed(square3) &&
               (Board.Square(square1)!.Value == Board.Square(square2)!.Value &&
                Board.Square(square2)!.Value == Board.Square(square3)!.Value);
    }

    private bool IsDraw()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (!Board.HasSquareBeenPlayed(new Coordinate(x, y)))
                {
                    return false;
                }
            }
        }

        return true;
    }
}