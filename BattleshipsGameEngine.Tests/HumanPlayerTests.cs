using BattleshipsGameEngine.Entities;
using BattleshipsGameEngine.Enums;

namespace BattleshipsGameEngine.Tests;

public class HumanPlayerTests
{
   [Fact]
   public void PlaceShipManually_Should_Return_True()
   {
      HumanPlayer humanPlayer = new HumanPlayer(10, 6, "Mateusz");
      List<Ship> listOfShips = new List<Ship>()
      {
         new Ship(8, 2, 6, Direction.Horizontal),
         new Ship(6, 4, 5, Direction.Horizontal),
         new Ship(4, 1, 4, Direction.Horizontal),
         new Ship(1, 9, 3, Direction.Vertical),
         new Ship(2, 3, 2, Direction.Horizontal),
         new Ship(2, 7, 2, Direction.Vertical),
      };
      Assert.True(humanPlayer.PlaceShipsManually(listOfShips));
   }
   
   [Fact]
   public void PlaceShipManually_Should_Return_False()
   {
      HumanPlayer humanPlayer = new HumanPlayer(10, 6, "Mateusz");
      List<Ship> listOfShips = new List<Ship>()
      {
         new Ship(0, 2, 6, Direction.Horizontal),
         new Ship(1, 2, 5, Direction.Horizontal),
         new Ship(4, 1, 4, Direction.Horizontal),
         new Ship(1, 9, 3, Direction.Vertical),
         new Ship(2, 3, 2, Direction.Horizontal),
         new Ship(2, 7, 2, Direction.Vertical),
      };
      Assert.False(humanPlayer.PlaceShipsManually(listOfShips));
   }
}