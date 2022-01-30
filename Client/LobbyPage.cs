using System;
using System.Windows.Forms;

namespace Client
{
    class LobbyPage : TabPage
    {
        internal readonly LobbyPanel Panel;

        public LobbyPage(Form1 form1)
        {
            Panel = new(form1);
            Dock = DockStyle.Fill;
            Text = "Lobby";
            Controls.Add(Panel);
        }
    }

    class LobbyPanel : FlowLayoutPanel
    {
        internal readonly Button CreateTableButton = new()
        {
            Text = "Create table",
            Width = 300,
        };

        internal readonly Button SendMessageButton = new()
        {
            Text = "Send",
        };

        internal readonly TextBox ChatBox = new()
        {
            Enabled = false,
            Height = 1000,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
        };

        internal readonly TextBox SendMessageBox = new()
        {
            PlaceholderText = "Type message",
        };

        readonly Form1 _form1;

        public LobbyPanel(Form1 form1)
        {
            _form1 = form1;

            Dock = DockStyle.Fill;
            FlowDirection = FlowDirection.LeftToRight;

            CreateTableButton.Click += CreateTable;
            SendMessageButton.Click += SendMessage;

            Controls.Add(CreateTableButton);
            Controls.Add(ChatBox);
            Controls.Add(SendMessageBox);
            Controls.Add(SendMessageButton);
        }

        private void SendMessage(object sender, EventArgs e)
        {
            _form1.Client.WriteAsync(new Common.Message { Text = SendMessageBox.Text });
            SendMessageBox.Clear();
        }

        private void CreateTable(object sender, EventArgs e)
        {
            _form1.Client.WriteAsync(new Common.CreateTable());
        }

        internal void OnCreateTable()
        {
            _form1.TabControl.Invoke(new MethodInvoker(delegate { _form1.TabControl.Controls.Add(_form1.TablePage); }));
            _form1.TabControl.Invoke(new MethodInvoker(delegate { _form1.TabControl.SelectedTab = _form1.TablePage; }));
            CreateTableButton.Invoke(new MethodInvoker(delegate { CreateTableButton.Enabled = false; }));
        }
    }
}
