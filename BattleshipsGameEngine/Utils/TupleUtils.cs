namespace BattleshipsGameEngine.Utils;

public static class TupleUtils
{
    public static bool IsBetween(this (byte x, byte y) tuple, int start, int end)
    {
        if (tuple.x >= start && tuple.x <= end && tuple.y >= start && tuple.y <= end)
            return true;
        return false;
    }
}