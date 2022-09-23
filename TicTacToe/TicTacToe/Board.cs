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
}