﻿using Common.Choices;
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
            Text = "Exit table",
            Height = 100,
            Width = 200,
        };
        readonly Button _gameSetupButton = new()
        {
            Text = "Setup game",
            Height = 100,
            Width = 200,
        };

        readonly ZonePanel _opponentHand = new("Opponent's hand", Color.LightBlue, Common.ZoneType.Hand);
        readonly ZonePanel _opponentManaZone = new("Opponent's mana zone", Color.LightGreen, Common.ZoneType.ManaZone);
        readonly ZonePanel _opponentShieldZone = new("Opponent's shield zone", Color.LightYellow, Common.ZoneType.ShieldZone);
        readonly ZonePanel _opponentDeck = new("Opponent's deck", Color.SandyBrown, Common.ZoneType.Deck);
        readonly ZonePanel _opponentGraveyard = new("Opponent's graveyard", Color.Gray, Common.ZoneType.Graveyard);
        readonly ZonePanel _opponentBattleZone = new("Opponent's battle zone", Color.PaleVioletRed, Common.ZoneType.BattleZone) { Visible = true };

        readonly ZonePanel _playerBattleZone = new("Your battle zone", Color.PaleVioletRed, Common.ZoneType.BattleZone) { Visible = true };
        readonly ZonePanel _playerGraveyard = new("Your graveyard", Color.Gray, Common.ZoneType.Graveyard);
        readonly ZonePanel _playerDeck = new("Your deck", Color.SandyBrown, Common.ZoneType.Deck);
        readonly ZonePanel _playerShieldZone = new("Your shield zone", Color.LightYellow, Common.ZoneType.ShieldZone);
        readonly ZonePanel _playerManaZone = new("Your mana zone", Color.LightGreen, Common.ZoneType.ManaZone);
        readonly ZonePanel _playerHand = new("Your hand", Color.LightBlue, Common.ZoneType.Hand) { Visible = true };

        IEnumerable<ZonePanel> Zones => new List<ZonePanel> { _playerBattleZone, _playerGraveyard, _playerDeck, _playerShieldZone, _playerManaZone, _playerHand, _opponentBattleZone, _opponentGraveyard, _opponentDeck, _opponentShieldZone, _opponentManaZone, _opponentHand };

        readonly PlayerPanel _opponentPanel;
        readonly PlayerPanel _playerPanel;

        readonly Form1 _form1;

        readonly TextBox _textBox = new() { ReadOnly = true, Height = 1000, Multiline = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Right };

        readonly ChoicePanel _choicePanel;

        internal Choice CurrentChoice;
        internal List<CardPanel> SelectedCards = new();
        internal List<CardPanel> SelectableCards = new();

        public TablePage(Form1 form1)
        {
            _form1 = form1;

            foreach (var zone in Zones)
            {
                zone.SetSize(form1.Size);
            }
            _textBox.Width = (int)(0.19 * form1.Width);
            _playerBattleZone.Top = _opponentBattleZone.Bottom;
            const int ZoneOffset = 10;
            _choicePanel = new(_form1.Client, this, new Size(_playerBattleZone.Width, (int)(0.5 * _playerBattleZone.Height))) { Left = ZonePanel.DefaultLeft, Top = 2 * (_playerBattleZone.Height + ZoneOffset) };
            _playerHand.Top = _choicePanel.Bottom + ZoneOffset;

            var index = 0;
            foreach (var zone in Zones.Except(new List<ZonePanel> { _opponentBattleZone, _playerBattleZone, _playerHand }))
            {
                zone.Top = _opponentBattleZone.Bottom / 2 + ++index * ZoneOffset;
            }

            Dock = DockStyle.Fill;
            Text = "Table";

            _opponentPanel = new("Opponent", 0, this, _form1.Client);
            _playerPanel = new("You", 300, this, _form1.Client);

            SetupClick(_playerPanel._battleZone, _playerBattleZone);
            SetupClick(_playerPanel._deck, _playerDeck);
            SetupClick(_playerPanel._graveyard, _playerGraveyard);
            SetupClick(_playerPanel._hand, _playerHand);
            SetupClick(_playerPanel._manaZone, _playerManaZone);
            SetupClick(_playerPanel._shieldZone, _playerShieldZone);

            SetupClick(_opponentPanel._battleZone, _opponentBattleZone);
            SetupClick(_opponentPanel._deck, _opponentDeck);
            SetupClick(_opponentPanel._graveyard, _opponentGraveyard);
            SetupClick(_opponentPanel._hand, _opponentHand);
            SetupClick(_opponentPanel._manaZone, _opponentManaZone);
            SetupClick(_opponentPanel._shieldZone, _opponentShieldZone);

            _gameSetupButton.Click += SetupGame;
            _exitTableButton.Click += ExitTable;
            AddControls();

            _gameSetupButton.Top = _playerPanel.Bottom + ZoneOffset;
            _exitTableButton.Top = _gameSetupButton.Bottom + ZoneOffset;
        }

        private void SetupClick(Control button, Control control)
        {
            button.Click += (object sender, EventArgs e) =>
            {
                control.Visible = !control.Visible;
                control.BringToFront();
            };
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
            _opponentPanel.Name = startGame.Players.Last().Player.Id.ToString();
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
            _choicePanel.Invoke(new MethodInvoker(delegate { _choicePanel._label.Text = c.ToString(); }));
            if (c is CardSelection cardSelection)
            {
                if (cardSelection.MinimumSelection == 0)
                {
                    _choicePanel.Invoke(new MethodInvoker(delegate { _choicePanel._defaultButton.Visible = true; }));
                }
                foreach (var card in cardSelection.Options)
                {
                    MarkSelectable(GetCardPanel(card.ToString()));
                }
            }
            else if (c is AttackTargetSelection targetSelection)
            {
                foreach (var option in targetSelection.Options)
                {
                    if (option.ToString() == _opponentPanel.Name)
                    {
                        _opponentPanel.Invoke(new MethodInvoker(delegate { _opponentPanel.Enabled = true; }));
                    }
                    else
                    {
                        MarkSelectable(GetCardPanel(option.ToString()));
                    }
                }
            }
            else if (c is YesNoChoice yesNoChoice)
            {
                _choicePanel._declineButton.Visible = true;
            }
        }

        private void MarkSelectable(CardPanel panel)
        {
            panel.Invoke(new MethodInvoker(delegate { panel.BackColor = Color.White; }));
            SelectableCards.Add(panel);
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
            zone?.Invoke(new MethodInvoker(delegate { zone.Controls.Add(new CardPanel(card, _form1.Client, this, _playerBattleZone.Height, zone.ZoneType == Common.ZoneType.BattleZone || zone.ZoneType == Common.ZoneType.ManaZone)); }));
        }

        private ZonePanel GetZonePanel(string playerId, Common.ZoneType zoneType)
        {
            return Zones.SingleOrDefault(x => x.Name == playerId && x.ZoneType == zoneType);
        }

        internal void ClearSelectedAndSelectableCards()
        {
            foreach (var card in SelectedCards)
            {
                card.BackColor = Color.Black;
            }
            SelectedCards.Clear();
            foreach (var card in SelectableCards)
            {
                card.BackColor = Color.Black;
            }
            SelectableCards.Clear();
            _choicePanel._defaultButton.Visible = false;
            _choicePanel._declineButton.Visible = false;
        }
    }
}