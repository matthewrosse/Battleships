namespace BattleshipsWinforms
{
    partial class StartingForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TwoPlayersGameButton = new System.Windows.Forms.Button();
            this.PlayWithBotButton = new System.Windows.Forms.Button();
            this.FirstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.SecondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmPlayersNamesButton = new System.Windows.Forms.Button();
            this.ConfirmPlayerNameButton = new System.Windows.Forms.Button();
            this.FirstPlayerNameLabel = new System.Windows.Forms.Label();
            this.SecondPlayerNameLabel = new System.Windows.Forms.Label();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TwoPlayersGameButton
            // 
            this.TwoPlayersGameButton.Location = new System.Drawing.Point(514, 201);
            this.TwoPlayersGameButton.Name = "TwoPlayersGameButton";
            this.TwoPlayersGameButton.Size = new System.Drawing.Size(221, 93);
            this.TwoPlayersGameButton.TabIndex = 0;
            this.TwoPlayersGameButton.Text = "Two players game";
            this.TwoPlayersGameButton.UseVisualStyleBackColor = true;
            this.TwoPlayersGameButton.Click += new System.EventHandler(this.TwoPlayersGameButton_Click);
            // 
            // PlayWithBotButton
            // 
            this.PlayWithBotButton.Location = new System.Drawing.Point(514, 443);
            this.PlayWithBotButton.Name = "PlayWithBotButton";
            this.PlayWithBotButton.Size = new System.Drawing.Size(221, 93);
            this.PlayWithBotButton.TabIndex = 1;
            this.PlayWithBotButton.Text = "Play with a computer";
            this.PlayWithBotButton.UseVisualStyleBackColor = true;
            this.PlayWithBotButton.Click += new System.EventHandler(this.PlayWithBotButton_Click);
            // 
            // FirstPlayerNameTextBox
            // 
            this.FirstPlayerNameTextBox.Location = new System.Drawing.Point(514, 311);
            this.FirstPlayerNameTextBox.Name = "FirstPlayerNameTextBox";
            this.FirstPlayerNameTextBox.Size = new System.Drawing.Size(221, 23);
            this.FirstPlayerNameTextBox.TabIndex = 2;
            this.FirstPlayerNameTextBox.Visible = false;
            // 
            // SecondPlayerNameTextBox
            // 
            this.SecondPlayerNameTextBox.Location = new System.Drawing.Point(514, 378);
            this.SecondPlayerNameTextBox.Name = "SecondPlayerNameTextBox";
            this.SecondPlayerNameTextBox.Size = new System.Drawing.Size(221, 23);
            this.SecondPlayerNameTextBox.TabIndex = 3;
            this.SecondPlayerNameTextBox.Visible = false;
            // 
            // ConfirmPlayersNamesButton
            // 
            this.ConfirmPlayersNamesButton.Location = new System.Drawing.Point(514, 607);
            this.ConfirmPlayersNamesButton.Name = "ConfirmPlayersNamesButton";
            this.ConfirmPlayersNamesButton.Size = new System.Drawing.Size(221, 93);
            this.ConfirmPlayersNamesButton.TabIndex = 4;
            this.ConfirmPlayersNamesButton.Text = "Confirm";
            this.ConfirmPlayersNamesButton.UseVisualStyleBackColor = true;
            this.ConfirmPlayersNamesButton.Visible = false;
            this.ConfirmPlayersNamesButton.Click += new System.EventHandler(this.ConfirmPlayersNamesButton_Click);
            // 
            // ConfirmPlayerNameButton
            // 
            this.ConfirmPlayerNameButton.Location = new System.Drawing.Point(514, 427);
            this.ConfirmPlayerNameButton.Name = "ConfirmPlayerNameButton";
            this.ConfirmPlayerNameButton.Size = new System.Drawing.Size(221, 93);
            this.ConfirmPlayerNameButton.TabIndex = 5;
            this.ConfirmPlayerNameButton.Text = "Confirm";
            this.ConfirmPlayerNameButton.UseVisualStyleBackColor = true;
            this.ConfirmPlayerNameButton.Visible = false;
            this.ConfirmPlayerNameButton.Click += new System.EventHandler(this.ConfirmPlayerNameButton_Click);
            // 
            // FirstPlayerNameLabel
            // 
            this.FirstPlayerNameLabel.AutoSize = true;
            this.FirstPlayerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.FirstPlayerNameLabel.Location = new System.Drawing.Point(576, 279);
            this.FirstPlayerNameLabel.Name = "FirstPlayerNameLabel";
            this.FirstPlayerNameLabel.Size = new System.Drawing.Size(100, 15);
            this.FirstPlayerNameLabel.TabIndex = 6;
            this.FirstPlayerNameLabel.Text = "First player name:";
            this.FirstPlayerNameLabel.Visible = false;
            // 
            // SecondPlayerNameLabel
            // 
            this.SecondPlayerNameLabel.AutoSize = true;
            this.SecondPlayerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.SecondPlayerNameLabel.Location = new System.Drawing.Point(576, 347);
            this.SecondPlayerNameLabel.Name = "SecondPlayerNameLabel";
            this.SecondPlayerNameLabel.Size = new System.Drawing.Size(117, 15);
            this.SecondPlayerNameLabel.TabIndex = 7;
            this.SecondPlayerNameLabel.Text = "Second player name:";
            this.SecondPlayerNameLabel.Visible = false;
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayerNameLabel.Location = new System.Drawing.Point(587, 264);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(75, 15);
            this.PlayerNameLabel.TabIndex = 8;
            this.PlayerNameLabel.Text = "Player name:";
            this.PlayerNameLabel.Visible = false;
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BattleshipsWinforms.Properties.Resources.battleships_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1256, 811);
            this.Controls.Add(this.PlayerNameLabel);
            this.Controls.Add(this.SecondPlayerNameLabel);
            this.Controls.Add(this.FirstPlayerNameLabel);
            this.Controls.Add(this.ConfirmPlayerNameButton);
            this.Controls.Add(this.ConfirmPlayersNamesButton);
            this.Controls.Add(this.SecondPlayerNameTextBox);
            this.Controls.Add(this.FirstPlayerNameTextBox);
            this.Controls.Add(this.PlayWithBotButton);
            this.Controls.Add(this.TwoPlayersGameButton);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1272, 850);
            this.MinimumSize = new System.Drawing.Size(1272, 850);
            this.Name = "StartingForm";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button TwoPlayersGameButton;
        private Button PlayWithBotButton;
        private TextBox FirstPlayerNameTextBox;
        private TextBox SecondPlayerNameTextBox;
        private Button ConfirmPlayersNamesButton;
        private Button ConfirmPlayerNameButton;
        private Label FirstPlayerNameLabel;
        private Label SecondPlayerNameLabel;
        private Label PlayerNameLabel;
    }
}