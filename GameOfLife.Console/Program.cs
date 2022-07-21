using ConwaysGameOfLife;

const int numberOfGenerations = 20;
const int millisecondsBetweenGenerations = 500;

// specific starting boards (see https://en.wikipedia.org/wiki/Conway's_Game_of_Life)
//var startingBoard = BlinkerPeriod2();
//var startingBoard = BeaconPeriod2();
var startingBoard = PulsarPeriod3();
var game = new GameOfLife(startingBoard);

// random starting board
//var game = new GameOfLife(5);

Console.CursorVisible = false;
for (int generation = 0; generation <= numberOfGenerations; generation++)
{
    PrintBoard(game, generation);
    Thread.Sleep(millisecondsBetweenGenerations);
    game.NextGen();
}
Console.CursorVisible = true;

static void PrintBoard(GameOfLife game, int generation)
{
    Console.SetCursorPosition(0,0);
    Console.WriteLine($"Generation: {generation}");
    
    for (int x = 0; x <= game.Board.GetUpperBound(0); x++)
    {
        PrintCellSeparator();
        for (int y = 0; y <= game.Board.GetUpperBound(1); y++)
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

static bool[,] PulsarPeriod3()
{
    var startingBoard = new bool[17,17];
    
    // bottom left pattern, starting at the bottom and moving clockwise 
    startingBoard[4, 2] = true;
    startingBoard[5, 2] = true;
    startingBoard[6, 2] = true;
    
    startingBoard[2, 4] = true;
    startingBoard[2, 5] = true;
    startingBoard[2, 6] = true;
    
    startingBoard[4, 7] = true;
    startingBoard[5, 7] = true;
    startingBoard[6, 7] = true;
    
    startingBoard[7, 4] = true;
    startingBoard[7, 5] = true;
    startingBoard[7, 6] = true;
    
    // top left pattern, starting at the bottom and moving clockwise 
    startingBoard[4, 9] = true;
    startingBoard[5, 9] = true;
    startingBoard[6, 9] = true;
    
    startingBoard[2, 10] = true;
    startingBoard[2, 11] = true;
    startingBoard[2, 12] = true;
    
    startingBoard[4, 14] = true;
    startingBoard[5, 14] = true;
    startingBoard[6, 14] = true;
    
    startingBoard[7, 10] = true;
    startingBoard[7, 11] = true;
    startingBoard[7, 12] = true;
    
    // top right pattern, starting at the bottom and moving clockwise 
    startingBoard[10, 9] = true;
    startingBoard[11, 9] = true;
    startingBoard[12, 9] = true;
    
    startingBoard[9, 10] = true;
    startingBoard[9, 11] = true;
    startingBoard[9, 12] = true;
    
    startingBoard[10, 14] = true;
    startingBoard[11, 14] = true;
    startingBoard[12, 14] = true;
    
    startingBoard[14, 10] = true;
    startingBoard[14, 11] = true;
    startingBoard[14, 12] = true;
    
    // bottom left pattern, starting at the bottom and moving clockwise 
    startingBoard[10, 2] = true;
    startingBoard[11, 2] = true;
    startingBoard[12, 2] = true;
    
    startingBoard[9, 4] = true;
    startingBoard[9, 5] = true;
    startingBoard[9, 6] = true;
    
    startingBoard[10, 7] = true;
    startingBoard[11, 7] = true;
    startingBoard[12, 7] = true;
    
    startingBoard[14, 4] = true;
    startingBoard[14, 5] = true;
    startingBoard[14, 6] = true;
    
    return startingBoard;
}