using System.Reflection.Metadata.Ecma335;

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

    public PlayResult Play(int x, int y)
    {
        if (HasGameAlreadyFinished())
        {
            return _lastPlayResult;
        }
        
        if (SquareAlreadyPlayed(x, y))
        {
            _lastPlayResult = PlayResult.Rejected;
            return _lastPlayResult;
        }
        
        // make the play
        Board[x, y] = CurrentPlayer;

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

    private bool SquareAlreadyPlayed(int x, int y)
    {
        return Board[x, y].HasValue;
    }

    private bool ColumnWin()
    {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++)
        {
            if (IsWinningSequence((columnIndex, 0), (columnIndex, 1), (columnIndex, 2)))
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
            if (IsWinningSequence((0, rowIndex), (1, rowIndex), (2, rowIndex)))
            {
                return true;
            }
        }

        return false;
    }

    private bool BottomLeftTopRightWin()
    {
        return IsWinningSequence((0, 0), (1, 1), (2, 2));
    }

    private bool TopLeftBottomRightWin()
    {
        return IsWinningSequence((0, 2), (1, 1), (2, 0));
    }

    private bool IsWinningSequence((int x, int y) square1, (int x, int y) square2, (int x, int y) square3)
    {
        return Board[square1.x, square1.y].HasValue && 
               Board[square2.x, square2.y].HasValue &&
               Board[square3.x, square3.y].HasValue &&
               (Board[square1.x, square1.y].Value == Board[square2.x, square2.y].Value &&
                Board[square2.x, square2.y].Value == Board[square3.x, square3.y].Value);
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