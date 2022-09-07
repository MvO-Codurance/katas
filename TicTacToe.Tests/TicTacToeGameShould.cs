using FluentAssertions;
using Xunit;

namespace TicTacToe.Tests;

public class TicTacToeGameShould
{
    [Fact]
    public void Start_A_New_Game_With_An_Empty_Board()
    {
        new TicTacToeGame().Board.Should().BeEquivalentTo(new char?[3, 3]);
    }
    
    [Fact]
    public void Start_A_New_Game_With_First_Player_As_X()
    {
        new TicTacToeGame().CurrentPlayer.Should().Be('X');
    }
    
    [Fact]
    public void Alternate_The_Current_Player_With_Each_Play()
    {
        var game = new TicTacToeGame();

        game.Play(0, 0);
        game.CurrentPlayer.Should().Be('O');
        
        game.Play(2, 2);
        game.CurrentPlayer.Should().Be('X');
        
        game.Play(1, 1);
        game.CurrentPlayer.Should().Be('O');
        
        game.Play(0, 1);
        game.CurrentPlayer.Should().Be('X');
    }
    
    [Fact]
    public void Place_An_X_Or_O_On_The_Correct_Square()
    {
        var game = new TicTacToeGame();

        game.Play(0, 0);
        game.Board[0, 0].Should().Be('X');
        
        game.Play(0, 1);
        game.Board[0, 1].Should().Be('O');
    }
    
    [Fact]
    public void Reject_Playing_On_An_Already_Played_Square()
    {
        var game = new TicTacToeGame();

        game.Play(0, 0).Should().Be(PlayResult.Accepted);
        game.Board[0, 0].Should().Be('X');
        
        game.Play(0, 0).Should().Be(PlayResult.Rejected);
        game.Board[0, 0].Should().Be('X');
    }
    
    [Fact]
    public void Draw_A_Game_If_All_Squares_Are_Filled_With_No_3_In_A_Row()
    {
        var game = new TicTacToeGame();

        game.Play(0, 0).Should().Be(PlayResult.Accepted);
        game.Play(0, 1).Should().Be(PlayResult.Accepted); 
        game.Play(0, 2).Should().Be(PlayResult.Accepted);
        game.Play(2, 0).Should().Be(PlayResult.Accepted);
        game.Play(2, 1).Should().Be(PlayResult.Accepted);
        game.Play(2, 2).Should().Be(PlayResult.Accepted);
        game.Play(1, 0).Should().Be(PlayResult.Accepted);
        game.Play(1, 1).Should().Be(PlayResult.Accepted);
        game.Play(1, 2).Should().Be(PlayResult.Draw);
    }
    
    [Theory, MemberData(nameof(WinningPlaysForPlayerX))]
    public void PlayerX_Win_If_There_Are_3_Xs_In_A_Row(
        (int x, int y) xPlay1,
        (int x, int y) xPlay2,
        (int x, int y) xPlay3,
        (int x, int y) oPlay1,
        (int x, int y) oPlay2,
        string expectedWinningRow)
    {
        var game = new TicTacToeGame();

        game.Play(xPlay1.x, xPlay1.y).Should().Be(PlayResult.Accepted);
        game.Play(oPlay1.x, oPlay1.y).Should().Be(PlayResult.Accepted);
        game.Play(xPlay2.x, xPlay2.y).Should().Be(PlayResult.Accepted);
        game.Play(oPlay2.x, oPlay2.y).Should().Be(PlayResult.Accepted);
        game.Play(xPlay3.x, xPlay3.y).Should().Be(PlayResult.PlayerXWins, expectedWinningRow);
    }
    
    public static TheoryData<(int, int), (int, int), (int, int), (int, int), (int, int), string> WinningPlaysForPlayerX =>
        new()
        {
            { (0, 0), (0, 1), (0, 2), (1, 1), (2, 2), "column 1 wins" }, 
            { (1, 0), (1, 1), (1, 2), (0, 0), (2, 2), "column 2 wins" },
            { (2, 0), (2, 1), (2, 2), (0, 0), (1, 1), "column 3 wins"},
            { (0, 0), (1, 0), (2, 0), (1, 1), (2, 2) , "row 1 wins"},
            { (0, 1), (1, 1), (2, 1), (0, 0), (2, 2) , "row 2 wins"},
            { (0, 2), (1, 2), (2, 2), (0, 0), (1, 1) , "row 3 wins"},
            { (0, 0), (1, 1), (2, 2), (0, 1), (1, 2) , "bottom left -> top right diagonal wins"},
            { (0, 2), (1, 1), (2, 0), (0, 1), (1, 2) , "top left -> bottom right diagonal wins"}
        };
    
    [Theory, MemberData(nameof(WinningPlaysForPlayerO))]
    public void PlayerO_Win_If_There_Are_3_Xs_In_A_Row(
        (int x, int y) oPlay1,
        (int x, int y) oPlay2,
        (int x, int y) oPlay3,
        (int x, int y) xPlay1,
        (int x, int y) xPlay2,
        (int x, int y) xPlay3,
        string expectedWinningRow)
    {
        var game = new TicTacToeGame();

        game.Play(xPlay1.x, xPlay1.y).Should().Be(PlayResult.Accepted);
        game.Play(oPlay1.x, oPlay1.y).Should().Be(PlayResult.Accepted);
        game.Play(xPlay2.x, xPlay2.y).Should().Be(PlayResult.Accepted);
        game.Play(oPlay2.x, oPlay2.y).Should().Be(PlayResult.Accepted);
        game.Play(xPlay3.x, xPlay3.y).Should().Be(PlayResult.Accepted);
        game.Play(oPlay3.x, oPlay3.y).Should().Be(PlayResult.PlayerOWins, expectedWinningRow);
    }
    
    public static TheoryData<(int, int), (int, int), (int, int), (int, int), (int, int), (int, int), string> WinningPlaysForPlayerO =>
        new()
        {
            { (0, 0), (0, 1), (0, 2), (1, 1), (2, 2), (1, 2), "column 1 wins" }, 
            { (1, 0), (1, 1), (1, 2), (0, 0), (2, 2), (2, 1),  "column 2 wins" },
            { (2, 0), (2, 1), (2, 2), (0, 0), (1, 1), (1, 2), "column 3 wins"},
            { (0, 0), (1, 0), (2, 0), (1, 1), (2, 2), (1, 2), "row 1 wins"},
            { (0, 1), (1, 1), (2, 1), (0, 0), (2, 2), (1, 2), "row 2 wins"},
            { (0, 2), (1, 2), (2, 2), (0, 0), (1, 1), (2, 1), "row 3 wins"},
            { (0, 0), (1, 1), (2, 2), (0, 1), (1, 2), (2, 1), "bottom left -> top right diagonal wins"},
            { (0, 2), (1, 1), (2, 0), (0, 1), (1, 2), (2, 1), "top left -> bottom right diagonal wins"}
        };
}