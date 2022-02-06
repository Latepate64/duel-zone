
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

        internal TabControl TabControl = new TabControl
        {
            Dock = DockStyle.Fill,
        };

        MenuPage _menuPage;
        internal LobbyPage LobbyPage;
        internal TablePage TablePage;
        internal GameSetupForm GameSetupForm;
        internal Client Client = new();

        internal string UserName;

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            _menuPage = new MenuPage(this);
            LobbyPage = new LobbyPage(this);
            TablePage = new TablePage(this);
            GameSetupForm = new(Client);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = Properties.Settings.Default.Resolution;
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            this.Text = "Duel Zone";

            TabControl.Controls.Add(_menuPage);
            this.Controls.Add(TabControl);
        }

        internal void CloseLobbyPage()
        {
            TabControl.Controls.Remove(LobbyPage);
            TabControl.SelectedTab = _menuPage;
            LobbyPage.Panel.ChatBox.Clear();
        }
        #endregion
    }
}

