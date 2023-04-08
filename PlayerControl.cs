using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLVP_Week7_CardgameWar_Multiplayer
{
    internal class PlayerControl : UserControl
    {
        private Label plcLblName;
        private Label plcLblScore;
        private Label plcLblNameText;
        private Label plcLblScoreText;
        private PictureBox plcPicturebox;
        private Player player;

        public PlayerControl(Player player)
        {
            InitializeComponent();
            this.player = player;
            //this.Location = new Point(10, 10);
            //this.Size = new Size(200, 300);
            // Set up the control's layout and other properties here
        }

        private void InitializeComponent()
        {
            this.plcLblName = new System.Windows.Forms.Label();
            this.plcLblScore = new System.Windows.Forms.Label();
            this.plcLblNameText = new System.Windows.Forms.Label();
            this.plcLblScoreText = new System.Windows.Forms.Label();
            this.plcPicturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.plcPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // plcLblName
            // 
            this.plcLblName.AutoSize = true;
            this.plcLblName.Location = new System.Drawing.Point(12, 30);
            this.plcLblName.Name = "plcLblName";
            this.plcLblName.Size = new System.Drawing.Size(42, 15);
            this.plcLblName.TabIndex = 0;
            this.plcLblName.Text = "Name:";
            // 
            // plcLblScore
            // 
            this.plcLblScore.AutoSize = true;
            this.plcLblScore.Location = new System.Drawing.Point(12, 60);
            this.plcLblScore.Name = "plcLblScore";
            this.plcLblScore.Size = new System.Drawing.Size(39, 15);
            this.plcLblScore.TabIndex = 1;
            this.plcLblScore.Text = "Score:";
            // 
            // plcLblNameText
            // 
            this.plcLblNameText.AutoSize = true;
            this.plcLblNameText.Location = new System.Drawing.Point(60, 30);
            this.plcLblNameText.Name = "plcLblNameText";
            this.plcLblNameText.Size = new System.Drawing.Size(12, 15);
            this.plcLblNameText.TabIndex = 2;
            this.plcLblNameText.Text = "-";
            // 
            // plcLblScoreText
            // 
            this.plcLblScoreText.AutoSize = true;
            this.plcLblScoreText.Location = new System.Drawing.Point(59, 60);
            this.plcLblScoreText.Name = "plcLblScoreText";
            this.plcLblScoreText.Size = new System.Drawing.Size(13, 15);
            this.plcLblScoreText.TabIndex = 3;
            this.plcLblScoreText.Text = "0";
            // 
            // plcPicturebox
            // 
            this.plcPicturebox.Location = new System.Drawing.Point(109, 13);
            this.plcPicturebox.Name = "plcPicturebox";
            this.plcPicturebox.Size = new System.Drawing.Size(71, 93);
            this.plcPicturebox.TabIndex = 4;
            this.plcPicturebox.TabStop = false;
            // 
            // PlayerControl
            // 
            this.Controls.Add(this.plcPicturebox);
            this.Controls.Add(this.plcLblScoreText);
            this.Controls.Add(this.plcLblNameText);
            this.Controls.Add(this.plcLblScore);
            this.Controls.Add(this.plcLblName);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(190, 120);
            ((System.ComponentModel.ISupportInitialize)(this.plcPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void Update()
        {
            plcLblScoreText.Text = player.Score.ToString();
        }

    }

}
