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
            tbPlayer1 = new TextBox();
            tbPlayer2 = new TextBox();
            lblPlayer1 = new Label();
            lblPlayer2 = new Label();
            tbNumPlayers = new TextBox();
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(425, 243);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(100, 23);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Start game!";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // rtbGame
            // 
            rtbGame.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            rtbGame.Location = new Point(402, 83);
            rtbGame.Name = "rtbGame";
            rtbGame.Size = new Size(171, 96);
            rtbGame.TabIndex = 1;
            rtbGame.Text = "Click the button to play!";
            // 
            // tbPlayer1
            // 
            tbPlayer1.Location = new Point(296, 83);
            tbPlayer1.Name = "tbPlayer1";
            tbPlayer1.Size = new Size(100, 23);
            tbPlayer1.TabIndex = 2;
            // 
            // tbPlayer2
            // 
            tbPlayer2.Location = new Point(579, 73);
            tbPlayer2.Name = "tbPlayer2";
            tbPlayer2.Size = new Size(100, 23);
            tbPlayer2.TabIndex = 3;
            // 
            // lblPlayer1
            // 
            lblPlayer1.AutoSize = true;
            lblPlayer1.Location = new Point(296, 55);
            lblPlayer1.Name = "lblPlayer1";
            lblPlayer1.Size = new Size(84, 15);
            lblPlayer1.TabIndex = 4;
            lblPlayer1.Text = "Player1 points:";
            // 
            // lblPlayer2
            // 
            lblPlayer2.AutoSize = true;
            lblPlayer2.Location = new Point(578, 55);
            lblPlayer2.Name = "lblPlayer2";
            lblPlayer2.Size = new Size(84, 15);
            lblPlayer2.TabIndex = 5;
            lblPlayer2.Text = "Player2 points:";
            // 
            // tbNumPlayers
            // 
            tbNumPlayers.Location = new Point(425, 199);
            tbNumPlayers.Name = "tbNumPlayers";
            tbNumPlayers.Size = new Size(100, 23);
            tbNumPlayers.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 450);
            Controls.Add(tbNumPlayers);
            Controls.Add(lblPlayer2);
            Controls.Add(lblPlayer1);
            Controls.Add(tbPlayer2);
            Controls.Add(tbPlayer1);
            Controls.Add(rtbGame);
            Controls.Add(btnPlay);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPlay;
        private RichTextBox rtbGame;
        private TextBox tbPlayer1;
        private TextBox tbPlayer2;
        private Label lblPlayer1;
        private Label lblPlayer2;
        private TextBox tbNumPlayers;
    }
}