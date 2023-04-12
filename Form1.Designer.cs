namespace SLVP_Week7_CardgameWar_Multiplayer
{
    partial class Form1
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
            btnPlay = new Button();
            rtbGame = new RichTextBox();
            tbNumPlayers = new TextBox();
            label1 = new Label();
            lblRounds = new Label();
            lblRoundsText = new Label();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(12, 231);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(108, 23);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Start game!";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // rtbGame
            // 
            rtbGame.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            rtbGame.Location = new Point(12, 12);
            rtbGame.Name = "rtbGame";
            rtbGame.Size = new Size(136, 132);
            rtbGame.TabIndex = 1;
            rtbGame.Text = "Click the button to play!\n\nThe game will technically\nsupport a number of\nplayers up to the limit\nof an integer, but it will\nlag badly for a high\nnumber of players.";
            // 
            // tbNumPlayers
            // 
            tbNumPlayers.Location = new Point(12, 192);
            tbNumPlayers.Name = "tbNumPlayers";
            tbNumPlayers.Size = new Size(108, 23);
            tbNumPlayers.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 174);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 7;
            label1.Text = "Number of players:";
            // 
            // lblRounds
            // 
            lblRounds.AutoSize = true;
            lblRounds.Location = new Point(12, 267);
            lblRounds.Name = "lblRounds";
            lblRounds.Size = new Size(50, 15);
            lblRounds.TabIndex = 8;
            lblRounds.Text = "Rounds:";
            // 
            // lblRoundsText
            // 
            lblRoundsText.AutoSize = true;
            lblRoundsText.Location = new Point(68, 267);
            lblRoundsText.Name = "lblRoundsText";
            lblRoundsText.Size = new Size(13, 15);
            lblRoundsText.TabIndex = 9;
            lblRoundsText.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 561);
            Controls.Add(lblRoundsText);
            Controls.Add(lblRounds);
            Controls.Add(label1);
            Controls.Add(tbNumPlayers);
            Controls.Add(rtbGame);
            Controls.Add(btnPlay);
            Name = "Form1";
            Text = "War - Multiplayer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlay;
        private RichTextBox rtbGame;
        private TextBox tbNumPlayers;
        private Label label1;
        private Label lblRounds;
        private Label lblRoundsText;
    }
}