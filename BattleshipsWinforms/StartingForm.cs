using BattleshipsGameEngine.Enums;

namespace BattleshipsWinforms
{
    public partial class StartingForm : Form
    {
        public StartingForm()
        {
            InitializeComponent();
        }

        private void TwoPlayersGameButton_Click(object sender, EventArgs e)
        {
            TwoPlayersGameButton.Visible = false;
            PlayWithBotButton.Visible = false;
            FirstPlayerNameTextBox.Visible = true;
            SecondPlayerNameTextBox.Visible = true;
            ConfirmPlayersNamesButton.Visible = true;
        }

        private void PlayWithBotButton_Click(object sender, EventArgs e)
        {
            TwoPlayersGameButton.Visible = false;
            PlayWithBotButton.Visible = false;
            FirstPlayerNameTextBox.Visible = true;
            ConfirmPlayerNameButton.Visible = true;
        }

        private void ConfirmPlayerNameButton_Click(object sender, EventArgs e)
        {
            var playerName = FirstPlayerNameTextBox.Text;

            if (String.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Enter proper names.");
                return;
            }
            PlayWithBotForm playWithBotForm = new PlayWithBotForm(GameMode.HumanComputer, playerName);
        }

        private void ConfirmPlayersNamesButton_Click(object sender, EventArgs e)
        {
            var firstPlayerName = FirstPlayerNameTextBox.Text.Trim();
            var secondPlayerName = SecondPlayerNameTextBox.Text.Trim();
            if (String.IsNullOrEmpty(firstPlayerName) || String.IsNullOrEmpty(secondPlayerName))
            {
                MessageBox.Show("Enter proper names.");
                return;
            }    
            TwoPlayersGameForm twoPlayersGameForm = new TwoPlayersGameForm(GameMode.TwoHumans, firstPlayerName, secondPlayerName);
            Hide();
            twoPlayersGameForm.ShowDialog();
            Show();
        }
    }
}