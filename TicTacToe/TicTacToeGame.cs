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
        // game already finished?
        if (_lastPlayResult is PlayResult.Draw or PlayResult.PlayerXWins or PlayResult.PlayerOWins)
        {
            return _lastPlayResult;
        }
        
        // square already played?
        if (Board[x, y].HasValue)
        {
            _lastPlayResult = PlayResult.Rejected;
            return _lastPlayResult;
        }
        
        // make the play
        Board[x, y] = CurrentPlayer;

        // check for a winner
        PlayResult ReturnWinningResult()
        {
            _lastPlayResult = CurrentPlayer == X ? PlayResult.PlayerXWins : PlayResult.PlayerOWins;
            return _lastPlayResult;
        }

        // column win?
        for (int columnIndex = 0; columnIndex < 3; columnIndex++)
        {
            if (IsWinningSequence((columnIndex, 0), (columnIndex, 1), (columnIndex, 2)))
            {
                return ReturnWinningResult();
            }    
        }
        
        // row win?
        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            if (IsWinningSequence((0, rowIndex), (1, rowIndex), (2, rowIndex)))
            {
                return ReturnWinningResult();
            }
        }
        
        // diagonal (bottom left -> top right) win?
        if (IsWinningSequence((0, 0), (1, 1), (2, 2)))
        {
            return ReturnWinningResult();
        }
        
        // diagonal (top left -> bottom right) win?
        if (IsWinningSequence((0, 2), (1, 1), (2, 0)))
        {
            return ReturnWinningResult();
        }
        
        // draw?
        if (IsBoardFull())
        {
            _lastPlayResult = PlayResult.Draw;
            return _lastPlayResult;
        }

        // toggle player
        CurrentPlayer = CurrentPlayer == X ? O : X;
        
        _lastPlayResult = PlayResult.Accepted;
        return _lastPlayResult;
    }

    private bool IsWinningSequence((int x, int y) square1, (int x, int y) square2, (int x, int y) square3)
    {
        return Board[square1.x, square1.y].HasValue && 
               Board[square2.x, square2.y].HasValue &&
               Board[square3.x, square3.y].HasValue &&
               (Board[square1.x, square1.y].Value == Board[square2.x, square2.y].Value &&
                Board[square2.x, square2.y].Value == Board[square3.x, square3.y].Value);
    }

    private bool IsBoardFull()
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