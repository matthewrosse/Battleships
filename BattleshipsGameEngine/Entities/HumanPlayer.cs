using BattleshipsGameEngine.Enums;
using BattleshipsGameEngine.Utils;

namespace BattleshipsGameEngine.Entities;

public class HumanPlayer : Player
{
    public HumanPlayer(int boardSize, int amountOfShips, string name) : base(boardSize, amountOfShips)
    {
        Name = name;
    }

    public bool PlaceShipsManually(IList<Ship> shipsToBePlaced)
    {
        var result = true;
        foreach (var ship in shipsToBePlaced)
        {
            result = Fleet.PlaceShip(ship);
            if (result)
            {
                listOfShips.Add(ship);
                continue;
            }
            // clean up the board
            Fleet.CleanUpBoard();
            break;
        }

        return result;
    }

    public override (byte x, byte y)? Shoot(byte x, byte y)
    {
        if (!(x, y).IsBetween(0, BoardSize - 1))
        {
            return null;
        }

        var potentialCell = Hits.MarkShot(x, y);
        if (potentialCell is BoardCellStatus.Occupied)
        {
            return null;
        }

        return (x, y);
    }
}