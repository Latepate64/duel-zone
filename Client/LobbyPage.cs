using System;
using System.Windows.Forms;

namespace Client
{
    class LobbyPage : TabPage
    {
        internal readonly LobbyPanel _panel;

        public LobbyPage(Form1 form1, TabControl tabControl)
        {
            Dock = DockStyle.Fill;
            Text = "Lobby";
            _panel = new(form1, tabControl);
            Controls.Add(_panel);
        }
    }

    class LobbyPanel : FlowLayoutPanel
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

        readonly Form1 _form1;
        private readonly TabControl _tabControl;

        public LobbyPanel(Form1 form1, TabControl tabControl)
        {
            _form1 = form1;
            _tabControl = tabControl;
            Dock = DockStyle.Fill;
            FlowDirection = FlowDirection.LeftToRight;

            _createTableButton.Click += CreateTable;
            _sendMessageButton.Click += SendMessage;

            Controls.Add(_createTableButton);
            Controls.Add(_chatBox);
            Controls.Add(_sendMessageBox);
            Controls.Add(_sendMessageButton);
        }

        private void SendMessage(object sender, EventArgs e)
        {
            _form1.Client.WriteAsync(new Common.Message { Text = _sendMessageBox.Text });
            _sendMessageBox.Clear();
        }

        private void CreateTable(object sender, EventArgs e)
        {
            _form1.Client.WriteAsync(new Common.CreateTable());
        }

        internal void OnCreateTable()
        {
            _tabControl.Invoke(new MethodInvoker(delegate { _tabControl.Controls.Add(_form1.TablePage); }));
            _tabControl.Invoke(new MethodInvoker(delegate { _tabControl.SelectedTab = _form1.TablePage; }));
            _createTableButton.Invoke(new MethodInvoker(delegate { _createTableButton.Enabled = false; }));
        }
    }
}
