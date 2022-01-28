
using System;
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

        TabControl _tabControl = new TabControl
        {
            Dock = DockStyle.Fill,
        };

        TabPage _menu = new TabPage
        {
            Dock = DockStyle.Fill,
            Text = "Menu",
        };

        TabPage _lobby = new TabPage
        {
            Dock = DockStyle.Fill,
            Text = "Lobby"
        };

        TabPage _table = new TabPage
        {
            Dock = DockStyle.Fill,
            Text = "Table"
        };

        Button _connectButton = new Button
        {
            Dock = DockStyle.Right,
            Text = "Connect",
        };

        Button _createTableButton = new Button
        {
            Dock = DockStyle.Fill,
            Text = "Create table",
        };

        Button _exitTableButton = new Button
        {
            Dock = DockStyle.Fill,
            Text = "Exit table",
        };

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Duel Zone";

            _tabControl.Controls.Add(_menu);
            //tabControl.Controls.Add(GetTable());
            this.Controls.Add(_tabControl);
            InitializeMenu();
            InitializeLobby();
            InitializeTable();
        }

        void InitializeMenu()
        {
            _connectButton.Click += Connect;
            var serverAddress = new TextBox
            {
                Dock = DockStyle.Left,
                Text = "localhost",
                Width = 200,
            };
            _menu.Controls.Add(serverAddress);
            _menu.Controls.Add(_connectButton);
        }

        void Connect(object sender, System.EventArgs e)
        {
            _connectButton.Text = "Disconnect";
            _connectButton.Click -= Connect;
            _connectButton.Click += Disconnect;
            _tabControl.Controls.Add(_lobby);
            _tabControl.SelectedTab = _lobby;
        }

        void Disconnect(object sender, System.EventArgs e)
        {
            if (_tabControl.Controls.Contains(_table))
            {
                ExitTable(sender, e);
            }
            _connectButton.Text = "Connect";
            _connectButton.Click -= Disconnect;
            _connectButton.Click += Connect;
            _tabControl.Controls.Remove(_lobby);
            _tabControl.SelectedTab = _menu;
        }

        void InitializeLobby()
        {
            _createTableButton.Click += CreateTable;
            _lobby.Controls.Add(_createTableButton);
        }

        void CreateTable(object sender, EventArgs e)
        {
            _tabControl.Controls.Add(_table);
            _tabControl.SelectedTab = _table;
            _createTableButton.Enabled = false;
        }

        void InitializeTable()
        {
            _exitTableButton.Click += ExitTable;
            _table.Controls.Add(_exitTableButton);
        }

        void ExitTable(object sender, EventArgs e)
        {
            _createTableButton.Enabled = true;
            _tabControl.Controls.Remove(_table);
            _tabControl.SelectedTab = _lobby;
        }
        #endregion
    }
}

