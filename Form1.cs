namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class Form1 : Form
    {
        Game g = new Game();
        List<PlayerControl> playerControls;
        private int _baseWidth = 475; // The starting width of the form if no resizing needed.
        DynamicPanel dynamicPanel = new DynamicPanel();

        public Form1()
        {
            InitializeComponent();
            playerControls = new List<PlayerControl>();
            dynamicPanel.Location = new Point(200, 10);
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
                tbNumPlayers.Enabled = false;
               
                dynamicPanel.ResetControls(); // Making sure to reset controls on the panel if any was added.

                // Defining the maximum allowed size of the form and panel.
                int size = (numPlayers - 1) / 4;
                if (size > 5) { size = 5; }
                this.Size = new Size(_baseWidth + 200 * size, this.Height);                

                foreach (Player p in g.Players)
                {
                    PlayerControl userControl = new PlayerControl(p);
                    playerControls.Add(userControl);

                    dynamicPanel.AddControl(userControl);

                }
                dynamicPanel.UpdateControls();
                dynamicPanel.Size = new Size(200 * (size + 1), 520);

                this.Controls.Add(dynamicPanel);

                g.FillDeck();
                btnPlay.Text = "Play";
                Initialize();
            }

            else
            {
                g.PlayRound();
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