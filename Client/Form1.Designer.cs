
using System.Windows.Forms;

namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private TabControl _tabControl = new TabControl
        {
            Dock = DockStyle.Fill,
        };

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            SetupProperties();

            var menuPage = new MenuPage();
            var tablePage = new TablePage(Size);
            var client = new Client();
            var lobbyPage = new LobbyPage();
            var lobbyPanel = new LobbyPanel(_tabControl, client, tablePage);

            _tabControl.Controls.Add(menuPage);
            this.Controls.Add(_tabControl);
            SetupDependencies(menuPage, tablePage, client, new GameSetupForm(client), lobbyPage, lobbyPanel);

            lobbyPage.Controls.Add(lobbyPanel);
        }

        private void SetupProperties()
        {
            this.ClientSize = Properties.Settings.Default.Resolution;
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Duel Zone";
        }

        private void SetupDependencies(MenuPage menuPage, TablePage tablePage, Client client, GameSetupForm gameSetupForm, LobbyPage lobbyPage, LobbyPanel lobbyPanel)
        {
            menuPage._client = client;
            menuPage._lobbyPage = lobbyPage;
            menuPage._tabControl = _tabControl;
            menuPage._tablePage = tablePage;

            tablePage._client = client;
            tablePage._gameSetupForm = gameSetupForm;
            tablePage._lobbyPage = lobbyPage;
            tablePage._lobbyPanel = lobbyPanel;
            tablePage._tabControl = _tabControl;

            client._lobbyPanel = lobbyPanel;
            client._tablePage = tablePage;
        }
        #endregion
    }
}

