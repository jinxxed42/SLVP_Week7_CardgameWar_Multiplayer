namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class Form1 : Form
    {
        Game g = new Game();
        List<PlayerControl> playerControls;
        //private DynamicPanel dynamicPanel;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (btnPlay.Text == "Start game!")
            {
                this.Size = new Size(725, 600);

                int numPlayers = int.Parse(tbNumPlayers.Text);
                g.StartGame(numPlayers);

                int addedPanels = 0;
                //int addedColumns = 0;

                DynamicPanel dynamicPanel = new DynamicPanel();
                dynamicPanel.Location = new Point(200, 10);


                playerControls = new List<PlayerControl>();

                foreach (Player p in g.players)
                {
                    // Det smider alle ekstra paneler ind i sidste kolonne....de skal fordeles!
                    // Jeg bliver nødt til at beregne hvor mange der skal laves, dele med 4 og så fordele dem udover panelerne.

                    // DET HER VIRKER FORNUFTIGT!!! GÅ EFTER AT LAVE ET STORT DYNAMIC PANEL, SOM DE ALLE SMIDES I I NYE KOLONNER,
                    // OG SÅ EN SCROLL BAR NEDERST PÅ DEN!!!!


                    if (addedPanels == 4)
                    {
                        //if (addedColumns < 3)
                        //{
                        
                            Point newLoc = new Point(dynamicPanel.Location.X + 199, dynamicPanel.Location.Y);
                            this.Controls.Add(dynamicPanel);
                            dynamicPanel = new DynamicPanel();
                            dynamicPanel.Location = newLoc;
                            addedPanels = 0;
                            this.Size = new Size(this.Width + 210, this.Height);
                        
                            //addedColumns++;
                        //}
                    }
                    PlayerControl userControl1 = new PlayerControl(p);
                    playerControls.Add(userControl1);

                    dynamicPanel.AddControl(userControl1);


                    dynamicPanel.Size = new Size(200, 500);
                    dynamicPanel.AutoScroll = true;
                    addedPanels++;
                }
                this.Controls.Add(dynamicPanel);

                g.FillDeck();
                btnPlay.Text = "Play";
            }

            //Result res = g.PlayRound();
            //Update(res);
            g.PlayRound();
            Update();

        }

        /**
        public void Update()
        {
            rtbGame.Text = "Player 1 drew a " + g.Player1Card.Value.ToString() + " of " + g.Player1Card.Suit.ToString() + "\n";
            rtbGame.Text += "Player 2 drew a " + g.Player2Card.Value.ToString() + " of " + g.Player2Card.Suit.ToString() + "\n";


            if (g.RemainingCards == 0)
            {
                //Game over
            }
            else
            {
                tbPlayer1.Text = g.Player1Score.ToString();
                tbPlayer2.Text = g.Player2Score.ToString();
            }
        }
        **/

        /**
        internal void Update(Result result)
        {
            //rtbGame.Text = "Player 1 drew a " + g.Player1Card.Value.ToString() + " of " + g.Player1Card.Suit.ToString() + "\n";
            //rtbGame.Text += "Player 2 drew a " + g.Player2Card.Value.ToString() + " of " + g.Player2Card.Suit.ToString() + "\n";

            if (result.GameOver)
            {
                btnPlay.Text = "Start game!";
                rtbGame.Text += "\n";
                
                if (result.GameWinner == "Draw")
                {
                    MessageBox.Show("The game is over and it was a draw!");
                }
                else
                {
                    MessageBox.Show("The game is over and the winner is: " + result.GameWinner + "!");
                }
                
            }
            else
            {
                // DØDSE PÅ DET HER!
                //tbPlayer1.Text = g.Player1Score.ToString();
                //tbPlayer2.Text = g.Player2Score.ToString();
            }

            foreach (PlayerControl p in playerControls)
            {
                p.Update();
            }
        }
        **/

        internal void Update()
        {
            //rtbGame.Text = "Player 1 drew a " + g.Player1Card.Value.ToString() + " of " + g.Player1Card.Suit.ToString() + "\n";
            //rtbGame.Text += "Player 2 drew a " + g.Player2Card.Value.ToString() + " of " + g.Player2Card.Suit.ToString() + "\n";

            if (g.GameOver)
            {
                btnPlay.Text = "Start game!";
                rtbGame.Text += "\n";
                /**
                if (result.GameWinner == "Draw")
                {
                    MessageBox.Show("The game is over and it was a draw!");
                }
                else
                {
                    MessageBox.Show("The game is over and the winner is: " + result.GameWinner + "!");
                }
                **/
            }
            else
            {
                // DØDSE PÅ DET HER!
                //tbPlayer1.Text = g.Player1Score.ToString();
                //tbPlayer2.Text = g.Player2Score.ToString();
            }

            foreach (PlayerControl p in playerControls)
            {
                p.Update();
            }
        }
    }

}