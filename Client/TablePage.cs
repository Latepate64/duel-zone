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

        private Dictionary<Tuple<ZoneType, bool>, ZonePanel> _zonePanels = new();

        private readonly PlayerPanel _opponentPanel;
        private readonly PlayerPanel _playerPanel;

        private readonly Form1 _form1;

        private readonly TextBox _textBox = new() { ReadOnly = true, Height = 1000, Multiline = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Right };

        private readonly ChoicePanel _choicePanel;

        internal Choice _currentChoice;
        internal List<CardPanel> _selectedCards = new();
        internal List<CardPanel> _selectableCards = new();

        private const int ZoneOffset = 10;

        internal TablePage(Form1 form1)
        {
            _form1 = form1;

            foreach (var player in new[] { false, true })
            {
                foreach (var zoneType in new[] { ZoneType.BattleZone, ZoneType.Deck, ZoneType.Graveyard, ZoneType.Hand, ZoneType.ManaZone, ZoneType.ShieldZone })
                {
                    var panel = new ZonePanel(zoneType, player);
                    _zonePanels.Add(new Tuple<ZoneType, bool>(zoneType, player), panel);
                    panel.SetSize(form1.Size);
                    Controls.Add(panel);
                }
            }

            _textBox.Width = (int)(0.19 * form1.Width);
            var playerBattleZone = _zonePanels[new Tuple<ZoneType, bool>(ZoneType.BattleZone, true)];
            playerBattleZone.Top = _zonePanels[new Tuple<ZoneType, bool>(ZoneType.BattleZone, false)].Bottom;
            _choicePanel = new(_form1.Client, this, new Size(playerBattleZone.Width, (int)(0.5 * playerBattleZone.Height))) { Left = ZonePanel.DefaultLeft, Top = 2 * playerBattleZone.Height + ZoneOffset };
            _zonePanels[new Tuple<ZoneType, bool>(ZoneType.Hand, true)].Top = _choicePanel.Bottom + ZoneOffset;
            _opponentPanel = new("Opponent", 0, this, _form1.Client);
            _playerPanel = new("You", 300, this, _form1.Client);
            SetupZoneTops();
            Dock = DockStyle.Fill;
            Text = "Table";
            SetupClicks();
            AddControls();
            _gameSetupButton.Top = _playerPanel.Bottom + ZoneOffset;
            _exitTableButton.Top = _gameSetupButton.Bottom + ZoneOffset;
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
                foreach (var button in panel._zoneButtons)
                {
                    SetupClick(button.Value, _zonePanels[new Tuple<ZoneType, bool>(button.Key, panel == _playerPanel)]);
                }
            }
            _gameSetupButton.Click += SetupGame;
            _exitTableButton.Click += ExitTable;
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
                    AddCard(_zonePanels[new Tuple<ZoneType, bool>(ZoneType.Deck, playerInsteadOfOpponent)], card);
                }
                playerInsteadOfOpponent = !playerInsteadOfOpponent;
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
            _currentChoice = c;
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
            zone?.Invoke(new MethodInvoker(delegate { zone.Controls.Add(new CardPanel(card, _form1.Client, this, _zonePanels.First().Value.Height, zone.ZoneType == ZoneType.BattleZone || zone.ZoneType == ZoneType.ManaZone)); }));
        }

        private ZonePanel GetZonePanel(string playerId, ZoneType zoneType)
        {
            return _zonePanels.SingleOrDefault(x => x.Value.Name == playerId && x.Key.Item1 == zoneType).Value;
        }

        internal void ClearSelectedAndSelectableCards()
        {
            foreach (var card in _selectedCards)
            {
                card.BackColor = Color.Black;
            }
            _selectedCards.Clear();
            foreach (var card in _selectableCards)
            {
                card.BackColor = Color.Black;
            }
            _selectableCards.Clear();
            _choicePanel._defaultButton.Visible = false;
            _choicePanel._declineButton.Visible = false;
        }
    }
}