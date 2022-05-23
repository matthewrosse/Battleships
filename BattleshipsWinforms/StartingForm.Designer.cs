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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartingForm));
            this.TwoPlayersGameButton = new System.Windows.Forms.Button();
            this.PlayWithBotButton = new System.Windows.Forms.Button();
            this.FirstPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.SecondPlayerNameTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmPlayersNamesButton = new System.Windows.Forms.Button();
            this.ConfirmPlayerNameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TwoPlayersGameButton
            // 
            this.TwoPlayersGameButton.Location = new System.Drawing.Point(486, 191);
            this.TwoPlayersGameButton.Name = "TwoPlayersGameButton";
            this.TwoPlayersGameButton.Size = new System.Drawing.Size(221, 93);
            this.TwoPlayersGameButton.TabIndex = 0;
            this.TwoPlayersGameButton.Text = "Two players game";
            this.TwoPlayersGameButton.UseVisualStyleBackColor = true;
            this.TwoPlayersGameButton.Click += new System.EventHandler(this.TwoPlayersGameButton_Click);
            // 
            // PlayWithBotButton
            // 
            this.PlayWithBotButton.Location = new System.Drawing.Point(486, 433);
            this.PlayWithBotButton.Name = "PlayWithBotButton";
            this.PlayWithBotButton.Size = new System.Drawing.Size(221, 93);
            this.PlayWithBotButton.TabIndex = 1;
            this.PlayWithBotButton.Text = "Play with a computer";
            this.PlayWithBotButton.UseVisualStyleBackColor = true;
            this.PlayWithBotButton.Click += new System.EventHandler(this.PlayWithBotButton_Click);
            // 
            // FirstPlayerNameTextBox
            // 
            this.FirstPlayerNameTextBox.Location = new System.Drawing.Point(486, 301);
            this.FirstPlayerNameTextBox.Name = "FirstPlayerNameTextBox";
            this.FirstPlayerNameTextBox.Size = new System.Drawing.Size(221, 23);
            this.FirstPlayerNameTextBox.TabIndex = 2;
            this.FirstPlayerNameTextBox.Visible = false;
            // 
            // SecondPlayerNameTextBox
            // 
            this.SecondPlayerNameTextBox.Location = new System.Drawing.Point(486, 368);
            this.SecondPlayerNameTextBox.Name = "SecondPlayerNameTextBox";
            this.SecondPlayerNameTextBox.Size = new System.Drawing.Size(221, 23);
            this.SecondPlayerNameTextBox.TabIndex = 3;
            this.SecondPlayerNameTextBox.Visible = false;
            // 
            // ConfirmPlayersNamesButton
            // 
            this.ConfirmPlayersNamesButton.Location = new System.Drawing.Point(486, 597);
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
            this.ConfirmPlayerNameButton.Location = new System.Drawing.Point(486, 417);
            this.ConfirmPlayerNameButton.Name = "ConfirmPlayerNameButton";
            this.ConfirmPlayerNameButton.Size = new System.Drawing.Size(221, 93);
            this.ConfirmPlayerNameButton.TabIndex = 5;
            this.ConfirmPlayerNameButton.Text = "Confirm";
            this.ConfirmPlayerNameButton.UseVisualStyleBackColor = true;
            this.ConfirmPlayerNameButton.Visible = false;
            this.ConfirmPlayerNameButton.Click += new System.EventHandler(this.ConfirmPlayerNameButton_Click);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1256, 811);
            this.Controls.Add(this.ConfirmPlayerNameButton);
            this.Controls.Add(this.ConfirmPlayersNamesButton);
            this.Controls.Add(this.SecondPlayerNameTextBox);
            this.Controls.Add(this.FirstPlayerNameTextBox);
            this.Controls.Add(this.PlayWithBotButton);
            this.Controls.Add(this.TwoPlayersGameButton);
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
    }
}