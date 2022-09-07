namespace TicTacToe;

public class TicTacToeGame
{
    private const char X = 'X';
    private const char O = 'O';
    
    public char?[,] Board { get; private set; }
    public char CurrentPlayer { get; private set; }

    private PlayResult _lastPlayResult;
    
    public TicTacToeGame()
    {
        Board = new char?[3, 3];
        CurrentPlayer = X;
    }

    public PlayResult Play(Coordinate coordinate)
    {
        if (HasGameAlreadyFinished())
        {
            return _lastPlayResult;
        }
        
        if (SquareAlreadyPlayed(coordinate))
        {
            _lastPlayResult = PlayResult.Rejected;
            return _lastPlayResult;
        }
        
        // make the play
        Board[coordinate.X, coordinate.Y] = CurrentPlayer;

        if (ColumnWin() || RowWin() || BottomLeftTopRightWin() || TopLeftBottomRightWin())
        {
            _lastPlayResult = CurrentPlayer == X ? PlayResult.PlayerXWins : PlayResult.PlayerOWins;
            return _lastPlayResult;
        }
        
        if (IsDraw())
        {
            _lastPlayResult = PlayResult.Draw;
            return _lastPlayResult;
        }

        // toggle player
        CurrentPlayer = CurrentPlayer == X ? O : X;
        
        // continue game
        _lastPlayResult = PlayResult.Accepted;
        return _lastPlayResult;
    }

    private bool HasGameAlreadyFinished()
    {
        return _lastPlayResult is PlayResult.Draw or PlayResult.PlayerXWins or PlayResult.PlayerOWins;
    }

    private bool SquareAlreadyPlayed(Coordinate coordinate)
    {
        return Board[coordinate.X, coordinate.Y].HasValue;
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
        return Board[square1.X, square1.Y].HasValue && 
               Board[square2.X, square2.Y].HasValue &&
               Board[square3.X, square3.Y].HasValue &&
               (Board[square1.X, square1.Y]!.Value == Board[square2.X, square2.Y]!.Value &&
                Board[square2.X, square2.Y]!.Value == Board[square3.X, square3.Y]!.Value);
    }

    private bool IsDraw()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (!Board[x, y].HasValue)
                {
                    return false;
                }
            }
        }

        return true;
    }
}