using System.Security.Cryptography;

namespace ConwaysGameOfLife;

public class Board
{
    private readonly int _size;
    private readonly bool[,] _board;

    public Board(int size, bool fillWithRandom = true)
    {
        _size = size;
        _board = new bool[_size, _size];

        if (fillWithRandom)
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    _board[x, y] = RandomNumberGenerator.GetInt32(2) == 1;
                }
            }
        }
    }

    public int Size => _size;
    
    public bool GetCellValue(int x, int y)
    {
        return _board[x, y];
    }
    
    public void SetCellValue(int x, int y, bool value)
    {
        _board[x, y] = value;
    }
    
    public List<bool> GetNeighbouringCellsOf(int x, int y)
    {
        return new List<bool>
        {
            // above
            GetNeighbouringCell(x - 1, y + 1),
            GetNeighbouringCell(x, y + 1),
            GetNeighbouringCell(x + 1, y + 1),
            // adjacent
            GetNeighbouringCell(x - 1, y),
            GetNeighbouringCell(x + 1, y),
            // below
            GetNeighbouringCell(x - 1, y - 1),
            GetNeighbouringCell(x, y - 1),
            GetNeighbouringCell(x + 1, y - 1)
        };
    }

    private bool GetNeighbouringCell(int x, int y)
    {
        if (CellIsOffTheBoard(x, y))
        {
            return false;
        }

        return GetCellValue(x, y);
    }

    private bool CellIsOffTheBoard(int x, int y)
    {
        return x < _board.GetLowerBound(0) ||
               x > _board.GetUpperBound(0) ||
               y < _board.GetLowerBound(1) ||
               y > _board.GetUpperBound(1);
    }
}