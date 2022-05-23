namespace BattleshipsWinforms
{
    partial class PlayWithBotForm
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
            this.PlaceShipsManuallyButton = new System.Windows.Forms.Button();
            this.PlaceShipsAutomaticallyButton = new System.Windows.Forms.Button();
            this.PlayerFleetPictureBox = new System.Windows.Forms.PictureBox();
            this.PlayerHitsPictureBox = new System.Windows.Forms.PictureBox();
            this.ManuallyDockedShipsPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerFleetPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHitsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManuallyDockedShipsPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PlaceShipsManuallyButton
            // 
            this.PlaceShipsManuallyButton.Location = new System.Drawing.Point(640, 203);
            this.PlaceShipsManuallyButton.Name = "PlaceShipsManuallyButton";
            this.PlaceShipsManuallyButton.Size = new System.Drawing.Size(201, 86);
            this.PlaceShipsManuallyButton.TabIndex = 0;
            this.PlaceShipsManuallyButton.Text = "Place ships manually";
            this.PlaceShipsManuallyButton.UseVisualStyleBackColor = true;
            // 
            // PlaceShipsAutomaticallyButton
            // 
            this.PlaceShipsAutomaticallyButton.Location = new System.Drawing.Point(640, 444);
            this.PlaceShipsAutomaticallyButton.Name = "PlaceShipsAutomaticallyButton";
            this.PlaceShipsAutomaticallyButton.Size = new System.Drawing.Size(201, 86);
            this.PlaceShipsAutomaticallyButton.TabIndex = 1;
            this.PlaceShipsAutomaticallyButton.Text = "Place ships automatically";
            this.PlaceShipsAutomaticallyButton.UseVisualStyleBackColor = true;
            // 
            // PlayerFleetPictureBox
            // 
            this.PlayerFleetPictureBox.Location = new System.Drawing.Point(12, 122);
            this.PlayerFleetPictureBox.Name = "PlayerFleetPictureBox";
            this.PlayerFleetPictureBox.Size = new System.Drawing.Size(622, 622);
            this.PlayerFleetPictureBox.TabIndex = 2;
            this.PlayerFleetPictureBox.TabStop = false;
            this.PlayerFleetPictureBox.Visible = false;
            this.PlayerFleetPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayerFleetPictureBox_Paint);
            // 
            // PlayerHitsPictureBox
            // 
            this.PlayerHitsPictureBox.Location = new System.Drawing.Point(850, 122);
            this.PlayerHitsPictureBox.Name = "PlayerHitsPictureBox";
            this.PlayerHitsPictureBox.Size = new System.Drawing.Size(622, 622);
            this.PlayerHitsPictureBox.TabIndex = 3;
            this.PlayerHitsPictureBox.TabStop = false;
            this.PlayerHitsPictureBox.Visible = false;
            this.PlayerHitsPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PlayerHitsPictureBox_Paint);
            this.PlayerHitsPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayerHitsPictureBox_MouseClick);
            // 
            // ManuallyDockedShipsPictureBox
            // 
            this.ManuallyDockedShipsPictureBox.Location = new System.Drawing.Point(429, 122);
            this.ManuallyDockedShipsPictureBox.Name = "ManuallyDockedShipsPictureBox";
            this.ManuallyDockedShipsPictureBox.Size = new System.Drawing.Size(622, 622);
            this.ManuallyDockedShipsPictureBox.TabIndex = 4;
            this.ManuallyDockedShipsPictureBox.TabStop = false;
            this.ManuallyDockedShipsPictureBox.Visible = false;
            this.ManuallyDockedShipsPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ManuallyDockedShipsPictureBox_Paint);
            this.ManuallyDockedShipsPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ManuallyDockedShipsPictureBox_MouseClick);
            this.ManuallyDockedShipsPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ManuallyDockedShipsPictureBox_MouseMove);
            // 
            // PlayWithBotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 911);
            this.Controls.Add(this.ManuallyDockedShipsPictureBox);
            this.Controls.Add(this.PlayerHitsPictureBox);
            this.Controls.Add(this.PlayerFleetPictureBox);
            this.Controls.Add(this.PlaceShipsAutomaticallyButton);
            this.Controls.Add(this.PlaceShipsManuallyButton);
            this.MinimumSize = new System.Drawing.Size(1500, 950);
            this.Name = "PlayWithBotForm";
            this.Text = "PlayWithBotForm";
            ((System.ComponentModel.ISupportInitialize)(this.PlayerFleetPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerHitsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManuallyDockedShipsPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button PlaceShipsManuallyButton;
        private Button PlaceShipsAutomaticallyButton;
        private PictureBox PlayerFleetPictureBox;
        private PictureBox PlayerHitsPictureBox;
        private PictureBox ManuallyDockedShipsPictureBox;
    }
}