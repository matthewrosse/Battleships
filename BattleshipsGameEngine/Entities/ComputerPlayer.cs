using BattleshipsGameEngine.Enums;
using BattleshipsGameEngine.Utils;

namespace BattleshipsGameEngine.Entities;

public class ComputerPlayer : Player
{
    public readonly Queue<(byte x, byte y)> ShotsQueue;
    public ComputerPlayer(int boardSize, int amountOfShips) : base(boardSize, amountOfShips)
    {
        Name = "Bot";
        ShotsQueue = new Queue<(byte x, byte y)>();
    }

    public override (byte x, byte y)? Shoot(byte x, byte y)
    {
        BoardCellStatus cellStatus;

        if (ShotsQueue.Count > 0)
        {
            (byte x, byte y) shot = ShotsQueue.Dequeue();
            if (shot.IsBetween(0, BoardSize - 1))
            {
                cellStatus = Hits.MarkShot(shot.x, shot.y);
                if (cellStatus is BoardCellStatus.Occupied)
                    return null;
                // add neighbor cells to shots queue.
                return shot;
            }
        }
        else
        {
            Random r = new Random();
            byte xx = (byte)r.Next(BoardSize);
            byte yy = (byte)r.Next(BoardSize);
            cellStatus = Hits.MarkShot(xx, yy);
            if (cellStatus is BoardCellStatus.Occupied)
                return null;
            return (xx, yy);
        }

        return null;
        // i have to test it
    }
}