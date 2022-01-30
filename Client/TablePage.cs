using System;
using System.Windows.Forms;

namespace Client
{
    class TablePage : TabPage
    {
        readonly Button _exitTableButton = new()
        {
            Text = "Exit table",
            Width = 200,
        };
        readonly Button _gameSetupButton = new()
        {
            Text = "Setup game",
            Width = 200,
        };
        readonly FlowLayoutPanel _panel = new()
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
        };

        readonly Form1 _form1;

        public TablePage(Form1 form1)
        {
            _form1 = form1;

            Dock = DockStyle.Fill;
            Text = "Table";

            _gameSetupButton.Click += SetupGame;
            _exitTableButton.Click += ExitTable;

            _panel.Controls.Add(_gameSetupButton);
            _panel.Controls.Add(_exitTableButton);

            Controls.Add(_panel);
        }

        private void SetupGame(object sender, EventArgs e)
        {
            _form1.GameSetupForm.GameSetupTable.Setup(_form1.UserName, "Computer");
            _form1.GameSetupForm.ShowDialog();
        }

        internal void ExitTable(object sender, EventArgs e)
        {
            _form1.Client.WriteAsync(new Common.LeaveTable());
        }

        internal void OnExitTable()
        {
            _form1.LobbyPage.Panel.CreateTableButton.Invoke(new MethodInvoker(delegate { _form1.LobbyPage.Panel.CreateTableButton.Enabled = true; }));
            _form1.TabControl.Invoke(new MethodInvoker(delegate { _form1.TabControl.Controls.Remove(_form1.TablePage); }));
            _form1.TabControl.Invoke(new MethodInvoker(delegate { _form1.TabControl.SelectedTab = _form1.LobbyPage; }));
        }

        internal void OnStartGame()
        {
            // TODO
        }
    }
}
