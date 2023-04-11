using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// THANK YOU CHATGPT!!!

namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class DynamicPanel : Panel
    {

        private int _maxWidth;
        private int _maxHeight;

        private List<UserControl> _userControls = new List<UserControl>();

        private int _numControls = 0;
        public IEnumerable<UserControl> UserControls => _userControls;

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
            //this.BorderStyle = BorderStyle.FixedSingle;
        }


        public void ResetLayout()
        {
            foreach (UserControl userControl in _userControls)
            {
                Controls.Remove(userControl);
            }
            _userControls.Clear();
            this.Size = new Size(200, 500);
        }

        public void AddControl(UserControl userControl)
        {
            _userControls.Add(userControl);
            Controls.Add(userControl);
            //_numControls++;
            UpdateLayout();
        }

        public void RemoveControl(UserControl userControl)
        {
            _userControls.Remove(userControl);
            Controls.Remove(userControl);
            //_numControls--;
            UpdateLayout();
        }

        private void UpdateLayout()
        {

            const int maxControlsInWidth = 24;
            int totalControls = 0;

            int yPos = 0;
            int xPos = 0;
            int lastControlYPos = 0; // Keep track of last control's y position
            int controlsInColumn = 1; // Keep track of how many controls have been added to the current column
            int columnWidth = 0; // Keep track of the maximum width of controls in the column

            foreach (var control in _userControls)
            {
                control.Location = new Point(xPos, yPos);


                // Check if we need to start a new column
                if (controlsInColumn % 4 == 0 && controlsInColumn > 0)
                {
                    xPos += columnWidth - 1; // Add spacing between columns - NO SPACING!
                    yPos = 0; // Use last control's y position for the new column
                    controlsInColumn = 0;
                    columnWidth = 0;
                }
                else
                {
                    yPos += control.Height - 1; // Add spacing between controls - NO SPACING!
                }

                // Update variables for next control
                lastControlYPos = control.Location.Y;
                controlsInColumn++;
                if (control.Width > columnWidth)
                {
                    columnWidth = control.Width;
                }
                totalControls++;

            }

            Width = xPos + columnWidth;
            if (Width > _maxWidth)
            {
                Width = _maxWidth;
                this.AutoScroll = true;
            }
            //Height = lastControlYPos + _userControls.Last().Height;
            //Height = yPos + _userControls.Last().Height;

            this.Size = new Size(Width, _maxHeight);
        }
}
}
