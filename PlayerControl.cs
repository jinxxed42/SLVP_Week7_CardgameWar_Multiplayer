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
        private Label plcLblScoreTxt;
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
            this.plcLblScoreTxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // plcLblName
            // 
            this.plcLblName.AutoSize = true;
            this.plcLblName.Location = new System.Drawing.Point(12, 13);
            this.plcLblName.Name = "plcLblName";
            this.plcLblName.Size = new System.Drawing.Size(42, 15);
            this.plcLblName.TabIndex = 0;
            this.plcLblName.Text = "Name:";
            // 
            // plcLblScore
            // 
            this.plcLblScore.AutoSize = true;
            this.plcLblScore.Location = new System.Drawing.Point(12, 41);
            this.plcLblScore.Name = "plcLblScore";
            this.plcLblScore.Size = new System.Drawing.Size(36, 15);
            this.plcLblScore.TabIndex = 1;
            this.plcLblScore.Text = "Score";
            // 
            // plcLblNameText
            // 
            this.plcLblNameText.AutoSize = true;
            this.plcLblNameText.Location = new System.Drawing.Point(60, 13);
            this.plcLblNameText.Name = "plcLblNameText";
            this.plcLblNameText.Size = new System.Drawing.Size(12, 15);
            this.plcLblNameText.TabIndex = 2;
            this.plcLblNameText.Text = "-";
            // 
            // plcLblScoreTxt
            // 
            this.plcLblScoreTxt.AutoSize = true;
            this.plcLblScoreTxt.Location = new System.Drawing.Point(60, 41);
            this.plcLblScoreTxt.Name = "plcLblScoreTxt";
            this.plcLblScoreTxt.Size = new System.Drawing.Size(13, 15);
            this.plcLblScoreTxt.TabIndex = 3;
            this.plcLblScoreTxt.Text = "0";
            // 
            // PlayerControl
            // 
            this.Controls.Add(this.plcLblScoreTxt);
            this.Controls.Add(this.plcLblNameText);
            this.Controls.Add(this.plcLblScore);
            this.Controls.Add(this.plcLblName);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(137, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }

}
