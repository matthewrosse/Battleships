using BattleshipsGameEngine.Entities;
using BattleshipsGameEngine.Enums;
using BattleshipsWinforms.Entities;
using BattleshipsWinforms.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipsWinforms
{
    public partial class PlayWithBotForm : Form
    {
        GameMode _gameMode;
        readonly int _boardSize = 10;
        readonly int _amountOfShips = 7;
        HumanPlayer _humanPlayer;
        ComputerPlayer _computerPlayer;
        readonly int _numOfCells;
        readonly int _cellSize;
        readonly List<VisualShip> _listOfVisualShips;
        VisualShip _clickedVisualShip;
        bool _mouseClickedOnVisualShip = false;
        public PlayWithBotForm(GameMode gameMode, string playerName)
        {
            InitializeComponent();
            _gameMode = gameMode;
            _humanPlayer = new HumanPlayer(_boardSize, _amountOfShips, playerName);
            _computerPlayer = new ComputerPlayer(_boardSize, _amountOfShips);
            _numOfCells = _boardSize;
            _cellSize = PlayerHitsPictureBox.Width / _numOfCells;
            _listOfVisualShips = new List<VisualShip>()
            {
                new VisualShip(Direction.Vertical,Color.Green, 6, _cellSize, 0, 0),
                new VisualShip(Direction.Vertical,Color.Green, 5, _cellSize, 1, 0),
                new VisualShip(Direction.Vertical,Color.Green, 4, _cellSize, 2, 0),
                new VisualShip(Direction.Vertical,Color.Green, 3, _cellSize, 3, 0),
                new VisualShip(Direction.Vertical,Color.Green, 2, _cellSize, 4, 0),
                new VisualShip(Direction.Vertical,Color.Green, 2, _cellSize, 5, 0),
            };
            _computerPlayer.PlaceShipsRandomly();
        }

        private void PlayerFleetPictureBox_Paint(object sender, PaintEventArgs e)
        {
            FillGrid(e.Graphics, FillGridOptions.Fleet);
            DrawGrid(e.Graphics);
        }

        private void PlayerHitsPictureBox_Paint(object sender, PaintEventArgs e)
        {
            FillGrid(e.Graphics, FillGridOptions.Hits);
            DrawGrid(e.Graphics);
        }

        private void PlayerHitsPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var coords = PlayerHitsPictureBox.PointToClient(Cursor.Position);

            int row = coords.Y / _cellSize;
            int col = coords.X / _cellSize;
            if (row > _numOfCells - 1 || col > _numOfCells - 1)
                return;

            var shotTuple = _humanPlayer.Shoot((byte)row, (byte)col);
            if (shotTuple is null)
            {
                MessageBox.Show("You've chosen wrong coordinates!");
                return;
            }
            _humanPlayer.Hits[shotTuple.Value.x, shotTuple.Value.y] = _computerPlayer.Fleet.MarkShot(shotTuple.Value.x, shotTuple.Value.y);
            _computerPlayer.Fleet.ExecuteShot(shotTuple.Value.x, shotTuple.Value.y);

            if (_computerPlayer.AreAllShipsSunk())
            {
                MessageBox.Show($"{_humanPlayer.Name} has won the game!");
                Close();
                return;
            }

            PlayerFleetPictureBox.Invalidate();
            PlayerHitsPictureBox.Invalidate();
            // koniec oddania strzalu uzytkownika
            // teraz bot

            do
            {
                shotTuple = _computerPlayer.Shoot((byte)row, (byte)col);
            }
            while (shotTuple is null);
            _computerPlayer.Hits[shotTuple.Value.x, shotTuple.Value.y] = _humanPlayer.Fleet.MarkShot(shotTuple.Value.x, shotTuple.Value.y);
            _humanPlayer.Fleet.ExecuteShot(shotTuple.Value.x, shotTuple.Value.y);
            if (_humanPlayer.AreAllShipsSunk())
            {
                MessageBox.Show($"{_computerPlayer.Name} has won the game!");
                Close();
            }
        }

        private void ManuallyDockedShipsPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _clickedVisualShip?.ChangeOrientation();
                return;
            }
            var coords = ManuallyDockedShipsPictureBox.PointToClient(Cursor.Position);
            if (_mouseClickedOnVisualShip)
            {
                _clickedVisualShip.Move((coords.X / _cellSize) * _cellSize, (coords.Y / _cellSize) * _cellSize);
                _mouseClickedOnVisualShip = false;
                ManuallyDockedShipsPictureBox.Invalidate();
                return;
            }
            foreach (var visualShip in _listOfVisualShips.Where(visualShip => visualShip.IsClicked(e.X, e.Y)))
            {
                _mouseClickedOnVisualShip = true;
                _clickedVisualShip = visualShip;
                return;
            }
        }

        private void ManuallyDockedShipsPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseClickedOnVisualShip) return;
            _clickedVisualShip.Move(e.X, e.Y);
            ManuallyDockedShipsPictureBox.Invalidate();
        }

        private void ManuallyDockedShipsPictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (var visualShip in _listOfVisualShips)
            {
                visualShip.Draw(e.Graphics);
            }
            DrawGrid(e.Graphics);
            ManuallyDockedShipsAlphabetPanel.Visible = true;
            ManuallyDockedShipsNumericalPanel.Visible = true;
        }

        private void FillGrid(Graphics graphics, FillGridOptions fillGridOption)
        {
            var boardToPrint = fillGridOption switch
            {
                FillGridOptions.Fleet => _humanPlayer.Fleet,
                FillGridOptions.Hits => _humanPlayer.Hits,
                _ => throw new InvalidEnumArgumentException()
            };

            for (int i = 0; i < _numOfCells; i++)
            {
                for (int j = 0; j < _numOfCells; j++)
                {
                    switch (boardToPrint[i, j])
                    {
                        case BoardCellStatus.Present:
                            graphics.FillRectangle(new SolidBrush(Color.Green), j * _cellSize, i * _cellSize, _cellSize, _cellSize);
                            break;
                        case BoardCellStatus.Empty:
                            graphics.FillRectangle(new SolidBrush(Color.LightSkyBlue), j * _cellSize, i * _cellSize, _cellSize, _cellSize);
                            break;
                        case BoardCellStatus.Hit:
                            graphics.FillRectangle(new SolidBrush(Color.Red), j * _cellSize, i * _cellSize, _cellSize, _cellSize);
                            break;
                        case BoardCellStatus.Miss:
                            graphics.FillRectangle(new SolidBrush(Color.DarkGray), j * _cellSize, i * _cellSize, _cellSize, _cellSize);
                            break;
                        case BoardCellStatus.Occupied:
                            graphics.FillRectangle(new SolidBrush(Color.Magenta), j * _cellSize, i * _cellSize, _cellSize, _cellSize);
                            break;
                    }
                }
            }

        }
        private void DrawGrid(Graphics graphics)
        {
            using Pen pen = new Pen(Brushes.Black);
            for (int i = 0; i <= _numOfCells; i++)
            {
                // vertical
                graphics.DrawLine(pen, i * _cellSize, 0, i * _cellSize, _numOfCells * _cellSize);
                // horizontal
                graphics.DrawLine(pen, 0, i * _cellSize, _numOfCells * _cellSize, i * _cellSize);
            }
        }

        private void PlaceShipsManuallyButton_Click(object sender, EventArgs e)
        {
            PlaceShipsManuallyButton.Visible = false;
            PlaceShipsAutomaticallyButton.Visible = false;
            ConfirmShipsPlacementButton.Visible = true;
            ManuallyDockedShipsPictureBox.Visible = true;
        }

        private void PlaceShipsAutomaticallyButton_Click(object sender, EventArgs e)
        {
            _humanPlayer.PlaceShipsRandomly();
            PlaceShipsManuallyButton.Visible = false;
            PlaceShipsAutomaticallyButton.Visible = false;
            ConfirmShipsPlacementButton.Visible = false;
            PlayerFleetPictureBox.Visible = true;
            PlayerHitsPictureBox.Visible = true;
            PlayerFleetAlphabetPanel.Visible = true;
            PlayerFleetNumericalPanel.Visible = true;
            PlayerHitsAlphabetPanel.Visible = true;
            PlayerHitsNumericalPanel.Visible = true;
        }

        private void ConfirmShipsPlacementButton_Click(object sender, EventArgs e)
        {
            if (_mouseClickedOnVisualShip)
            {
                MessageBox.Show("Place every ship to play!");
                return;
            }
            var listOfShips = _listOfVisualShips.Select(x => x.ToGameEngineShip()).ToList();
            bool result = _humanPlayer.PlaceShipsManually(listOfShips);
            if (!result)
            {
                MessageBox.Show("You've placed ships incorrectly, please try again!");
                return;
            }

            PlaceShipsManuallyButton.Visible = false;
            PlaceShipsAutomaticallyButton.Visible = false;
            ConfirmShipsPlacementButton.Visible = false;
            ManuallyDockedShipsPictureBox.Visible = false;
            PlayerFleetPictureBox.Visible = true;
            PlayerHitsPictureBox.Visible = true;
            PlayerFleetAlphabetPanel.Visible = true;
            PlayerFleetNumericalPanel.Visible = true;
            PlayerHitsAlphabetPanel.Visible = true;
            PlayerHitsNumericalPanel.Visible = true;
            ManuallyDockedShipsAlphabetPanel.Visible = false;
            ManuallyDockedShipsNumericalPanel.Visible = false;
        }
    }
}
