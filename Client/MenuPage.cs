﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class MenuPage : TabPage
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

        private readonly TextBox _userNameBox = new()
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

        private readonly Form1 _form1;
        private readonly TabControl _tabControl;

        public MenuPage(Form1 form1, TabControl tabControl)
        {
            _form1 = form1;
            _tabControl = tabControl;
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
                _form1.Client.Connect(_serverAddress.Text, 11000);
                Task.Run(() => _form1.Client.ReadLoop(_form1));
                OnConnect();
                _form1.Client.WriteAsync(new Common.ClientName() { Name = _userNameBox.Text });
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
            _tabControl.Controls.Add(_form1.LobbyPage);
            _tabControl.SelectedTab = _form1.LobbyPage;
        }

        private void EndConnect(object sender, EventArgs e)
        {
            _form1.Client.EndConnect();
            if (_tabControl.Controls.Contains(_form1.TablePage))
            {
                _form1.TablePage.ExitTable(null, null);
            }
            _connectButton.Text = "Connect";
            _connectButton.Click -= EndConnect;
            _connectButton.Click += Connect;
            _form1.CloseLobbyPage();
        }
    }
}
