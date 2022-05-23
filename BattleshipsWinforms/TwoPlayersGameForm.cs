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
    public partial class TwoPlayersGameForm : Form
    {
        GameMode _gameMode;
        HumanPlayer _currentPlayer;
        HumanPlayer _waitingPlayer;
        readonly int _numOfCells;
        readonly int _cellSize;
        readonly byte boardSize = 10;
        readonly int amountOfShips = 7;
        int _playersThatPlacedTheirShips = 0;
         List<VisualShip> _listOfVisualShips;
        VisualShip _clickedVisualShip;
        bool _mouseClickedOnVisualShip = false;

        public TwoPlayersGameForm(GameMode gameMode, string firstPlayerName, string secondPlayerName)
        {
            InitializeComponent();
            _gameMode = gameMode;
            _numOfCells = boardSize;
            _cellSize = PlayerHitsPictureBox.Width / _numOfCells;
            _currentPlayer = new HumanPlayer(boardSize, amountOfShips, firstPlayerName);
            _waitingPlayer = new HumanPlayer(boardSize, amountOfShips, secondPlayerName);
            PromptLabel.Visible = true;
            PromptLabel.Text = $"{_currentPlayer.Name}, dock your battleships!";
            ResetListOfVisualShips();
        }

        private void ResetListOfVisualShips()
        {
            _listOfVisualShips = new List<VisualShip>()
            {
                new VisualShip(Direction.Vertical,Color.FromArgb(138,181,225), 6, _cellSize, 0, 0),
                new VisualShip(Direction.Vertical,Color.FromArgb(138,181,225), 5, _cellSize, 1, 0),
                new VisualShip(Direction.Vertical,Color.FromArgb(138,181,225), 4, _cellSize, 2, 0),
                new VisualShip(Direction.Vertical,Color.FromArgb(138,181,225), 3, _cellSize, 3, 0),
                new VisualShip(Direction.Vertical,Color.FromArgb(138,181,225), 2, _cellSize, 4, 0),
                new VisualShip(Direction.Vertical,Color.FromArgb(138,181,225), 2, _cellSize, 5, 0),
            };
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

            var shotTuple = _currentPlayer.Shoot((byte)row, (byte)col);
            if (shotTuple is null)
            {
                MessageBox.Show("You've chosen wrong coordinates!");
                return;
            }
            _currentPlayer.Hits[shotTuple.Value.x, shotTuple.Value.y] = _waitingPlayer.Fleet.MarkShot(shotTuple.Value.x, shotTuple.Value.y);
            _waitingPlayer.Fleet.ExecuteShot(shotTuple.Value.x, shotTuple.Value.y);

            if (_waitingPlayer.AreAllShipsSunk())
            {
                MessageBox.Show($"{_currentPlayer.Name} has won the game!");
                Close();
            }

            (_currentPlayer, _waitingPlayer) = (_waitingPlayer, _currentPlayer);
            PromptLabel.Text = $"{_currentPlayer.Name}, it's your turn!";
            PlayerFleetPictureBox.Invalidate();
            PlayerHitsPictureBox.Invalidate();
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

        private void PlaceShipsManuallyButton_Click(object sender, EventArgs e)
        {
            PlaceShipsManuallyButton.Visible = false;
            PlaceShipsAutomaticallyButton.Visible = false;
            ConfirmShipsPlacementButton.Visible = true;
            ManuallyDockedShipsPictureBox.Visible = true;
        }

        private void ConfirmShipsPlacementButton_Click(object sender, EventArgs e)
        {
            if (_mouseClickedOnVisualShip)
            {
                MessageBox.Show("Place every ship to play!");
                return;
            }
            var listOfShips = _listOfVisualShips.Select(x => x.ToGameEngineShip()).ToList();
            bool result = _currentPlayer.PlaceShipsManually(listOfShips);
            if (!result)
            {
                MessageBox.Show("You've placed ships incorrectly, please try again!");
                return;
            }
            (_currentPlayer, _waitingPlayer) = (_waitingPlayer, _currentPlayer);
            PromptLabel.Text = $"{_currentPlayer.Name}, place your ships!";
            ManuallyDockedShipsPictureBox.Visible = false;
            ConfirmShipsPlacementButton.Visible = false;
            PlaceShipsManuallyButton.Visible = true;
            PlaceShipsAutomaticallyButton.Visible = true;
            ManuallyDockedShipsAlphabetPanel.Visible = false;
            ManuallyDockedShipsNumericalPanel.Visible = false;

            _playersThatPlacedTheirShips++;
            ResetListOfVisualShips();
            if (_playersThatPlacedTheirShips < 2) return;
            PromptLabel.Text = $"{_currentPlayer.Name}, it's your turn!";
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

        private void PlaceShipsAutomaticallyButton_Click(object sender, EventArgs e)
        {
            //ToggleShipPlacementButtons();
            _currentPlayer.PlaceShipsRandomly();
            //ToggleShipPlacementButtons();
            (_currentPlayer, _waitingPlayer) = (_waitingPlayer, _currentPlayer);
            PromptLabel.Text = $"{_currentPlayer.Name}, dock your ships!";
            _playersThatPlacedTheirShips++;
            if (_playersThatPlacedTheirShips < 2) return;
            PromptLabel.Text = $"{_currentPlayer.Name}, it's your turn!";
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

        private void ToggleShipPlacementButtons()
        {
            PlaceShipsManuallyButton.Visible ^= true;
            PlaceShipsAutomaticallyButton.Visible ^= true;
            ConfirmShipsPlacementButton.Visible ^= true;
        }

        private void FillGrid(Graphics graphics, FillGridOptions fillGridOption)
        {
            var boardToPrint = fillGridOption switch
            {
                FillGridOptions.Fleet => _currentPlayer.Fleet,
                FillGridOptions.Hits => _currentPlayer.Hits,
                _ => throw new InvalidEnumArgumentException()
            };

            for (int i = 0; i < _numOfCells; i++)
            {
                for (int j = 0; j < _numOfCells; j++)
                {
                    switch (boardToPrint[i, j])
                    {
                        case BoardCellStatus.Present:
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(83,137, 191)), j * _cellSize, i * _cellSize, _cellSize, _cellSize);
                            break;
                        case BoardCellStatus.Empty:
                            graphics.FillRectangle(new SolidBrush(Color.White), j * _cellSize, i * _cellSize, _cellSize, _cellSize);
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
    }
}
