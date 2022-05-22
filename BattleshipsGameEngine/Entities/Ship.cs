using BattleshipsGameEngine.Enums;

namespace BattleshipsGameEngine.Entities;

public class Ship
{
    public byte X { get; set; }
    public byte Y { get; set; }
    public Direction Direction { get; set; }
    public bool[] Masts { get; set; }

    public int Size => Masts.Length;

    public bool this[int idx]
    {
        get => Masts[idx];
        set => Masts[idx] = value;
    }

    public Ship(byte x, byte y, int size, Direction direction)
    {
        X = x;
        Y = y;
        Direction = direction;
        Masts = new bool[size];
        _initializeMasts();
    }

    private void _initializeMasts()
    {
        for (int i = 0; i < Masts.Length; i++)
        {
            Masts[i] = true;
        }
    }

    public bool IsSunk()
    {
        bool isSunk = true;
        foreach (var mast in Masts)
        {
            if (mast)
            {
                isSunk = false;
                break;
            }
        }
        return isSunk;
    }

}