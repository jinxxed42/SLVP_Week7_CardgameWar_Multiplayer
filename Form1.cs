namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class Form1 : Form
    {
        Game g = new Game();
        List<PlayerControl> playerControls;
        DynamicPanel dynamicPanel = new DynamicPanel(1200, 520);
        private int _baseWidth = 475;
        //int rounds = 0;

        public Form1()
        {
            InitializeComponent();
            playerControls = new List<PlayerControl>();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (btnPlay.Text == "Start game!")
            {
                if (!int.TryParse(tbNumPlayers.Text, out int numPlayers) || numPlayers < 2)
                {
                    MessageBox.Show("You need to enter a valid integer above 1.");
                    return;
                }
                g.StartGame(numPlayers);
                //rounds = 0;
                tbNumPlayers.Enabled = false;
              
                dynamicPanel.ResetLayout();
                dynamicPanel.Location = new Point(200, 10);

                int addedPanels = g.Players.Count;
                int size = (addedPanels - 1) / 4;
                if (size > 5) { size = 5; }
                this.Size = new Size(_baseWidth + 200 * size, this.Height);

                foreach (Player p in g.Players)
                {
                    PlayerControl userControl = new PlayerControl(p);
                    playerControls.Add(userControl);

                    dynamicPanel.AddControl(userControl);

                }
                dynamicPanel.UpdateLayout();
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
                FormUpdate();
            }

        }


        internal void Initialize()
        {
            foreach (PlayerControl p in playerControls)
            {
                p.Initialize();
            }
        }

        internal void FormUpdate()
        {
            foreach (PlayerControl p in playerControls)
            {
                p.ControlUpdate();
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