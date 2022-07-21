using ConwaysGameOfLife;

const int boardSize = 5;
const int numberOfGenerations = 20;
const int millisecondsBetweenGenerations = 500;

// specific starting boards
//var startingBoard = BlinkerPeriod2();
//var startingBoard = BeaconPeriod2();
//var game = new GameOfLife(startingBoard);

// random starting board
var game = new GameOfLife(boardSize);

for (int generation = 0; generation <= numberOfGenerations; generation++)
{
    PrintBoard(game, generation);
    Thread.Sleep(millisecondsBetweenGenerations);
    game.NextGen();
}

static void PrintBoard(GameOfLife game, int generation)
{
    Console.Clear();
    Console.WriteLine($"Generation: {generation}");
    
    for (int x = 0; x <= game.Board.GetUpperBound(0); x++)
    {
        PrintCellSeparator();
        for (int y = game.Board.GetUpperBound(1); y >= 0; y--)
        {
            PrintCell(game.Board[x, y]);
            PrintCellSeparator();
        }
        PrintNewLine();
    }
}

static void PrintCellSeparator()
{
    Console.Write('|');
}

static void PrintCell(bool value)
{
    Console.Write(" {0} ", value ? "X" : " ");
}

static void PrintNewLine()
{
    Console.WriteLine();
}

static bool[,] BlinkerPeriod2()
{
    var startingBoard = new bool[5,5];
    startingBoard[2, 2] = true;
    startingBoard[1, 2] = true;
    startingBoard[3, 2] = true;
    return startingBoard;
}

static bool[,] BeaconPeriod2()
{
    var startingBoard = new bool[6,6];
    startingBoard[1, 3] = true;
    startingBoard[1, 4] = true;
    startingBoard[2, 4] = true;
    startingBoard[3, 1] = true;
    startingBoard[4, 1] = true;
    startingBoard[4, 2] = true;
    return startingBoard;
}