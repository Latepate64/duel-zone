using System;
using System.Windows.Forms;

namespace Client
{
    class LobbyPage : TabPage
    {
        internal readonly Button CreateTableButton = new()
        {
            Dock = DockStyle.Fill,
            Text = "Create table",
        };

        readonly Form1 _form1;

        public LobbyPage(Form1 form1)
        {
            _form1 = form1;
            Dock = DockStyle.Fill;
            Text = "Lobby";

            CreateTableButton.Click += CreateTable;
            Controls.Add(CreateTableButton);
        }

        void CreateTable(object sender, EventArgs e)
        {
            _form1.TabControl.Controls.Add(_form1.TablePage);
            _form1.TabControl.SelectedTab = _form1.TablePage;
            CreateTableButton.Enabled = false;
        }
    }
}
