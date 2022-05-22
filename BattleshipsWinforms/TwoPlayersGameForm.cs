using BattleshipsGameEngine.Entities;
using BattleshipsGameEngine.Enums;
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
        Player currentPlayer;
        Player waitingPlayer;
        int numOfCells;
        int cellSize;
        byte boardSize = 10;
        int amountOfShips = 7;

        bool userDocksShipsManuallyMode = false;
        public TwoPlayersGameForm(GameMode gameMode, string firstPlayerName, string secondPlayerName)
        {
            InitializeComponent();
            _gameMode = gameMode;
            currentPlayer = new HumanPlayer(boardSize, amountOfShips, firstPlayerName);
            waitingPlayer = new HumanPlayer(boardSize, amountOfShips, secondPlayerName);
        }

        private void PlayerFleetPictureBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlayerHitsPictureBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlayerHitsPictureBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ManuallyDockedShipsPictureBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ManuallyDockedShipsPictureBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlaceShipsManuallyButton_Click(object sender, EventArgs e)
        {
            PlaceShipsManuallyButton.Visible = false;
            PlaceShipsAutomaticallyButton.Visible = false;
            ConfirmShipsPlacementButton.Visible = true;
            ManuallyDockedShipsPictureBox.Visible = true;
            // zmiana gracza
        }

        private void ConfirmShipsPlacementButton_Click(object sender, EventArgs e)
        {

        }

        private void PlaceShipsAutomaticallyButton_Click(object sender, EventArgs e)
        {
            PlaceShipsManuallyButton.Visible = false;
            PlaceShipsAutomaticallyButton.Visible = false;
            ConfirmShipsPlacementButton.Visible = true;
        }

        private void DrawGrid(Graphics graphics)
        {
            for (int i = 0; i < numOfCells; i++)
            {
                for (int j = 0; j < numOfCells; j++)
                {
                    switch (currentPlayer.Fleet[i, j])
                    {
                        case BoardCellStatus.Present:
                            graphics.FillRectangle(new SolidBrush(Color.Green), j * cellSize, i * cellSize, cellSize, cellSize);
                            break;
                        case BoardCellStatus.Empty:
                            graphics.FillRectangle(new SolidBrush(Color.Blue), j * cellSize, i * cellSize, cellSize, cellSize);
                            break;
                        case BoardCellStatus.Hit:
                            graphics.FillRectangle(new SolidBrush(Color.Red), j * cellSize, i * cellSize, cellSize, cellSize);
                            break;
                        case BoardCellStatus.Miss:
                            graphics.FillRectangle(new SolidBrush(Color.DarkGray), j * cellSize, i * cellSize, cellSize, cellSize);
                            break;
                        case BoardCellStatus.Occupied:
                            graphics.FillRectangle(new SolidBrush(Color.Magenta), j * cellSize, i * cellSize, cellSize, cellSize);
                            break;
                    }
                }
            }

        }
        private void FillGrid(Graphics graphics)
        {
            using Pen pen = new Pen(Brushes.Black);
            for (int i = 0; i <= numOfCells; i++)
            {
                // vertical
                graphics.DrawLine(pen, i * cellSize, 0, i * cellSize, numOfCells * cellSize);
                // horizontal
                graphics.DrawLine(pen, 0, i * cellSize, numOfCells * cellSize, i * cellSize);
            }
        }
    }
}
