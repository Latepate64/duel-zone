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

        const int Offset = 80;

        readonly ZonePanel _opponentHand = new("Opponent's hand", 0, Color.LightBlue);
        readonly ZonePanel _opponentManaZone = new("Opponent's mana zone", 1 * Offset, Color.LightGreen);
        readonly ZonePanel _opponentShieldZone = new("Opponent's shield zone", 2 * Offset, Color.LightYellow);
        readonly ZonePanel _opponentDeck = new("Opponent's deck", 3 * Offset, Color.SandyBrown);
        readonly ZonePanel _opponentGraveyard = new("Opponent's graveyard", 4 * Offset, Color.Gray);
        readonly ZonePanel _opponentBattleZone = new("Opponent's battle zone", 5 * Offset, Color.PaleVioletRed);

        readonly ZonePanel _playerBattleZone = new("Your battle zone", 6 * Offset, Color.PaleVioletRed);
        readonly ZonePanel _playerGraveyard = new("Your graveyard", 7 * Offset, Color.Gray);
        readonly ZonePanel _playerDeck = new("Your deck", 8 * Offset, Color.SandyBrown);
        readonly ZonePanel _playerShieldZone = new("Your shield zone", 9 * Offset, Color.LightYellow);
        readonly ZonePanel _playerManaZone = new("Your mana zone", 10 * Offset, Color.LightGreen);
        readonly ZonePanel _playerHand = new("Your hand", 11 * Offset, Color.LightBlue);

        readonly PlayerPanel _opponentPanel = new("Opponent", 0);
        readonly PlayerPanel _playerPanel = new("You", 300);

        readonly Form1 _form1;

        public TablePage(Form1 form1)
        {
            _form1 = form1;

            Dock = DockStyle.Fill;
            Text = "Table";

            _gameSetupButton.Click += SetupGame;
            _exitTableButton.Click += ExitTable;
            AddControls();

            //TODO test
            _playerHand.Controls.Add(new CardPanel("Aqua Vehicle"));
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
            // TODO
        }
    }
}
