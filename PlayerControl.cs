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
            this.plcPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
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
            plcLblNameText.Text = player.Name.ToString(); // Skal kun sættes én gang!
            plcLblScoreText.Text = player.Score.ToString();

            string cardString = CardImageFileName(player.CardDrawn);
            string cardFolder = @"C:\Users\claus\source\repos\SLVP_Week7_CardgameWar_Multiplayer\Cards\";

            Image image = Image.FromFile(cardFolder + cardString);
            plcPicturebox.Image = image;

        }

        internal string CardImageFileName(Card card)
        {
            string valueCode;
            switch (card.Value)
            {
                case CardValue.Two:
                    valueCode = "2";
                    break;
                case CardValue.Three:
                    valueCode = "3";
                    break;
                case CardValue.Four:
                    valueCode = "4";
                    break;
                case CardValue.Five:
                    valueCode = "5";
                    break;
                case CardValue.Six:
                    valueCode = "6";
                    break;
                case CardValue.Seven:
                    valueCode = "7";
                    break;
                case CardValue.Eight:
                    valueCode = "8";
                    break;
                case CardValue.Nine:
                    valueCode = "9";
                    break;
                case CardValue.Ten:
                    valueCode = "10";
                    break;
                case CardValue.Jack:
                    valueCode = "J";
                    break;
                case CardValue.Queen:
                    valueCode = "Q";
                    break;
                case CardValue.King:
                    valueCode = "K";
                    break;
                case CardValue.Ace:
                    valueCode = "A";
                    break;
                default:
                    throw new ArgumentException("Invalid card value");
            }

            string suitCode;
            switch (card.Suit)
            {
                case CardSuit.Clubs:
                    suitCode = "C";
                    break;
                case CardSuit.Diamonds:
                    suitCode = "D";
                    break;
                case CardSuit.Hearts:
                    suitCode = "H";
                    break;
                case CardSuit.Spades:
                    suitCode = "S";
                    break;
                default:
                    throw new ArgumentException("Invalid card suit");
            }

            return valueCode + suitCode + ".png";
        }

    }
}
