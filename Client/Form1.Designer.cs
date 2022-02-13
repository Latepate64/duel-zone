
using System.Drawing;
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
            var lobbyPage = new LobbyPage();
            var client = new Client();
            var tablePage = new TablePage(Size);
            var lobbyPanel = new LobbyPanel(_tabControl, client, tablePage);
            var menuPage = new MenuPage();
            var choicePanel = new ChoicePanel();
            SetupDependencies(menuPage, tablePage, client, new GameSetupForm(client), lobbyPage, lobbyPanel, choicePanel);
            AddControls(lobbyPage, lobbyPanel, menuPage);
        }

        private void AddControls(LobbyPage lobbyPage, LobbyPanel lobbyPanel, MenuPage menuPage)
        {
            Controls.Add(_tabControl);
            _tabControl.Controls.Add(menuPage);
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

        private void SetupDependencies(MenuPage menuPage, TablePage tablePage, Client client, GameSetupForm gameSetupForm, LobbyPage lobbyPage, LobbyPanel lobbyPanel, ChoicePanel choicePanel)
        {
            SetupMenuPage(menuPage, tablePage, client, lobbyPage);
            SetupChoicePanel(tablePage, client, choicePanel);
            SetupTablePage(tablePage, client, gameSetupForm, lobbyPage, lobbyPanel, choicePanel);
            SetupClient(tablePage, client, lobbyPanel);
        }

        private static void SetupChoicePanel(TablePage tablePage, Client client, ChoicePanel choicePanel)
        {
            choicePanel._client = client;
            choicePanel._tablePage = tablePage;

            choicePanel.UpdateSize(new Size(tablePage.ZonePanelSize.Width, (int)(0.5 * tablePage.ZonePanelSize.Height)));
            choicePanel.Left = ZonePanel.DefaultLeft;
            choicePanel.Top = 2 * tablePage.ZonePanelSize.Height + TablePage.ZoneOffset;
        }

        private static void SetupClient(TablePage tablePage, Client client, LobbyPanel lobbyPanel)
        {
            client._lobbyPanel = lobbyPanel;
            client._tablePage = tablePage;
        }

        private void SetupTablePage(TablePage tablePage, Client client, GameSetupForm gameSetupForm, LobbyPage lobbyPage, LobbyPanel lobbyPanel, ChoicePanel choicePanel)
        {
            tablePage.SetClient(client);
            tablePage._gameSetupForm = gameSetupForm;
            tablePage._lobbyPage = lobbyPage;
            tablePage._lobbyPanel = lobbyPanel;
            tablePage._tabControl = _tabControl;
            tablePage.SetChoicePanel(choicePanel);
        }

        private void SetupMenuPage(MenuPage menuPage, TablePage tablePage, Client client, LobbyPage lobbyPage)
        {
            menuPage._client = client;
            menuPage._lobbyPage = lobbyPage;
            menuPage._tabControl = _tabControl;
            menuPage._tablePage = tablePage;
        }
        #endregion
    }
}

