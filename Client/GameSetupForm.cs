using System;
using System.Windows.Forms;

namespace Client
{
    class GameSetupForm : Form
    {
        internal readonly GameSetupPanel GameSetupTable = new();
        
        public GameSetupForm()
        {
            Dock = DockStyle.Fill;
            Text = "Game setup";
            Controls.Add(GameSetupTable);
        }
    }
}
