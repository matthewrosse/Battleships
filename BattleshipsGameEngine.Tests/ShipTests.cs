using BattleshipsGameEngine.Entities;
using BattleshipsGameEngine.Enums;

namespace BattleshipsGameEngine.Tests;

public class ShipTests
{
    [Fact]
    public void Creating_Ship_Should_Return_All_True_Masts()
    {
        Ship ship = new Ship(1, 2, 6, Direction.Horizontal);
            bool isAnyMastSunk = false;
            foreach (var mast in ship.Masts)
            {
                if (!mast)
                {
                    isAnyMastSunk = true;
                    break;
                }
            }
            Assert.False(isAnyMastSunk);
    }

    [Fact]
    public void IsSunk_Should_Return_True()
    {
        Ship ship = new Ship(1, 2, 6, Direction.Horizontal);
        for (int i = 0; i < ship.Masts.Length; i++)
        {
            ship.Masts[i] = false;
        }

        Assert.True(ship.IsSunk());
    }
    [Fact]
    public void IsSunk_One_Mast_Hit_Should_Return_False()
    {
        Ship ship = new Ship(1, 2, 6, Direction.Horizontal);
        ship.Masts[0] = false;

        Assert.False(ship.IsSunk());
    }
    [Fact]
    public void IsSunk_Healthy_Ship_Should_Return_False()
    {
        Ship ship = new Ship(1, 2, 6, Direction.Horizontal);
        Assert.False(ship.IsSunk());
    }
    
}