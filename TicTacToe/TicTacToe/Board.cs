namespace TicTacToe;

public class Board
{
    private readonly Player?[,] _board;

    public Board()
    {
        _board = new Player?[3, 3];
    }

    public Player? Square(Coordinate coordinate)
    {
        return _board[coordinate.X, coordinate.Y];
    }

    public bool HasSquareBeenPlayed(Coordinate coordinate)
    {
        return Square(coordinate).HasValue;
    }

    public void PlaySquare(Coordinate coordinate, Player player)
    {
        _board[coordinate.X, coordinate.Y] = player;
    }

    public bool HasSomebodyWon()
    {
        return ColumnWin() || RowWin() || BottomLeftTopRightWin() || TopLeftBottomRightWin();
    }
    
    public bool IsDraw()
    {
        for (int x = 0; x < 3; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                if (!HasSquareBeenPlayed(new Coordinate(x, y)))
                {
                    return false;
                }
            }
        }

        return true;
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
        return HasSquareBeenPlayed(square1) && 
               HasSquareBeenPlayed(square2) &&
               HasSquareBeenPlayed(square3) &&
               (Square(square1)!.Value == Square(square2)!.Value &&
                Square(square2)!.Value == Square(square3)!.Value);
    }
}