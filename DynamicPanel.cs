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
        private List<PlayerControl> _playerControls = new List<PlayerControl>();

        public DynamicPanel()
        {
            this.AutoScroll = true;
        }


        internal void ResetControls()
        {                       
            if (_playerControls.Any()) { 
                foreach (PlayerControl playerControl in _playerControls)
                {
                    Controls.Remove(playerControl);
                }            
                _playerControls.Clear();
            }
        }
        

        internal void AddControl(PlayerControl playerControl)
        {
            _playerControls.Add(playerControl);
            Controls.Add(playerControl);
        }

        internal void UpdateControls()
        {

            int yPos = 0;
            int xPos = 0;
            int controlsInColumn = 0; // Keep track of how many controls have been added to the current column

            foreach (PlayerControl playerControl in _playerControls)
            {
                playerControl.Location = new Point(xPos, yPos);

                controlsInColumn++;

                // Check if we need to start a new column
                if (controlsInColumn % 4 == 0)
                {
                    xPos += playerControl.Width - 1; 
                    yPos = 0;                   
                }
                else
                {
                    yPos += playerControl.Height - 1; 
                }

                //Width = xPos + playerControl.Width;
            }

            /**
            if (Width > _maxWidth)
            {
                Width = _maxWidth;
                this.AutoScroll = true;

            }
            this.Size = new Size(Width, _maxHeight);
            **/

            //this.Size = new Size(_width, _height);
            
        }
    }
}
