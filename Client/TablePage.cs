using Common.Choices;
using Common.GameEvents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        readonly ZonePanel _opponentHand = new("Opponent's hand", Color.LightBlue, Common.ZoneType.Hand);
        readonly ZonePanel _opponentManaZone = new("Opponent's mana zone", Color.LightGreen, Common.ZoneType.ManaZone);
        readonly ZonePanel _opponentShieldZone = new("Opponent's shield zone", Color.LightYellow, Common.ZoneType.ShieldZone);
        readonly ZonePanel _opponentDeck = new("Opponent's deck", Color.SandyBrown, Common.ZoneType.Deck);
        readonly ZonePanel _opponentGraveyard = new("Opponent's graveyard", Color.Gray, Common.ZoneType.Graveyard);
        readonly ZonePanel _opponentBattleZone = new("Opponent's battle zone", Color.PaleVioletRed, Common.ZoneType.BattleZone) { Top = 0, Visible = true };

        readonly ZonePanel _playerBattleZone = new("Your battle zone", Color.PaleVioletRed, Common.ZoneType.BattleZone) { Top = ZonePanel.DefaultHeight + 10, Visible = true };
        readonly ZonePanel _playerGraveyard = new("Your graveyard", Color.Gray, Common.ZoneType.Graveyard);
        readonly ZonePanel _playerDeck = new("Your deck", Color.SandyBrown, Common.ZoneType.Deck);
        readonly ZonePanel _playerShieldZone = new("Your shield zone", Color.LightYellow, Common.ZoneType.ShieldZone);
        readonly ZonePanel _playerManaZone = new("Your mana zone", Color.LightGreen, Common.ZoneType.ManaZone);
        readonly ZonePanel _playerHand = new("Your hand", Color.LightBlue, Common.ZoneType.Hand) { Top = 2 * (ZonePanel.DefaultHeight + 10), Visible = true };

        IEnumerable<ZonePanel> Zones => new List<ZonePanel> { _playerBattleZone, _playerGraveyard, _playerDeck, _playerShieldZone, _playerManaZone, _playerHand, _opponentBattleZone, _opponentGraveyard, _opponentDeck, _opponentShieldZone, _opponentManaZone, _opponentHand };

        readonly PlayerPanel _opponentPanel;
        readonly PlayerPanel _playerPanel;

        readonly Form1 _form1;

        readonly TextBox _textBox = new() { ReadOnly = true, Height = 1000, Width = 550, Left = 1300, Multiline = true, ScrollBars = ScrollBars.Vertical };

        readonly ChoicePanel _choicePanel;

        internal Choice CurrentChoice;
        internal List<CardPanel> SelectedCards = new();

        public TablePage(Form1 form1)
        {
            _form1 = form1;

            Dock = DockStyle.Fill;
            Text = "Table";

            _opponentPanel = new("Opponent", 0);
            _playerPanel = new("You", 300);
            _choicePanel = new(_form1.Client, this) { Left = ZonePanel.DefaultLeft, Top = 3 * (ZonePanel.DefaultHeight + 10) };

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
            Controls.Add(_choicePanel);
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

        internal void OnStartGame(Common.StartGame startGame)
        {
            _form1.GameSetupForm.Invoke(new MethodInvoker(delegate { _form1.GameSetupForm.Hide(); }));
            bool playerInsteadOfOpponent = true;
            foreach (var playerDeck in startGame.Players)
            {
                foreach (var zone in GetZonePanels(playerInsteadOfOpponent))
                {
                    zone.Name = playerDeck.Player.Id.ToString();
                }
                foreach (var card in playerDeck.Deck)
                {
                    AddCard(playerInsteadOfOpponent ? _playerDeck : _opponentDeck, card);
                }
                playerInsteadOfOpponent = !playerInsteadOfOpponent;
            }
        }

        private List<ZonePanel> GetZonePanels(bool playerInsteadOfOpponent)
        {
            if (playerInsteadOfOpponent)
            {
                return new List<ZonePanel> { _playerBattleZone, _playerGraveyard, _playerDeck, _playerShieldZone, _playerManaZone, _playerHand };
            }
            else
            {
                return new List<ZonePanel> { _opponentBattleZone, _opponentGraveyard, _opponentDeck, _opponentShieldZone, _opponentManaZone, _opponentHand };
            }
        }

        internal void Process(GameEvent e)
        {
            _textBox.Invoke(new MethodInvoker(delegate { _textBox.AppendText(e + Environment.NewLine); }));
            if (e is CardMovedEvent cme && cme.Player != null)
            {
                RemoveCard(GetZonePanel(cme.Player.Id.ToString(), cme.Source), cme.CardInSourceZone.ToString());
                AddCard(GetZonePanel(cme.Player.Id.ToString(), cme.Destination), cme.CardInDestinationZone);
            }
            else if (e is TapEvent tap)
            {
                foreach (var card in tap.Cards.Select(x => x.Id))
                {
                    var panel = GetCardPanel(card.ToString());
                    panel.Invoke(new MethodInvoker(delegate { panel.TapOrUntap(tap.TapInsteadOfUntap); }));
                }
            }
            else if (e is SummoningSicknessEvent sse)
            {
                foreach (var card in sse.Cards.Select(x => x.Id))
                {
                    var panel = GetCardPanel(card.ToString());
                    panel.Invoke(new MethodInvoker(delegate { panel.RemoveSummoningSickness(); }));
                }
            }
        }

        internal void Process(Choice c)
        {
            CurrentChoice = c;
            _choicePanel.Invoke(new MethodInvoker(delegate { _choicePanel.DefaultButton.Enabled = true; _choicePanel.Label.Text = c.ToString(); }));
        }

        private CardPanel GetCardPanel(string id)
        {
            return Zones.Single(x => x.Controls.ContainsKey(id)).Controls.Find(id, true).OfType<CardPanel>().Single();
        }

        private static void RemoveCard(ZonePanel zone, string cardId)
        {
            zone?.Invoke(new MethodInvoker(delegate { zone.Controls.RemoveByKey(cardId); }));
        }

        private void AddCard(ZonePanel zone, Common.Card card)
        {
            zone?.Invoke(new MethodInvoker(delegate { zone.Controls.Add(new CardPanel(card, _form1.Client, this)); }));
        }

        private ZonePanel GetZonePanel(string playerId, Common.ZoneType zoneType)
        {
            return Zones.SingleOrDefault(x => x.Name == playerId && x.ZoneType == zoneType);
        }
    }
}