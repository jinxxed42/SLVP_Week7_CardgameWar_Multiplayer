namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class Form1 : Form
    {
        Game g = new Game();
        List<PlayerControl> playerControls;
        //private DynamicPanel dynamicPanel;
        DynamicPanel dynamicPanel = new DynamicPanel(1200, 520);
        int rounds = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (btnPlay.Text == "Start game!")
            {
                rounds = 0;
                /**
                if (Controls.Contains(dynamicPanel))
                {
                    Controls.Remove(dynamicPanel);
                }
                **/

                this.Size = new Size(500, 600);

                int numPlayers = int.Parse(tbNumPlayers.Text);
                g.StartGame(numPlayers);

                int addedPanels = 0;
                //int addedColumns = 0;

                //DynamicPanel dynamicPanel = new DynamicPanel();

                dynamicPanel.ResetLayout();
                dynamicPanel.Location = new Point(200, 10);
                //dynamicPanel.Size = new Size(200, 500);
                int dynPanelWidth = 200;

                playerControls = new List<PlayerControl>();

                foreach (Player p in g.players)
                {

                    // Virker, men resizer først efter 8? Hvilket er idéelt!
                    if (addedPanels % 4 == 0 && addedPanels < 24 && addedPanels > 3)
                    {
                        //if (addedColumns < 3)
                        //{

                        //Point newLoc = new Point(dynamicPanel.Location.X + 199, dynamicPanel.Location.Y);
                        //this.Controls.Add(dynamicPanel);
                        //dynamicPanel = new DynamicPanel();
                        //dynamicPanel.Location = newLoc;
                        //addedPanels = 0;
                        this.Size = new Size(this.Width + 200, this.Height);
                        //dynPanelWidth = 200;
                        dynPanelWidth += 210;
                        //dynamicPanel.Size = new Size(dynamicPanel.Size.Width + 210, 500);

                        //addedColumns++;
                        //}
                    }
                    PlayerControl userControl = new PlayerControl(p);
                    playerControls.Add(userControl);

                    dynamicPanel.AddControl(userControl);
                    //dynamicPanel.Size = new Size(dynPanelWidth, 500);


                    //dynamicPanel.AutoScroll = true;

                    addedPanels++;
                    //dynPanelWidth += 210;
                }
                this.Controls.Add(dynamicPanel);

                g.FillDeck();
                btnPlay.Text = "Play";
                Initialize();
            }

            else
            {
                g.PlayRound();
                rounds++;
                lblRoundsText.Text = rounds.ToString();
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
            }
        }
    }

}