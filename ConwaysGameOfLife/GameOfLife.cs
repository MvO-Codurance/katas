namespace ConwaysGameOfLife;

public class GameOfLife
{
    public Board Board { get; private set; }

    public GameOfLife(int size)
        : this(new Board(size))
    {
    }
    
    public GameOfLife(Board board)
    {
        Board = board;
    }

    public void NextGen()
    {
        var newBoard = new Board(Board.Size, false);

        for (int x = 0; x < Board.Size; x++)
        {
            for (int y = 0; y < Board.Size; y++)
            {
                bool isAlive = Board.GetCellValue(x, y);
                int liveNeighboursCount = Board.GetNeighbouringCellsOf(x, y).Count(n => n);

                switch (isAlive)
                {
                    case true when liveNeighboursCount is < 2 or > 3:
                        newBoard.SetCellValue(x, y, false);
                        break;
                    case true when liveNeighboursCount is 2 or 3:
                    case false when liveNeighboursCount == 3:
                        newBoard.SetCellValue(x, y, true);
                        break;
                }
            }    
        }

        Board = newBoard;
    }
}