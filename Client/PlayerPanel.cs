using System.Windows.Forms;

namespace Client
{
    class PlayerPanel : TableLayoutPanel
    {
        internal readonly Button _manaZone = new() { Dock = DockStyle.Fill, Text = "Mana zone" };
        internal readonly Button _hand = new() { Dock = DockStyle.Fill, Text = "Hand" };
        internal readonly Button _graveyard = new() { Dock = DockStyle.Fill, Text = "Graveyard" };
        internal readonly Button _shieldZone = new() { Dock = DockStyle.Fill, Text = "Shield zone" };
        internal readonly Button _battleZone = new() { Dock = DockStyle.Fill, Text = "Battle zone" };
        internal readonly Button _deck = new() { Dock = DockStyle.Fill, Text = "Deck" };

        public PlayerPanel(string name, int top)
        {
            Width = 250;
            Height = (int)(1.1 * Width);

            Top = top;

            ColumnCount = 2;
            RowCount = 4;

            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            RowStyles.Add(new RowStyle(SizeType.Percent, 25));

            Controls.Add(new Label { Dock = DockStyle.Fill, Text = name }, 0, 0);
            //Controls.Add(, 1, 0);
            Controls.Add(_battleZone, 0, 1);
            Controls.Add(_graveyard, 1, 1);
            Controls.Add(_manaZone, 0, 2);
            Controls.Add(_shieldZone, 1, 2);
            Controls.Add(_hand, 0, 3);
            Controls.Add(_deck, 1, 3);
        }
    }
}
