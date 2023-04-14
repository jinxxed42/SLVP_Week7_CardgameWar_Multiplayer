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
        private Player player; // _player
        private string file = "";

        public PlayerControl(Player player)
        {
            InitializeComponent();
            this.player = player;

            file = AppDomain.CurrentDomain.BaseDirectory;
            var parent = Directory.GetParent(file);
            if (parent != null)
            {
                parent = parent.Parent;
                if (parent != null)
                {
                    parent = parent.Parent;
                    if (parent != null)
                    {
                        parent = parent.Parent;
                        if (parent != null)
                        {
                            file = parent.FullName;
                        }
                    }
                }
            }
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
            plcLblNameText.Text = player.Name.ToString();
            plcLblScoreText.Text = player.Score.ToString();

            if (File.Exists(@"C:\Cards\gray_back.png")) 
            { 
                Image image = Image.FromFile(@"C:\Users\claus\source\repos\SLVP_Week7_CardgameWar_Multiplayer\Cards\gray_back.png");
                plcPicturebox.Image = image;
            }
            else if (File.Exists(file + @"\Cards\gray_back.png"))
            {
                Image image = Image.FromFile(file + @"\Cards\gray_back.png");
                plcPicturebox.Image = image;
            }
            
        }

        public void ControlUpdate()
        {
            plcLblScoreText.Text = player.Score.ToString();

            string cardString = CardImageFileName(player.CardDrawn);
            string cardFolder = file + @"\Cards\";

            if (File.Exists(@"C:\Cards\" + cardString))
            {
                Image image = Image.FromFile(@"C:\Cards\" + cardString);
                plcPicturebox.Image = image;
            }
            else if (File.Exists(cardFolder + cardString)) 
            { 
                Image image = Image.FromFile(cardFolder + cardString);
                plcPicturebox.Image = image;
            }
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
