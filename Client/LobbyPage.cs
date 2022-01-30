using System;
using System.Windows.Forms;

namespace Client
{
    class LobbyPage : TabPage
    {
        internal readonly Button CreateTableButton = new()
        {
            Text = "Create table",
        };

        internal readonly Button SendMessageButton = new()
        {
            Text = "Send",
        };

        internal readonly TextBox ChatBox = new()
        {
            Enabled = false,
            Height = 500,
            Multiline = true,
        };

        internal readonly TextBox SendMessageBox = new()
        {
            PlaceholderText = "Type message",
        };

        private readonly FlowLayoutPanel _panel = new()
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
        };

        readonly Form1 _form1;

        public LobbyPage(Form1 form1)
        {
            _form1 = form1;
            Dock = DockStyle.Fill;
            Text = "Lobby";

            CreateTableButton.Click += CreateTable;
            SendMessageButton.Click += SendMessage;

            _panel.Controls.Add(CreateTableButton);
            _panel.Controls.Add(ChatBox);
            _panel.Controls.Add(SendMessageBox);
            _panel.Controls.Add(SendMessageButton);

            Controls.Add(_panel);
        }

        private void SendMessage(object sender, EventArgs e)
        {
            _form1.Client.WriteAsync(new Common.Message { Text = SendMessageBox.Text });
            SendMessageBox.Clear();
        }

        void CreateTable(object sender, EventArgs e)
        {
            _form1.TabControl.Controls.Add(_form1.TablePage);
            _form1.TabControl.SelectedTab = _form1.TablePage;
            CreateTableButton.Enabled = false;
        }
    }
}
