using System.Security.Cryptography;

namespace ConwaysGameOfLife;

public class GameOfLife
{
    public bool[,] Board { get; private set; }

    public GameOfLife(int size)
    {
        var startingBoard = new bool[size, size];
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                startingBoard[x, y] = RandomNumberGenerator.GetInt32(2) == 1;
            }
        }

        Board = startingBoard;
    }
    
    public GameOfLife(bool[,] board)
    {
        Board = board;
    }

    public void NextGen()
    {
        int maxX = Board.GetUpperBound(0) + 1;
        int maxY = Board.GetUpperBound(1) + 1;
        var newBoard = new bool[maxX, maxY];

        for (int x = 0; x < maxX; x++)
        {
            for (int y = 0; y < maxY; y++)
            {
                bool isAlive = Board[x, y];
                int liveNeighbours = GetNeighbours(x, y).Count(n => n);

                switch (isAlive)
                {
                    case true when liveNeighbours is < 2 or > 3:
                        newBoard[x, y] = false;
                        break;
                    case true when liveNeighbours is 2 or 3:
                    case false when liveNeighbours == 3:
                        newBoard[x, y] = true;
                        break;
                }
            }    
        }

        Board = newBoard;
    }

    private List<bool> GetNeighbours(int x, int y)
    {
        return new List<bool>
        {
            // above
            GetCell(x - 1, y + 1),
            GetCell(x, y + 1),
            GetCell(x + 1, y + 1),
            // adjacent
            GetCell(x - 1, y),
            GetCell(x + 1, y),
            // below
            GetCell(x - 1, y - 1),
            GetCell(x, y - 1),
            GetCell(x + 1, y - 1)
        };
    }

    private bool GetCell(int x, int y)
    {
        if (x < Board.GetLowerBound(0) || 
            x > Board.GetUpperBound(0) ||
            y < Board.GetLowerBound(1) || 
            y > Board.GetUpperBound(1))
        {
            return false;
        }

        return Board[x, y];
    }
}