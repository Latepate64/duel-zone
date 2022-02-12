using System.Windows.Forms;

namespace Client
{
    class GameSetupForm : Form
    {
        internal readonly GameSetupPanel _gameSetupTable;
        
        public GameSetupForm(Client client)
        {
            _gameSetupTable = new(client);
            Dock = DockStyle.Fill;
            Text = "Game setup";
            Controls.Add(_gameSetupTable);
        }
    }
}
