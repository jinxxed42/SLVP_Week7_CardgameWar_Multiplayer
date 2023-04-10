namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class Form1 : Form
    {
        Game g = new Game();
        List<PlayerControl> playerControls;
        //private DynamicPanel dynamicPanel;


        // SELVFØLGELIG BLIVER DET PROBLEM AT DESIGNE NOGET PÅ ET DYNAMISK PANEL???

        public Form1()
        {
            InitializeComponent();
            //tlp1
            //tlp1.RowCount = 1;
            //tlp1.ColumnCount = 1;
            //Panel pnl1 = new Panel();
            //this.Controls.Add(pnl1);



            /**
            UserControl1 userControl1 = new UserControl1();
            dynamicPanel.AddControl(userControl1);
            **/


            /**
            foreach (Player p in g.players) 
            {
                PlayerControl playerControl = new PlayerControl(p);
                playerControls.Add(playerControl);
                //tlp1.Controls.Add(playerControl);
                pnl1.Controls.Add(playerControl);
            }
            **/
            //tlp1.Show();
            //pnl1.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (btnPlay.Text == "Start game!")
            {
                int numPlayers = int.Parse(tbNumPlayers.Text);
                g.StartGame(numPlayers);

                int addedPanels = 0;

                DynamicPanel dynamicPanel = new DynamicPanel();
                dynamicPanel.Location = new Point(10, 10);


                playerControls = new List<PlayerControl>();
                foreach (Player p in g.players)
                {
                    if (addedPanels == 5)
                    {
                        Point newLoc = new Point(dynamicPanel.Location.X + 225, dynamicPanel.Location.Y);
                        this.Controls.Add(dynamicPanel);
                        dynamicPanel = new DynamicPanel();
                        dynamicPanel.Location = newLoc; 
                        addedPanels = 0;
                        this.ClientSize = new Size(this.Width + 225, this.Height);
                    }
                    PlayerControl userControl1 = new PlayerControl(p);
                    playerControls.Add(userControl1);
                    dynamicPanel.AddControl(userControl1);
                    dynamicPanel.Size = new Size(225, 400); //trying in class ctor
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