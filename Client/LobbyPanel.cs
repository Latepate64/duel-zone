using System;
using System.Windows.Forms;

namespace Client
{
    internal class LobbyPanel : FlowLayoutPanel
    {
        internal readonly Button _createTableButton = new()
        {
            Text = "Create table",
            Width = 300,
        };

        internal readonly Button _sendMessageButton = new()
        {
            Text = "Send",
        };

        internal readonly TextBox _chatBox = new()
        {
            Enabled = false,
            Height = 1000,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
        };

        internal readonly TextBox _sendMessageBox = new()
        {
            PlaceholderText = "Type message",
        };

        private readonly TabControl _tabControl;
        private readonly Client _client;
        private readonly TablePage _tablePage;

        public LobbyPanel(TabControl tabControl, Client client, TablePage tablePage)
        {
            _tabControl = tabControl;
            _client = client;
            _tablePage = tablePage;
            SetupProperties();
            SetupEvents();
            AddControls();
        }

        private void SetupEvents()
        {
            _createTableButton.Click += CreateTable;
            _sendMessageButton.Click += SendMessage;
        }

        private void SetupProperties()
        {
            Dock = DockStyle.Fill;
            FlowDirection = FlowDirection.LeftToRight;
        }

        private void AddControls()
        {
            Controls.Add(_createTableButton);
            Controls.Add(_chatBox);
            Controls.Add(_sendMessageBox);
            Controls.Add(_sendMessageButton);
        }

        private void SendMessage(object sender, EventArgs e)
        {
            _client.WriteAsync(new Common.Message { Text = _sendMessageBox.Text });
            _sendMessageBox.Clear();
        }

        private void CreateTable(object sender, EventArgs e)
        {
            _client.WriteAsync(new Common.CreateTable());
        }

        internal void OnCreateTable()
        {
            _tabControl.Invoke(new MethodInvoker(delegate { _tabControl.Controls.Add(_tablePage); _tabControl.SelectedTab = _tablePage; }));
            _createTableButton.Invoke(new MethodInvoker(delegate { _createTableButton.Enabled = false; }));
        }
    }
}
