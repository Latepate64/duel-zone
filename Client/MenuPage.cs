using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    internal class MenuPage : TabPage
    {
        private readonly FlowLayoutPanel _panel = new()
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
        };

        private readonly Button _connectButton = new()
        {
            Text = "Connect",
        };

        internal readonly TextBox _userNameBox = new()
        {
            PlaceholderText = "Username",
            Text = "Shobu",
            Width = 200,
        };

        private readonly TextBox _serverAddress = new()
        {
            PlaceholderText = "Server address",
            Text = Properties.Settings.Default.IP,
            Width = 200,
        };

        internal TabControl _tabControl;
        internal Client _client;
        internal LobbyPage _lobbyPage;
        internal TablePage _tablePage;
        internal LobbyPanel _lobbyPanel;

        public MenuPage()
        {
            Dock = DockStyle.Fill;
            Text = "Menu";

            _connectButton.Click += Connect;
            SetupPanel();
            Controls.Add(_panel);
        }

        private void SetupPanel()
        {
            _panel.Controls.Add(_userNameBox);
            _panel.Controls.Add(_serverAddress);
            _panel.Controls.Add(_connectButton);
        }

        private void Connect(object sender, EventArgs e)
        {
            try
            {
                _client.Connect(_serverAddress.Text, 11000);
                Task.Run(() => _client.ReadLoop());
                OnConnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnConnect()
        {
            _connectButton.Text = "Disconnect";
            _connectButton.Click -= Connect;
            _connectButton.Click += EndConnect;
            _tabControl.Controls.Add(_lobbyPage);
            _tabControl.SelectedTab = _lobbyPage;
        }

        private void EndConnect(object sender, EventArgs e)
        {
            _client.EndConnect();
            if (_tabControl.Controls.Contains(_tablePage))
            {
                _tablePage.ExitTable(null, null);
            }
            UpdateConnectButton();
            UpdateTabControl();
            _lobbyPanel._chatBox.Clear();
        }

        private void UpdateTabControl()
        {
            _tabControl.Controls.Remove(_lobbyPage);
            _tabControl.SelectedTab = this;
        }

        private void UpdateConnectButton()
        {
            _connectButton.Text = "Connect";
            _connectButton.Click -= EndConnect;
            _connectButton.Click += Connect;
        }
    }
}
