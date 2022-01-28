using System.Windows.Forms;

namespace Client
{
    class MenuPage : TabPage
    {
        readonly FlowLayoutPanel _panel = new()
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
        };

        readonly Button _connectButton = new()
        {
            Text = "Connect",
        };

        readonly TextBox _userNameBox = new()
        {
            PlaceholderText = "Username",
            Text = "Shobu",
            Width = 200,
        };

        readonly Form1 _form1;

        public MenuPage(Form1 form1)
        {
            _form1 = form1;
            Dock = DockStyle.Fill;
            Text = "Menu";

            _connectButton.Click += Connect;
            SetupPanel();
            Controls.Add(_panel);
        }

        private void SetupPanel()
        {
            var serverAddress = new TextBox
            {
                PlaceholderText = "Server address",
                Text = "localhost",
                Width = 200,
            };
            _panel.Controls.Add(_userNameBox);
            _panel.Controls.Add(serverAddress);
            _panel.Controls.Add(_connectButton);
        }

        void Connect(object sender, System.EventArgs e)
        {
            _form1.UserName = _userNameBox.Text;
            _connectButton.Text = "Disconnect";
            _connectButton.Click -= Connect;
            _connectButton.Click += Disconnect;
            _form1.TabControl.Controls.Add(_form1.LobbyPage);
            _form1.TabControl.SelectedTab = _form1.LobbyPage;
        }

        void Disconnect(object sender, System.EventArgs e)
        {
            if (_form1.TabControl.Controls.Contains(_form1.TablePage))
            {
                _form1.TablePage.ExitTable(sender, e);
            }
            _connectButton.Text = "Connect";
            _connectButton.Click -= Disconnect;
            _connectButton.Click += Connect;
            _form1.CloseLobbyPage();
        }
    }
}
