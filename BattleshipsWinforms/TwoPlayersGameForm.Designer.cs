namespace BattleshipsWinforms
{
    partial class TwoPlayersGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayerFleetPictureBox = new System.Windows.Forms.PictureBox();
            this.PlayerHitsPictureBox = new System.Windows.Forms.PictureBox();
            this.ManuallyDockedShipsPictureBox = new System.Windows.Forms.PictureBox();
            this.PlaceShipsManuallyButton = new System.Windows.Forms.Button();
            this.ConfirmShipsPlacementButton = new System.Windows.Forms.Button();
            this.PlaceShipsAutomaticallyButton = new System.Windows.Forms.Button();
            this.PromptLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerFleetPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHitsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManuallyDockedShipsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerFleetPictureBox
            // 
            this.PlayerFleetPictureBox.Location = new System.Drawing.Point(12, 107);
            this.PlayerFleetPictureBox.Name = "PlayerFleetPictureBox";
            this.PlayerFleetPictureBox.Size = new System.Drawing.Size(622, 622);
            this.PlayerFleetPictureBox.TabIndex = 0;
            this.PlayerFleetPictureBox.TabStop = false;
            this.PlayerFleetPictureBox.Visible = false;
            this.PlayerFleetPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayerFleetPictureBox_Paint);
            // 
            // PlayerHitsPictureBox
            // 
            this.PlayerHitsPictureBox.Location = new System.Drawing.Point(850, 107);
            this.PlayerHitsPictureBox.Name = "PlayerHitsPictureBox";
            this.PlayerHitsPictureBox.Size = new System.Drawing.Size(622, 622);
            this.PlayerHitsPictureBox.TabIndex = 1;
            this.PlayerHitsPictureBox.TabStop = false;
            this.PlayerHitsPictureBox.Visible = false;
            this.PlayerHitsPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayerHitsPictureBox_Paint);
            this.PlayerHitsPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayerHitsPictureBox_MouseClick);
            // 
            // ManuallyDockedShipsPictureBox
            // 
            this.ManuallyDockedShipsPictureBox.Location = new System.Drawing.Point(430, 107);
            this.ManuallyDockedShipsPictureBox.Name = "ManuallyDockedShipsPictureBox";
            this.ManuallyDockedShipsPictureBox.Size = new System.Drawing.Size(622, 622);
            this.ManuallyDockedShipsPictureBox.TabIndex = 2;
            this.ManuallyDockedShipsPictureBox.TabStop = false;
            this.ManuallyDockedShipsPictureBox.Visible = false;
            this.ManuallyDockedShipsPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ManuallyDockedShipsPictureBox_Paint);
            this.ManuallyDockedShipsPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ManuallyDockedShipsPictureBox_MouseClick);
            this.ManuallyDockedShipsPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManuallyDockedShipsPictureBox_MouseMove);
            // 
            // PlaceShipsManuallyButton
            // 
            this.PlaceShipsManuallyButton.Location = new System.Drawing.Point(352, 782);
            this.PlaceShipsManuallyButton.Name = "PlaceShipsManuallyButton";
            this.PlaceShipsManuallyButton.Size = new System.Drawing.Size(202, 82);
            this.PlaceShipsManuallyButton.TabIndex = 3;
            this.PlaceShipsManuallyButton.Text = "Place ships manually";
            this.PlaceShipsManuallyButton.UseVisualStyleBackColor = true;
            this.PlaceShipsManuallyButton.Click += new System.EventHandler(this.PlaceShipsManuallyButton_Click);
            // 
            // ConfirmShipsPlacementButton
            // 
            this.ConfirmShipsPlacementButton.Location = new System.Drawing.Point(675, 782);
            this.ConfirmShipsPlacementButton.Name = "ConfirmShipsPlacementButton";
            this.ConfirmShipsPlacementButton.Size = new System.Drawing.Size(202, 82);
            this.ConfirmShipsPlacementButton.TabIndex = 4;
            this.ConfirmShipsPlacementButton.Text = "Confirm ships placement";
            this.ConfirmShipsPlacementButton.UseVisualStyleBackColor = true;
            this.ConfirmShipsPlacementButton.Visible = false;
            this.ConfirmShipsPlacementButton.Click += new System.EventHandler(this.ConfirmShipsPlacementButton_Click);
            // 
            // PlaceShipsAutomaticallyButton
            // 
            this.PlaceShipsAutomaticallyButton.Location = new System.Drawing.Point(1008, 782);
            this.PlaceShipsAutomaticallyButton.Name = "PlaceShipsAutomaticallyButton";
            this.PlaceShipsAutomaticallyButton.Size = new System.Drawing.Size(202, 77);
            this.PlaceShipsAutomaticallyButton.TabIndex = 5;
            this.PlaceShipsAutomaticallyButton.Text = "Place ships automatically";
            this.PlaceShipsAutomaticallyButton.UseVisualStyleBackColor = true;
            this.PlaceShipsAutomaticallyButton.Click += new System.EventHandler(this.PlaceShipsAutomaticallyButton_Click);
            // 
            // PromptLabel
            // 
            this.PromptLabel.AutoSize = true;
            this.PromptLabel.Location = new System.Drawing.Point(689, 32);
            this.PromptLabel.Name = "PromptLabel";
            this.PromptLabel.Size = new System.Drawing.Size(0, 15);
            this.PromptLabel.TabIndex = 6;
            this.PromptLabel.Visible = false;
            // 
            // TwoPlayersGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 911);
            this.Controls.Add(this.PromptLabel);
            this.Controls.Add(this.PlaceShipsAutomaticallyButton);
            this.Controls.Add(this.ConfirmShipsPlacementButton);
            this.Controls.Add(this.PlaceShipsManuallyButton);
            this.Controls.Add(this.ManuallyDockedShipsPictureBox);
            this.Controls.Add(this.PlayerHitsPictureBox);
            this.Controls.Add(this.PlayerFleetPictureBox);
            this.MaximumSize = new System.Drawing.Size(1500, 950);
            this.MinimumSize = new System.Drawing.Size(1500, 950);
            this.Name = "TwoPlayersGameForm";
            this.Text = "TwoPlayersGameForm";
            ((System.ComponentModel.ISupportInitialize)(this.PlayerFleetPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHitsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManuallyDockedShipsPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox PlayerFleetPictureBox;
        private PictureBox PlayerHitsPictureBox;
        private PictureBox ManuallyDockedShipsPictureBox;
        private Button PlaceShipsManuallyButton;
        private Button ConfirmShipsPlacementButton;
        private Button PlaceShipsAutomaticallyButton;
        private Label PromptLabel;
    }
}