using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLVP_Week7_CardgameWar_Multiplayer
{
    internal class PlayerControl : UserControl
    {
        private Label plcLblName = new Label();
        private Label plcLblScore = new Label();
        private Label plcLblNameText = new Label();
        private Label plcLblScoreText = new Label();
        private PictureBox plcPicturebox = new PictureBox();
        private Player _player; 

        public PlayerControl(Player player)
        {
            InitializeComponent();
            this._player = player;
            // Set up the control's layout and other properties here
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)plcPicturebox).BeginInit();
            SuspendLayout();
            // 
            // plcLblName
            // 
            plcLblName.AutoSize = true;
            plcLblName.Location = new Point(12, 20);
            plcLblName.Name = "plcLblName";
            plcLblName.Size = new Size(42, 15);
            plcLblName.TabIndex = 0;
            plcLblName.Text = "Name:";
            // 
            // plcLblScore
            // 
            plcLblScore.AutoSize = true;
            plcLblScore.Location = new Point(12, 50);
            plcLblScore.Name = "plcLblScore";
            plcLblScore.Size = new Size(39, 15);
            plcLblScore.TabIndex = 1;
            plcLblScore.Text = "Score:";
            // 
            // plcLblNameText
            // 
            plcLblNameText.AutoSize = true;
            plcLblNameText.Location = new Point(60, 20);
            plcLblNameText.Name = "plcLblNameText";
            plcLblNameText.Size = new Size(12, 15);
            plcLblNameText.TabIndex = 2;
            plcLblNameText.Text = "-";
            // 
            // plcLblScoreText
            // 
            plcLblScoreText.AutoSize = true;
            plcLblScoreText.Location = new Point(59, 50);
            plcLblScoreText.Name = "plcLblScoreText";
            plcLblScoreText.Size = new Size(13, 15);
            plcLblScoreText.TabIndex = 3;
            plcLblScoreText.Text = "0";
            // 
            // plcPicturebox
            // 
            plcPicturebox.BorderStyle = BorderStyle.FixedSingle;
            plcPicturebox.Location = new Point(120, 15);
            plcPicturebox.Name = "plcPicturebox";
            plcPicturebox.Size = new Size(70, 93);
            plcPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            plcPicturebox.TabIndex = 4;
            plcPicturebox.TabStop = false;
            // 
            // PlayerControl
            // 
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(plcPicturebox);
            Controls.Add(plcLblScoreText);
            Controls.Add(plcLblNameText);
            Controls.Add(plcLblScore);
            Controls.Add(plcLblName);
            Name = "PlayerControl";
            Size = new Size(200, 125);
            ((System.ComponentModel.ISupportInitialize)plcPicturebox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        public void Initialize()
        {
            plcLblNameText.Text = _player.Name.ToString();
            plcLblScoreText.Text = _player.Score.ToString();

            plcPicturebox.Image = Properties.Resources.gray_back;           
        }

        public void ControlUpdate()
        {
            plcLblScoreText.Text = _player.Score.ToString();

            string cardString = CardImageFileName(_player.CardDrawn);
            
            Image? image = Properties.Resources.ResourceManager.GetObject(cardString) as Image; // We know it exists since it's in the resources.
            plcPicturebox.Image = image;
        }

        internal string CardImageFileName(Card card)
        {
            string valueCode;
            switch (card.Value)
            {
                case CardValue.Two:
                    valueCode = "_2"; // _ in front of numbers when added as a resource.
                    break;
                case CardValue.Three:
                    valueCode = "_3";
                    break;
                case CardValue.Four:
                    valueCode = "_4";
                    break;
                case CardValue.Five:
                    valueCode = "_5";
                    break;
                case CardValue.Six:
                    valueCode = "_6";
                    break;
                case CardValue.Seven:
                    valueCode = "_7";
                    break;
                case CardValue.Eight:
                    valueCode = "_8";
                    break;
                case CardValue.Nine:
                    valueCode = "_9";
                    break;
                case CardValue.Ten:
                    valueCode = "_10";
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
            return valueCode + suitCode;
        }

    }
}
