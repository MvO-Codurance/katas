using FluentAssertions;
using Xunit;

namespace ConwaysGameOfLife.Tests;

public class GameOfLifeShould
{
    [Fact]
    public void Kill_A_Live_Cell_Alive_When_It_Has_Less_Than_2_Live_Neighbours()
    {
        // arrange
        var startingBoard = new Board(3, false);
        // the center cell is alive
        startingBoard.SetCellValue(1, 1, true); 
        
        var game = new GameOfLife(startingBoard);
        
        // act
        game.NextGen();
        
        // assert
        game.Board.GetCellValue(1, 1).Should().BeFalse();
        AssertAllCellsAreDeadExcept(game.Board, 1, 1);
    }

    [Fact]
    public void Keep_A_Live_Cell_Alive_When_It_Has_2_Live_Neighbours()
    {
        // arrange
        var startingBoard = new Board(3, false);
        // the center cell is alive
        startingBoard.SetCellValue(1, 1, true); 
        // it has 2 live neighbours
        startingBoard.SetCellValue(0, 1, true); 
        startingBoard.SetCellValue(2, 1, true); 
        
        var game = new GameOfLife(startingBoard);
        
        // act
        game.NextGen();
        
        // assert
        game.Board.GetCellValue(1, 1).Should().BeTrue();
        AssertAllCellsAreDeadExcept(game.Board, 1, 1);
    }
    
    [Fact]
    public void Keep_A_Live_Cell_Alive_When_It_Has_3_Live_Neighbours()
    {
        // arrange
        var startingBoard = new Board(3, false);
        // the center cell is alive
        startingBoard.SetCellValue(1, 1, true);
        // it has 3 live neighbours
        startingBoard.SetCellValue(0, 2, true);
        startingBoard.SetCellValue(1, 2, true);
        startingBoard.SetCellValue(2, 2, true);
        
        var game = new GameOfLife(startingBoard);
        
        // act
        game.NextGen();
        
        // assert
        game.Board.GetCellValue(1, 1).Should().BeTrue();
    }
    
    [Fact]
    public void Resurrect_A_Dead_Cell_When_It_Has_3_Live_Neighbours()
    {
        // arrange
        var startingBoard = new Board(3, false);
        // the center cell is already dead and it has 3 live neighbours
        startingBoard.SetCellValue(0, 2, true);
        startingBoard.SetCellValue(1, 2, true);
        startingBoard.SetCellValue(2, 2, true);
        
        var game = new GameOfLife(startingBoard);
        
        // act
        game.NextGen();
        
        // assert
        game.Board.GetCellValue(1, 1).Should().BeTrue();
        AssertAllCellsAreDeadExcept(game.Board, 1, 1);
    }
    
    [Theory]
    // top row
    [InlineAutoMoqData(0, 2)]
    [InlineAutoMoqData(1, 2)]
    [InlineAutoMoqData(2, 2)]
    // adjacent of center
    [InlineAutoMoqData(0, 1)]
    [InlineAutoMoqData(2, 1)]
    // bottom row
    [InlineAutoMoqData(0, 0)]
    [InlineAutoMoqData(1, 0)]
    [InlineAutoMoqData(2, 0)]
    public void Keep_A_Dead_Edge_Cell_Dead_When_It_Only_Has_1_Live_Neighbour(
        int edgeCellX, 
        int edgeCellY)
    {
        // arrange
        var startingBoard = new Board(3, false);
        // it has 1 live neighbour (the center cell)
        startingBoard.SetCellValue(1, 1, true);

        var game = new GameOfLife(startingBoard);
        
        // act
        game.NextGen();
        
        // assert
        game.Board.GetCellValue(edgeCellX, edgeCellY).Should().BeFalse();
        AssertAllCellsAreDeadExcept(game.Board, edgeCellX, edgeCellY);
    }
    
    private void AssertAllCellsAreDeadExcept(Board board, int exceptX, int exceptY)
    {
        for (int x = 0; x < board.Size; x++)
        {
            for (int y = 0; y < board.Size; y++)
            {
                if (x != exceptX && y != exceptY)
                {
                    board.GetCellValue(x, y).Should().BeFalse($"expected cell[{x},{y}] to be dead");
                }
            }
        }
    }
}