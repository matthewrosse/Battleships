using BattleshipsGameEngine.Enums;

namespace BattleshipsGameEngine.Entities;

public abstract class Player
{
    public string Name { get; set; }
    protected IList<Ship> listOfShips;
    public Board Fleet { get; set; }
    public Board Hits { get; set; }
    protected int BoardSize;
    protected int AmountOfShips;

    public Player(int boardSize, int amountOfShips)
    {
        BoardSize = boardSize;
        AmountOfShips = amountOfShips;
        listOfShips = new List<Ship>(AmountOfShips);
        Fleet = new Board(BoardSize);
        Hits = new Board(BoardSize);
    }

    public void PlaceShipsRandomly()
    {
        Random r = new Random();
        byte size, x, y;
        Direction direction;

        for (int i = 0; i < AmountOfShips; i++)
        {
            size = i switch
            {
                0 => 6,
                1 or 2 => 4,
                3 or 4 => 3,
                _ => 2,
            };

            bool result = false;
            while (result is false)
            {
                x = (byte)r.Next(BoardSize);
                y = (byte)r.Next(BoardSize);
                int k = r.Next(2);

                direction = k switch
                {
                    0 => Direction.Horizontal,
                    1 => Direction.Vertical,
                    _ => throw new ArgumentException(),
                };

                Ship ship = new Ship(x, y, size, direction);
                result = Fleet.PlaceShip(ship);
                if (result)
                {
                    listOfShips.Add(ship);
                }
            }
        } 
    }

    public bool AreAllShipsSunk()
    {
        bool allShipsSunk = true;

        foreach (var ship in listOfShips)
        {
            if (!ship.IsSunk())
            {
                allShipsSunk = false;
                break;
            }
        }

        return allShipsSunk;
    }

    public abstract (byte x, byte y)? Shoot(byte x, byte y);
}