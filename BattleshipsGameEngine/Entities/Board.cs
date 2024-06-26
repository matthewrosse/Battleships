﻿using BattleshipsGameEngine.Enums;

namespace BattleshipsGameEngine.Entities;

public class Board
{
    public BoardCell[,] BoardCells { get; }
    
    public BoardCellStatus this[int x, int y]
    {
        get => BoardCells[x, y].CellStatus;
        set => BoardCells[x, y].CellStatus = value;
    }

    public Board(int size)
    {
        BoardCells = new BoardCell[size, size];
        _initializeBoard();
        CleanUpBoard();
    }

    private void _initializeBoard()
    {
        for (int i = 0; i < BoardCells.GetLength(0); i++)
        {
            for (int j = 0; j < BoardCells.GetLength(1); j++)
            {
                BoardCells[i, j] = new BoardCell();
            }
        }
    }

    public void CleanUpBoard()
    {
        for (int i = 0; i < BoardCells.GetLength(0); i++)
        {
            for (int j = 0; j < BoardCells.GetLength(1); j++)
            {
                BoardCells[i, j].CellStatus = BoardCellStatus.Empty;
                BoardCells[i, j].Ship = null;
            }
        }
    }

    public bool PlaceShip(Ship? ship)
    {
        if (ship is null)
        {
            return false;
        }

        int x = ship.X > 0 ? ship.X - 1 : 0;
        int y = ship.Y > 0 ? ship.Y - 1 : 0;

        int rowsCondition, columnsCondition, mastIndex, rowToUpdate, columnToUpdate;

        if (ship.Direction is Direction.Vertical)
        {
            if (ship.X + ship.Size > BoardCells.GetLength(0))
            {
                return false;
            }

            rowsCondition = ship.X + ship.Size < BoardCells.GetLength(0) ? ship.X + ship.Size : ship.X + ship.Size - 1;
            columnsCondition = ship.Y + 1 < BoardCells.GetLength(1) ? ship.Y + 1 : ship.Y;
            mastIndex = ship.X;
            rowToUpdate = mastIndex;
            columnToUpdate = ship.Y;
        }
        else
        {
            if (ship.Y + ship.Size > BoardCells.GetLength(1))
            {
                return false;
            }

            rowsCondition = ship.X + 1 < BoardCells.GetLength(0) ? ship.X + 1 : ship.X;
            columnsCondition = ship.Y + ship.Size < BoardCells.GetLength(1)
                ? ship.Y + ship.Size
                : ship.Y + ship.Size - 1;
            mastIndex = ship.Y;
            rowToUpdate = ship.X;
            columnToUpdate = mastIndex;
        }

        var result = _isAvailableSpaceForShip(x, y, rowsCondition, columnsCondition);
        if (!result)
        {
            return false;
        }
        
        _updateEmptyCellsWithShip(ship, rowToUpdate, columnToUpdate);

        return true;
    }

    private void _updateEmptyCellsWithShip(Ship ship, int row, int column)
    {
        for (int i = 0; i < ship.Size; i++)
        {
            BoardCells[row, column].CellStatus = BoardCellStatus.Present;
            BoardCells[row, column].Ship = ship;
            if (ship.Direction is Direction.Vertical)
            {
                row++;
            }
            else
            {
                column++;
            }
        }
    }

    private bool _isAvailableSpaceForShip(int startingRow, int startingColumn, int endingRow, int endingColumn)
    {
        for (int i = startingRow; i <= endingRow; i++)
        {
            for (int j = startingColumn; j <= endingColumn; j++)
            {
                if (BoardCells[i, j].CellStatus is BoardCellStatus.Present)
                    return false;
            }
        }

        return true;
    }

    public BoardCellStatus MarkShot(byte x, byte y)
    {
        var result = BoardCells[x, y].CellStatus switch
        {
            BoardCellStatus.Empty => BoardCellStatus.Miss,
            BoardCellStatus.Miss or BoardCellStatus.Hit or BoardCellStatus.Occupied => BoardCellStatus.Occupied,
            BoardCellStatus.Present => BoardCellStatus.Hit,
            _ => BoardCells[x, y].CellStatus
        };
        return result;
    }

    public Ship? ExecuteShot(byte x, byte y)
    {
        var ship = BoardCells[x, y].Ship;
        if (ship is null)
        {
            BoardCells[x, y].CellStatus = BoardCellStatus.Miss;
            return null;
        }

        if (ship.Direction is Direction.Horizontal && ship.X == x)
        {
            ship[y - ship.Y] = false;
            BoardCells[x, y].CellStatus = BoardCellStatus.Hit;
        }
        else if (ship.Direction is Direction.Vertical && ship.Y == y)
        {
            ship[x - ship.X] = false;
            BoardCells[x, y].CellStatus = BoardCellStatus.Hit;
        }

        return BoardCells[x, y].Ship;
    }
}