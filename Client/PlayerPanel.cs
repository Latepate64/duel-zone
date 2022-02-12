using Common;
using Common.Choices;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    internal class PlayerPanel : TableLayoutPanel
    {
        internal IEnumerable<KeyValuePair<ZoneType, Button>> ZoneButtons => _zoneButtons;

        private readonly Dictionary<ZoneType, Button> _zoneButtons = new();
        private readonly Button _player = new() { Dock = DockStyle.Fill, Text = "Player" };
        private readonly TablePage _tablePage;
        private readonly Client _client;

        internal PlayerPanel(string name, TablePage tablePage, Client client)
        {
            _tablePage = tablePage;
            _client = client;
            _player.Enabled = false;
            _player.Click += PlayerClick;
            SetupProperties();
            SetColumnAndRowStyles();
            SetupZoneButtons();
            AddControls(name);
        }

        private void SetupProperties()
        {
            Width = 250;
            Height = 275;
            ColumnCount = 2;
            RowCount = 4;
        }

        private void SetupZoneButtons()
        {
            foreach (var zoneType in new[] { ZoneType.BattleZone, ZoneType.Deck, ZoneType.Graveyard, ZoneType.Hand, ZoneType.ManaZone, ZoneType.ShieldZone })
            {
                _zoneButtons.Add(zoneType, new Button { Dock = DockStyle.Fill, Text = zoneType.ToString() });
            }
        }

        private void SetColumnAndRowStyles()
        {
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            RowStyles.Add(new RowStyle(SizeType.Percent, 25));
        }

        private void AddControls(string name)
        {
            Controls.Add(new Label { Dock = DockStyle.Fill, Text = name }, 0, 0);
            Controls.Add(_player, 1, 0);
            AddZoneButtons();
        }

        private void AddZoneButtons()
        {
            Controls.Add(_zoneButtons[ZoneType.BattleZone], 0, 1);
            Controls.Add(_zoneButtons[ZoneType.Graveyard], 1, 1);
            Controls.Add(_zoneButtons[ZoneType.ManaZone], 0, 2);
            Controls.Add(_zoneButtons[ZoneType.ShieldZone], 1, 2);
            Controls.Add(_zoneButtons[ZoneType.Hand], 0, 3);
            Controls.Add(_zoneButtons[ZoneType.Deck], 1, 3);
        }

        private void PlayerClick(object sender, System.EventArgs e)
        {
            if (_tablePage._currentChoice is AttackTargetSelection)
            {
                var decision = new GuidDecision { Decision = new System.Collections.Generic.List<System.Guid> { new System.Guid(Name) } };
                Enabled = false;
                _tablePage.ClearSelectedAndSelectableCards();
                _client.WriteAsync(decision);
            }
        }
    }
}
