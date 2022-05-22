using BattleshipsGameEngine.Entities;
using BattleshipsGameEngine.Enums;

namespace BattleshipsGameEngine.Tests;

public class BoardTests
{
    [Fact]
    public void PlaceShip_Two_Horizontally_Should_Return_True()
    {
        Board board = new Board(10);
        Ship firstShip = new Ship(4, 7, 4, Direction.Horizontal);
        Ship secondShip = new Ship(1, 3, 3, Direction.Horizontal);
        board.PlaceShip(firstShip);
        
        Assert.True(board.PlaceShip(secondShip));
    }

    [Fact]
    public void PlaceShip_One_Horizontally_One_Vertically_Should_Return_False()
    {
        Board board = new Board(10);
        
        Ship firstShip = new Ship(3, 1, 3, Direction.Horizontal);
        Ship secondShip = new Ship(4, 1, 3, Direction.Vertical);
        board.PlaceShip(firstShip);
        
        Assert.False(board.PlaceShip(secondShip));
    }
    
    [Fact]
    public void PlaceShip_Two_Vertically_Should_Return_False()
    {
        Board board = new Board(10);
        Ship firstShip = new Ship(0, 0, 4, Direction.Vertical);
        Ship secondShip = new Ship(0, 1, 4, Direction.Vertical);
        board.PlaceShip(firstShip);

        Assert.False(board.PlaceShip(secondShip));
    }

    [Fact]
    public void PlaceShip_Two_Horizontally_Should_Return_False()
    {
        Board board = new Board(10);
        Ship firstShip = new Ship(0, 0, 4, Direction.Horizontal);
        Ship secondShip = new Ship(1, 0, 4, Direction.Horizontal);
        board.PlaceShip(firstShip);

        Assert.False(board.PlaceShip(secondShip));
    }
    
    [Fact]
    public void PlaceShip_Horizontally_Outside_Array_Should_Return_False()
    {
        Board board = new Board(10);
        Ship firstShip = new Ship(0, 8, 4, Direction.Horizontal);

        Assert.False(board.PlaceShip(firstShip));
    }
    
    [Fact]
    public void PlaceShip_Vertically_Outside_Array_Should_Return_False()
    {
        Board board = new Board(10);
        Ship firstShip = new Ship(8, 0, 4, Direction.Horizontal);

        Assert.False(board.PlaceShip(firstShip));
    }

    [Fact]
    public void PlaceShip_One_Vertically_One_Horizontally_Should_Return_False()
    {
        Board board = new Board(10);
        Ship firstShip = new Ship(3, 1, 3, Direction.Horizontal);
        Ship secondShip = new Ship(2, 0, 3, Direction.Vertical);
        board.PlaceShip(firstShip);
        Assert.False(board.PlaceShip(secondShip));
    }
}