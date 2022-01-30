using System.Windows.Forms;

namespace Client
{
    class GameSetupForm : Form
    {
        internal readonly GameSetupPanel GameSetupTable;
        
        public GameSetupForm(Client client)
        {
            GameSetupTable = new(client);
            Dock = DockStyle.Fill;
            Text = "Game setup";
            Controls.Add(GameSetupTable);
        }
    }
}
