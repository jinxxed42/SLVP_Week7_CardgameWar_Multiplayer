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
            SuspendLayout();
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(12, 192);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(108, 23);
            btnPlay.TabIndex = 0;
            btnPlay.Text = "Start game!";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // rtbGame
            // 
            rtbGame.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            rtbGame.Location = new Point(12, 12);
            rtbGame.Name = "rtbGame";
            rtbGame.Size = new Size(136, 96);
            rtbGame.TabIndex = 1;
            rtbGame.Text = "Click the button to play!";
            // 
            // tbNumPlayers
            // 
            tbNumPlayers.Location = new Point(12, 150);
            tbNumPlayers.Name = "tbNumPlayers";
            tbNumPlayers.Size = new Size(108, 23);
            tbNumPlayers.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 122);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 7;
            label1.Text = "Number of players:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 561);
            Controls.Add(label1);
            Controls.Add(tbNumPlayers);
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
        private TextBox tbNumPlayers;
        private Label label1;
    }
}