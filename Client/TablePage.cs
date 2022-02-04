using Common.GameEvents;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    class TablePage : TabPage
    {
        readonly Button _exitTableButton = new()
        {
            Left = 1200,
            Text = "Exit table",
            Top = 800,
            Width = 200,
        };
        readonly Button _gameSetupButton = new()
        {
            Left = 1000,
            Text = "Setup game",
            Top = 800,
            Width = 200,
        };

        readonly ZonePanel _opponentHand = new("Opponent's hand", Color.LightBlue);
        readonly ZonePanel _opponentManaZone = new("Opponent's mana zone", Color.LightGreen);
        readonly ZonePanel _opponentShieldZone = new("Opponent's shield zone", Color.LightYellow);
        readonly ZonePanel _opponentDeck = new("Opponent's deck", Color.SandyBrown);
        readonly ZonePanel _opponentGraveyard = new("Opponent's graveyard", Color.Gray);
        readonly ZonePanel _opponentBattleZone = new("Opponent's battle zone", Color.PaleVioletRed) { Top = 0, Visible = true };

        readonly ZonePanel _playerBattleZone = new("Your battle zone", Color.PaleVioletRed) { Top = ZonePanel.DefaultHeight + 10, Visible = true };
        readonly ZonePanel _playerGraveyard = new("Your graveyard", Color.Gray);
        readonly ZonePanel _playerDeck = new("Your deck", Color.SandyBrown);
        readonly ZonePanel _playerShieldZone = new("Your shield zone", Color.LightYellow);

        readonly ZonePanel _playerManaZone = new("Your mana zone", Color.LightGreen);
        readonly ZonePanel _playerHand = new("Your hand", Color.LightBlue) { Top = 2 * (ZonePanel.DefaultHeight + 10), Visible = true };

        readonly PlayerPanel _opponentPanel;
        readonly PlayerPanel _playerPanel;

        readonly Form1 _form1;

        readonly TextBox _textBox = new() { ReadOnly = true, Height = 1000, Width = 550, Left = 1300, Multiline = true, ScrollBars = ScrollBars.Vertical, };

        public TablePage(Form1 form1)
        {
            _form1 = form1;

            Dock = DockStyle.Fill;
            Text = "Table";

            _opponentPanel = new("Opponent", 0);
            _playerPanel = new("You", 300);

            Foo(_playerPanel._battleZone, _playerBattleZone);
            Foo(_playerPanel._deck, _playerDeck);
            Foo(_playerPanel._graveyard, _playerGraveyard);
            Foo(_playerPanel._hand, _playerHand);
            Foo(_playerPanel._manaZone, _playerManaZone);
            Foo(_playerPanel._shieldZone, _playerShieldZone);

            Foo(_opponentPanel._battleZone, _opponentBattleZone);
            Foo(_opponentPanel._deck, _opponentDeck);
            Foo(_opponentPanel._graveyard, _opponentGraveyard);
            Foo(_opponentPanel._hand, _opponentHand);
            Foo(_opponentPanel._manaZone, _opponentManaZone);
            Foo(_opponentPanel._shieldZone, _opponentShieldZone);

            _gameSetupButton.Click += SetupGame;
            _exitTableButton.Click += ExitTable;
            AddControls();

            //TODO test
            _playerHand.Controls.Add(new CardPanel("Aqua Vehicle"));
        }

        private void Foo(Control button, Control control)
        {
            button.Click += (object sender, EventArgs e) => control.Visible = !control.Visible;
        }

        private void AddControls()
        {
            Controls.Add(_gameSetupButton);
            Controls.Add(_exitTableButton);

            Controls.Add(_opponentHand);
            Controls.Add(_opponentManaZone);
            Controls.Add(_opponentShieldZone);
            Controls.Add(_opponentDeck);
            Controls.Add(_opponentGraveyard);
            Controls.Add(_opponentBattleZone);

            Controls.Add(_playerBattleZone);
            Controls.Add(_playerGraveyard);
            Controls.Add(_playerDeck);
            Controls.Add(_playerShieldZone);
            Controls.Add(_playerManaZone);
            Controls.Add(_playerHand);

            Controls.Add(_opponentPanel);
            Controls.Add(_playerPanel);

            Controls.Add(_textBox);
        }

        private void SetupGame(object sender, EventArgs e)
        {
            _form1.GameSetupForm.GameSetupTable.Setup(_form1.UserName, "Computer");
            _form1.GameSetupForm.ShowDialog();
        }

        internal void ExitTable(object sender, EventArgs e)
        {
            _form1.Client.WriteAsync(new Common.LeaveTable());
        }

        internal void OnExitTable()
        {
            _form1.LobbyPage.Panel.CreateTableButton.Invoke(new MethodInvoker(delegate { _form1.LobbyPage.Panel.CreateTableButton.Enabled = true; }));
            _form1.TabControl.Invoke(new MethodInvoker(delegate { _form1.TabControl.Controls.Remove(_form1.TablePage); }));
            _form1.TabControl.Invoke(new MethodInvoker(delegate { _form1.TabControl.SelectedTab = _form1.LobbyPage; }));
        }

        internal void OnStartGame()
        {
            _form1.GameSetupForm.Invoke(new MethodInvoker(delegate { _form1.GameSetupForm.Hide(); }));
        }

        internal void Process(GameEvent e)
        {
            _textBox.Invoke(new MethodInvoker(delegate { _textBox.Text += e; _textBox.Text += Environment.NewLine; }));
        }
    }
}
