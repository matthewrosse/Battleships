using BattleshipsGameEngine.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsWinforms.Entities
{
    internal class VisualShip
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int indexX { get; set; }
        public int indexY { get; set; }
        public Direction Direction { get; set; }
        public int Length { get; set; }
        public Color Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        private int _cellSize;

        public VisualShip(Direction direction, Color color, int length, int cellSize, int x, int y)
        {
            Direction = direction;
            Length = length;
            _cellSize = cellSize;
            if (Direction is Direction.Vertical)
            {
                Width = _cellSize;
                Height = Length * _cellSize;
            }
            else
            {
                Width = Length * _cellSize;
                Height = _cellSize;
            }
            X = x * _cellSize;
            Y = y * _cellSize;
            indexX = y;
            indexY = x;
            Color = color;
        }

        public void Draw(Graphics graphics)
        {
            Brush brush = new SolidBrush(Color);
            graphics.FillRectangle(brush, X, Y, Width, Height);
        }

        public void Move(int x, int y)
        {
            X = x;
            Y = y;
            indexX = Y / _cellSize;
            indexY = X / _cellSize;
        }

        public bool IsClicked(int x, int y)
        {
            if (x >= X && x <= X + Width && y >= Y && y <= Y + Height)
                return true;
            return false;
        }

        public void ChangeOrientation()
        {
            int tmp = Height;
            Height = Width;
            Width = tmp;
            Direction = Direction == Direction.Vertical ? Direction.Horizontal : Direction.Vertical;
        }

    }
}
