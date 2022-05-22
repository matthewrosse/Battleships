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

        }

        private void ConfirmShipsPlacementButton_Click(object sender, EventArgs e)
        {

        }

        private void PlaceShipsAutomaticallyButton_Click(object sender, EventArgs e)
        {

        }
    }
}
