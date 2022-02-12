using Common;
using Common.Choices;
using Common.GameEvents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    internal class TablePage : TabPage
    {
        internal Choice _currentChoice;
        internal List<CardPanel> _selectedCards = new();

        internal const int ZoneOffset = 10;

        private readonly Button _exitTableButton = new()
        {
            Text = "Exit table",
            Height = 100,
            Width = 200,
        };
        private readonly Button _gameSetupButton = new()
        {
            Text = "Setup game",
            Height = 100,
            Width = 200,
        };
        internal Size ZonePanelSize => _zonePanels.First().Value.Size;
        private readonly Dictionary<Tuple<ZoneType, bool>, ZonePanel> _zonePanels = new();
        internal TabControl _tabControl;
        internal Client _client;
        internal LobbyPage _lobbyPage;
        internal LobbyPanel _lobbyPanel;
        internal GameSetupForm _gameSetupForm;
        private ChoicePanel _choicePanel; 
        private readonly TextBox _textBox = new() { ReadOnly = true, Multiline = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Right };
        private readonly List<CardPanel> _selectableCards = new();
        private PlayerPanel _opponentPanel;
        private PlayerPanel _playerPanel;
        private Label _phaseLabel = new() { Font = new(FontFamily.GenericSansSerif, 12), Height = 100, Width = 200 };

        internal TablePage(Size size)
        {
            SetupPanels(size);
            SetupZoneTops();
            SetupProperties();
            SetupClicks();
            AddControls();
            SetupFields(size);
        }

        internal void SetChoicePanel(ChoicePanel choicePanel)
        {
            _choicePanel = choicePanel;
            Controls.Add(_choicePanel);
            _zonePanels[new Tuple<ZoneType, bool>(ZoneType.Hand, true)].Top = _choicePanel.Bottom + ZoneOffset;
        }

        private void SetupFields(Size size)
        {
            _textBox.Width = (int)(0.19 * size.Width);
            _gameSetupButton.Top = _playerPanel.Bottom + ZoneOffset;
            _exitTableButton.Top = _gameSetupButton.Bottom + ZoneOffset;
            _phaseLabel.Top = _exitTableButton.Bottom + ZoneOffset;
        }

        private void SetupPanels(Size size)
        {
            SetupZonePanels(size);
            SetupVisiblePanels();
            SetupPlayerPanels();
        }

        private void SetupVisiblePanels()
        {
            _zonePanels[new Tuple<ZoneType, bool>(ZoneType.BattleZone, true)].Top = _zonePanels[new Tuple<ZoneType, bool>(ZoneType.BattleZone, false)].Bottom;
        }

        private void SetupPlayerPanels()
        {
            _opponentPanel = new("Opponent", this, _client);
            _playerPanel = new("You", this, _client) { Top = 300 };
        }

        private void SetupProperties()
        {
            Dock = DockStyle.Fill;
            Text = "Table";
        }

        private void SetupZonePanels(Size size)
        {
            foreach (var player in new[] { false, true })
            {
                foreach (var zoneType in new[] { ZoneType.BattleZone, ZoneType.Deck, ZoneType.Graveyard, ZoneType.Hand, ZoneType.ManaZone, ZoneType.ShieldZone })
                {
                    var panel = new ZonePanel(zoneType, player);
                    _zonePanels.Add(new Tuple<ZoneType, bool>(zoneType, player), panel);
                    panel.SetSize(size);
                    Controls.Add(panel);
                }
            }
        }

        private void SetupZoneTops()
        {
            var index = 0;
            var opponentBattleZone = _zonePanels[new Tuple<ZoneType, bool>(ZoneType.BattleZone, false)];
            foreach (var zone in _zonePanels.Where(x => !(x.Key.Item1 == ZoneType.BattleZone || (x.Key.Item1 == ZoneType.Hand && x.Key.Item2))).Select(x => x.Value))
            {
                zone.Top = opponentBattleZone.Bottom / 2 + ++index * ZoneOffset;
            }
        }

        private void SetupClicks()
        {
            foreach (var panel in new[] { _playerPanel, _opponentPanel })
            {
                foreach (var button in panel.ZoneButtons)
                {
                    SetupClick(button.Value, _zonePanels[new Tuple<ZoneType, bool>(button.Key, panel == _playerPanel)]);
                }
            }
            _gameSetupButton.Click += SetupGame;
            _exitTableButton.Click += ExitTable;
        }

        private static void SetupClick(Control button, Control control)
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
            Controls.Add(_opponentPanel);
            Controls.Add(_playerPanel);
            Controls.Add(_textBox);
            Controls.Add(_phaseLabel);
        }

        private void SetupGame(object sender, EventArgs e)
        {
            _gameSetupForm._gameSetupTable.Setup(_client._userName, "Computer");
            _gameSetupForm.ShowDialog();
        }

        internal void ExitTable(object sender, EventArgs e)
        {
            _client.WriteAsync(new LeaveTable());
        }

        internal void OnExitTable()
        {
            _lobbyPanel._createTableButton.Invoke(new MethodInvoker(delegate { _lobbyPanel._createTableButton.Enabled = true; }));
            _tabControl.Invoke(new MethodInvoker(delegate { _tabControl.Controls.Remove(this); }));
            _tabControl.Invoke(new MethodInvoker(delegate { _tabControl.SelectedTab = _lobbyPage; }));
        }

        internal void OnStartGame(StartGame startGame)
        {
            _playerPanel.Name = startGame.Players.First().Player.Id.ToString();
            _opponentPanel.Name = startGame.Players.Last().Player.Id.ToString();
            _gameSetupForm.Invoke(new MethodInvoker(delegate { _gameSetupForm.Hide(); }));
            bool playerInsteadOfOpponent = true;
            foreach (var playerDeck in startGame.Players)
            {
                playerInsteadOfOpponent = SetupPlayer(playerInsteadOfOpponent, playerDeck);
            }
        }

        private bool SetupPlayer(bool playerInsteadOfOpponent, PlayerDeck playerDeck)
        {
            SetupZoneNames(playerInsteadOfOpponent, playerDeck);
            AddDeckCards(playerInsteadOfOpponent, playerDeck);
            return !playerInsteadOfOpponent;
        }

        private void AddDeckCards(bool playerInsteadOfOpponent, PlayerDeck playerDeck)
        {
            foreach (var card in playerDeck.Deck)
            {
                AddCard(_zonePanels[new Tuple<ZoneType, bool>(ZoneType.Deck, playerInsteadOfOpponent)], card);
            }
        }

        private void SetupZoneNames(bool playerInsteadOfOpponent, PlayerDeck playerDeck)
        {
            foreach (var zone in GetZonePanels(playerInsteadOfOpponent))
            {
                zone.Name = playerDeck.Player.Id.ToString();
            }
        }

        private IEnumerable<ZonePanel> GetZonePanels(bool playerInsteadOfOpponent)
        {
            return _zonePanels.Where(x => x.Key.Item2 == playerInsteadOfOpponent).Select(x => x.Value);
        }

        internal void Process(GameEvent e)
        {
            _textBox.Invoke(new MethodInvoker(delegate { _textBox.AppendText(e + Environment.NewLine); }));
            if (e is CardMovedEvent cme && cme.Player != null)
            {
                Process(cme);
            }
            else if (e is TapEvent tap)
            {
                Process(tap);
            }
            else if (e is SummoningSicknessEvent sse)
            {
                Process(sse);
            }
            else if (e is WinEvent win && win.Player.Id.ToString() == _playerPanel.Name)
            {
                SetChoiceText("You won!");
            }
            else if (e is LoseEvent lose && lose.Player.Id.ToString() == _playerPanel.Name)
            {
                SetChoiceText("You lost!");
            }
            else if (e is PhaseBegunEvent phase)
            {
                _phaseLabel.Invoke(new MethodInvoker(delegate { _phaseLabel.Text = phase.ToString(); }));
            }
            else if (e is CreatureAttackedEvent attackEvent)
            {
                var panel = GetCardPanel(attackEvent.Attacker.Id.ToString());
                panel.Invoke(new MethodInvoker(delegate { panel.DrawCombat("Attacking"); }));
                try
                {
                    var targetPanel = GetCardPanel(attackEvent.Attackable.ToString());
                    targetPanel.Invoke(new MethodInvoker(delegate { targetPanel.DrawCombat("Target of attack"); }));
                }
                catch (Exception)
                {
                    // TODO: Should draw opponent as target of attack
                }
            }
            else if (e is CreatureStoppedAttackingEvent stop)
            {
                var panel = GetCardPanel(stop.Attacker.Id.ToString());
                panel.Invoke(new MethodInvoker(delegate { panel.RemoveCombat(); }));
            }
            else if (e is BlockEvent block)
            {
                var panel = GetCardPanel(block.Blocker.Id.ToString());
                panel.Invoke(new MethodInvoker(delegate { panel.DrawCombat("Blocking"); }));
            }
            else if (e is CreatureStoppedBlockingEvent stopBlock)
            {
                var panel = GetCardPanel(stopBlock.Blocker.Id.ToString());
                panel.Invoke(new MethodInvoker(delegate { panel.RemoveCombat(); }));
            }
            else if (e is AttackTargetRemovedEvent target)
            {
                if (target.TargetCard != null)
                {
                    var panel = GetCardPanel(target.TargetCard.Id.ToString());
                    panel.Invoke(new MethodInvoker(delegate { panel.RemoveCombat(); }));
                }
                else
                {
                    // TODO: Should antidraw opponent
                }
            }
            else if (e is CreatureSummonedEvent || e is AbilityTriggeredEvent || e is DeckShuffledEvent || e is ShieldsBrokenEvent || e is BattleEvent || e is WinBattleEvent || e is DirectAttackEvent) // These events need not to be displayed.
            { }
            else
            {
                throw new NotImplementedException(e.ToString());
            }
        }

        private void Process(SummoningSicknessEvent e)
        {
            foreach (var card in e.Cards.Select(x => x.Id))
            {
                var panel = GetCardPanel(card.ToString());
                panel.Invoke(new MethodInvoker(delegate { panel.RemoveSummoningSickness(); }));
            }
        }

        private void Process(TapEvent e)
        {
            foreach (var card in e.Cards.Select(x => x.Id))
            {
                var panel = GetCardPanel(card.ToString());
                panel.Invoke(new MethodInvoker(delegate { panel.TapOrUntap(e.TapInsteadOfUntap); }));
            }
        }

        private void Process(CardMovedEvent e)
        {
            RemoveCard(GetZonePanel(e.Player.Id.ToString(), e.Source), e.CardInSourceZone.ToString());
            AddCard(GetZonePanel(e.Player.Id.ToString(), e.Destination), e.CardInDestinationZone);
        }

        internal void Process(Choice c)
        {
            _currentChoice = c;
            SetChoiceText(c.ToString());
            if (c is CardSelection cardSelection)
            {
                Process(cardSelection);
            }
            else if (c is AttackTargetSelection targetSelection)
            {
                Process(targetSelection);
            }
            else if (c is YesNoChoice)
            {
                ProcessYesNoChoice();
            }
        }

        private void SetChoiceText(string text)
        {
            _choicePanel.Invoke(new MethodInvoker(delegate { _choicePanel._label.Text = text; }));
        }

        private void ProcessYesNoChoice()
        {
            _choicePanel.Invoke(new MethodInvoker(delegate { _choicePanel.ActivateDefaultButton("Take action"); _choicePanel.ActivateDeclineButton(); }));
        }

        private void Process(AttackTargetSelection targetSelection)
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

        private void Process(CardSelection cardSelection)
        {
            if (cardSelection.MinimumSelection == 0)
            {
                _choicePanel.Invoke(new MethodInvoker(delegate { _choicePanel.ActivateDefaultButton("Pass"); }));
            }
            foreach (var card in cardSelection.Options)
            {
                MarkSelectable(GetCardPanel(card.ToString()));
            }
        }

        private void MarkSelectable(CardPanel panel)
        {
            panel.Invoke(new MethodInvoker(delegate { panel.BackColor = Color.White; }));
            _selectableCards.Add(panel);
        }

        private CardPanel GetCardPanel(string id)
        {
            return _zonePanels.Values.Single(x => x.Controls.ContainsKey(id)).Controls.Find(id, true).OfType<CardPanel>().Single();
        }

        private static void RemoveCard(ZonePanel zone, string cardId)
        {
            zone?.Invoke(new MethodInvoker(delegate { zone.Controls.RemoveByKey(cardId); }));
        }

        private void AddCard(ZonePanel zone, Card card)
        {
            zone?.Invoke(new MethodInvoker(delegate { zone.Controls.Add(new CardPanel(card, _client, this, _zonePanels.First().Value.Height, zone.ZoneType == ZoneType.BattleZone || zone.ZoneType == ZoneType.ManaZone)); }));
        }

        private ZonePanel GetZonePanel(string playerId, ZoneType zoneType)
        {
            return _zonePanels.SingleOrDefault(x => x.Value.Name == playerId && x.Key.Item1 == zoneType).Value;
        }

        internal void ClearSelectedAndSelectableCards()
        {
            ClearSelectedCards();
            ClearSelectableCards();
            HideChoiceButtons();
        }

        private void HideChoiceButtons()
        {
            _choicePanel._defaultButton.Visible = false;
            _choicePanel._declineButton.Visible = false;
        }

        private void ClearSelectableCards()
        {
            foreach (var card in _selectableCards)
            {
                card.BackColor = Color.Black;
            }
            _selectableCards.Clear();
        }

        private void ClearSelectedCards()
        {
            foreach (var card in _selectedCards)
            {
                card.BackColor = Color.Black;
            }
            _selectedCards.Clear();
        }
    }
}