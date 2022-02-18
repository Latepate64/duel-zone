using Common;
using System;
using System.Collections.Generic;
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

        internal readonly ListView _tables = new() { MultiSelect = false };

        private readonly TabControl _tabControl;
        private readonly Client _client;
        private readonly TablePage _tablePage;
        private readonly CheckBox _humanOpponent = new() { Text = "Human opponent" };

        public LobbyPanel(TabControl tabControl, Client client, TablePage tablePage)
        {
            _tabControl = tabControl;
            _client = client;
            _tablePage = tablePage;
            SetupProperties();
            SetupEvents();
            AddControls();
            _tables.ItemActivate += TableActivate;
        }

        private void TableActivate(object sender, EventArgs e)
        {
            _client.WriteAsync(new JoinTable { Table = new Table { Id = new Guid((sender as ListView).SelectedItems[0].Text), Guest = new Player(_client._player) } });
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
            Controls.Add(_humanOpponent);
            Controls.Add(_chatBox);
            Controls.Add(_sendMessageBox);
            Controls.Add(_sendMessageButton);
            Controls.Add(_tables);
        }

        private void SendMessage(object sender, EventArgs e)
        {
            _client.WriteAsync(new Common.Message { Text = _sendMessageBox.Text });
            _sendMessageBox.Clear();
        }

        private void CreateTable(object sender, EventArgs e)
        {
            _client.WriteAsync(new CreateTable 
            {
                Table = new Table { Host = new Player(_client._player), HumanOpponent = _humanOpponent.Checked }
            });
        }

        internal void OnCreateOrJoinTable()
        {
            _tabControl.Invoke(new MethodInvoker(delegate { _tabControl.Controls.Add(_tablePage); _tabControl.SelectedTab = _tablePage; }));
            _createTableButton.Invoke(new MethodInvoker(delegate { _createTableButton.Enabled = false; }));
        }

        internal void AddTables(IEnumerable<Table> tables)
        {
            foreach (var table in tables)
            {
                _tables.Items.Add(table.Id.ToString());
            }
        }
    }
}
