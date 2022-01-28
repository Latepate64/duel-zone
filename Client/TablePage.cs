using System;
using System.Windows.Forms;

namespace Client
{
    class TablePage : TabPage
    {
        readonly Button _exitTableButton = new()
        {
            Dock = DockStyle.Fill,
            Text = "Exit table",
        };
        readonly Button _gameSetupButton = new()
        {
            Dock = DockStyle.Fill,
            Text = "Setup game",
        };

        readonly Form1 _form1;

        public TablePage(Form1 form1)
        {
            _form1 = form1;

            Dock = DockStyle.Fill;
            Text = "Table";

            _gameSetupButton.Click += SetupGame;
            Controls.Add(_gameSetupButton);

            _exitTableButton.Click += ExitTable;
            Controls.Add(_exitTableButton);
        }

        private void SetupGame(object sender, EventArgs e)
        {
            _form1.GameSetupForm.GameSetupTable.Setup(_form1.UserName, "Computer");
            _form1.GameSetupForm.ShowDialog();
        }

        internal void ExitTable(object sender, EventArgs e)
        {
            _form1.LobbyPage.CreateTableButton.Enabled = true;
            _form1.TabControl.Controls.Remove(_form1.TablePage);
            _form1.TabControl.SelectedTab = _form1.LobbyPage;
        }
    }
}
