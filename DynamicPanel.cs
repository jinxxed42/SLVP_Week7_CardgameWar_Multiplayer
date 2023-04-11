using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// THANK YOU CHATGPT!!!

namespace SLVP_Week7_CardgameWar_Multiplayer
{
    public partial class DynamicPanel : Panel
    {


        private List<UserControl> _userControls = new List<UserControl>();

        public IEnumerable<UserControl> UserControls => _userControls;


        public DynamicPanel()
        {
            //this.BorderStyle = BorderStyle.FixedSingle;
        }


        public void AddControl(UserControl userControl)
        {
            _userControls.Add(userControl);
            Controls.Add(userControl);
            UpdateLayout();
        }

        public void RemoveControl(UserControl userControl)
        {
            _userControls.Remove(userControl);
            Controls.Remove(userControl);
            UpdateLayout();
        }

        private void InitializeComponent()
        {

        }

        private void UpdateLayout()
        {
            int yPos = 0;
            foreach (var control in _userControls)
            {
                control.Location = new Point(0, yPos);
                yPos += control.Height - 1;
            }
            Height = yPos;
        }
    }
}
