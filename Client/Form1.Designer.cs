
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
            this.ClientSize = Properties.Settings.Default.Resolution;
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            GameSetupForm = new(Client);
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;  
            this.Text = "Duel Zone";

            _tabControl.Controls.Add(_menuPage);
            this.Controls.Add(_tabControl);
            _menuPage = new MenuPage(this, _tabControl);
            LobbyPage = new LobbyPage(this, _tabControl);
            TablePage = new TablePage(this, _tabControl);
        }

        internal void CloseLobbyPage()
        {
            _tabControl.Controls.Remove(LobbyPage);
            _tabControl.SelectedTab = _menuPage;
            LobbyPage._panel._chatBox.Clear();
        }
        #endregion
    }
}

