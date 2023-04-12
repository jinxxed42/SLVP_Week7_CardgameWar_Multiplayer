using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class DynamicPanel : Panel
    {

        private int _maxWidth;
        private int _maxHeight;

        //private List<UserControl> _userControls = new List<UserControl>();

        private List<PlayerControl> _playerControls = new List<PlayerControl>();

        //public IEnumerable<UserControl> UserControls => _userControls;

        //public IEnumerable<PlayerControl> 

        private void InitializeComponent()
        {
            this.Size = new Size(200, 500);
        }

        public DynamicPanel()
        {
            
        }

        public DynamicPanel(int maxWidth, int maxHeight)
        {
            _maxWidth = maxWidth;
            _maxHeight = maxHeight; 
        }


        internal void ResetLayout()
        {
            foreach (PlayerControl playerControl in _playerControls)
            {
                Controls.Remove(playerControl);
            }
            _playerControls.Clear();
            this.Size = new Size(200, 500);
        }

        internal void AddControl(PlayerControl playerControl)
        {
            _playerControls.Add(playerControl);
            Controls.Add(playerControl);
            UpdateLayout();
        }

        internal void RemoveControl(PlayerControl playerControl)
        {
            _playerControls.Remove(playerControl);
            Controls.Remove(playerControl);
            UpdateLayout();
        }

        private void UpdateLayout()
        {

            //const int maxControlsInWidth = 24;
            int totalControls = 0;

            int yPos = 0;
            int xPos = 0;
            int lastControlYPos = 0; // Keep track of last control's y position
            int controlsInColumn = 1; // Keep track of how many controls have been added to the current column
            int columnWidth = 0; // Keep track of the maximum width of controls in the column

            foreach (PlayerControl playerControl in _playerControls)
            {
                playerControl.Location = new Point(xPos, yPos);


                // Check if we need to start a new column
                if (controlsInColumn % 4 == 0 && controlsInColumn > 0)
                {
                    xPos += columnWidth - 1; 
                    yPos = 0; 
                    controlsInColumn = 0;
                    columnWidth = 0;
                }
                else
                {
                    yPos += playerControl.Height - 1; 
                }

                // Update variables for next control
                lastControlYPos = playerControl.Location.Y;
                controlsInColumn++;
                if (playerControl.Width > columnWidth)
                {
                    columnWidth = playerControl.Width;
                }
                totalControls++;

            }

            Width = xPos + columnWidth;
            if (Width > _maxWidth)
            {
                Width = _maxWidth;
                this.AutoScroll = true;
            }

            this.Size = new Size(Width, _maxHeight);
        }
    }
}
