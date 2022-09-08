using ConwaysGameOfLife;

const int numberOfGenerations = 20;
const int millisecondsBetweenGenerations = 500;

// specific starting boards (see https://en.wikipedia.org/wiki/Conway's_Game_of_Life)
// var startingBoard = BlinkerPeriod2();
// var startingBoard = BeaconPeriod2();
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
    
    for (int x = 0; x < game.Board.Size; x++)
    {
        PrintCellSeparator();
        for (int y = 0; y < game.Board.Size; y++)
        {
            PrintCell(game.Board.GetCellValue(x, y));
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

static Board BlinkerPeriod2()
{
    var startingBoard = new Board(5, false);
    startingBoard.SetCellValue(2, 2, true);
    startingBoard.SetCellValue(1, 2, true);
    startingBoard.SetCellValue(3, 2, true);
    return startingBoard;
}

static Board BeaconPeriod2()
{
    var startingBoard = new Board(6, false);
    
    startingBoard.SetCellValue(1, 3, true);
    startingBoard.SetCellValue(1, 4, true);
    startingBoard.SetCellValue(2, 4, true);
    
    startingBoard.SetCellValue(3, 1, true);
    startingBoard.SetCellValue(4, 1, true);
    startingBoard.SetCellValue(4, 2, true);
    
    return startingBoard;
}

static Board PulsarPeriod3()
{
    var startingBoard = new Board(17, false);
    
    // bottom left pattern, starting at the bottom and moving clockwise 
    startingBoard.SetCellValue(4, 2, true);
    startingBoard.SetCellValue(5, 2, true);
    startingBoard.SetCellValue(6, 2, true);
    
    startingBoard.SetCellValue(2, 4, true);
    startingBoard.SetCellValue(2, 5, true);
    startingBoard.SetCellValue(2, 6, true);
    
    startingBoard.SetCellValue(4, 7, true);
    startingBoard.SetCellValue(5, 7, true);
    startingBoard.SetCellValue(6, 7, true);
    
    startingBoard.SetCellValue(7, 4, true);
    startingBoard.SetCellValue(7, 5, true);
    startingBoard.SetCellValue(7, 6, true);
    
    // top left pattern, starting at the bottom and moving clockwise 
    startingBoard.SetCellValue(4, 9, true);
    startingBoard.SetCellValue(5, 9, true);
    startingBoard.SetCellValue(6, 9, true);
    
    startingBoard.SetCellValue(2, 10, true);
    startingBoard.SetCellValue(2, 11, true);
    startingBoard.SetCellValue(2, 12, true);
    
    startingBoard.SetCellValue(4, 14, true);
    startingBoard.SetCellValue(5, 14, true);
    startingBoard.SetCellValue(6, 14, true);
    
    startingBoard.SetCellValue(7, 10, true);
    startingBoard.SetCellValue(7, 11, true);
    startingBoard.SetCellValue(7, 12, true);
    
    // top right pattern, starting at the bottom and moving clockwise 
    startingBoard.SetCellValue(10, 9, true);
    startingBoard.SetCellValue(11, 9, true);
    startingBoard.SetCellValue(12, 9, true);
    
    startingBoard.SetCellValue(9, 10, true);
    startingBoard.SetCellValue(9, 11, true);
    startingBoard.SetCellValue(9, 12, true);
    
    startingBoard.SetCellValue(10, 14, true);
    startingBoard.SetCellValue(11, 14, true);
    startingBoard.SetCellValue(12, 14, true);
    
    startingBoard.SetCellValue(14, 10, true);
    startingBoard.SetCellValue(14, 11, true);
    startingBoard.SetCellValue(14, 12, true);
    
    // bottom left pattern, starting at the bottom and moving clockwise 
    startingBoard.SetCellValue(10, 2, true);
    startingBoard.SetCellValue(11, 2, true);
    startingBoard.SetCellValue(12, 2, true);
    
    startingBoard.SetCellValue(9, 4, true);
    startingBoard.SetCellValue(9, 5, true);
    startingBoard.SetCellValue(9, 6, true);
    
    startingBoard.SetCellValue(10, 7, true);
    startingBoard.SetCellValue(11, 7, true);
    startingBoard.SetCellValue(12, 7, true);
    
    startingBoard.SetCellValue(14, 4, true);
    startingBoard.SetCellValue(14, 5, true);
    startingBoard.SetCellValue(14, 6, true);
    
    return startingBoard;
}