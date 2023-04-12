namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class Form1 : Form
    {
        Game g = new Game();
        List<PlayerControl> playerControls;
        DynamicPanel dynamicPanel = new DynamicPanel(1200, 520);
        //int rounds = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (btnPlay.Text == "Start game!")
            {
                //rounds = 0;
                tbNumPlayers.Enabled = false;

                this.Size = new Size(500, 600);

                int numPlayers = int.Parse(tbNumPlayers.Text);
                g.StartGame(numPlayers);

                int addedPanels = 0;

                dynamicPanel.ResetLayout();
                dynamicPanel.Location = new Point(200, 10);

                playerControls = new List<PlayerControl>();

                foreach (Player p in g.players)
                {
                    if (addedPanels % 4 == 0 && addedPanels < 24 && addedPanels > 3)
                    {
                        this.Size = new Size(this.Width + 200, this.Height);
                    }
                    PlayerControl userControl = new PlayerControl(p);
                    playerControls.Add(userControl);

                    dynamicPanel.AddControl(userControl);

                    addedPanels++;
                }
                this.Controls.Add(dynamicPanel);

                g.FillDeck();
                btnPlay.Text = "Play";
                Initialize();
            }

            else
            {
                g.PlayRound();
                //rounds++;
                lblRoundsText.Text = g.GameRounds.ToString();
                Update();
            }

        }


        internal void Initialize()
        {
            foreach (PlayerControl p in playerControls)
            {
                p.Initialize();
            }
        }

        internal void Update()
        {

            foreach (PlayerControl p in playerControls)
            {
                p.Update();
            }

            if (g.GameOver)
            {
                MessageBox.Show(g.GameWinner);
                btnPlay.Text = "Start game!";
                tbNumPlayers.Enabled = true;
            }
        }
    }

}