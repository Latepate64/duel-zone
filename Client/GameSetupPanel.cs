using System.Windows.Forms;

namespace Client
{
    class GameSetupPanel : TableLayoutPanel
    {
        readonly TextBox _gameSetupTablePlayer1Name = new() { Dock = DockStyle.Fill, ReadOnly = true };
        readonly TextBox _gameSetupTablePlayer2Name = new() { Dock = DockStyle.Fill, ReadOnly = true };

        public GameSetupPanel()
        {
            Dock = DockStyle.Fill;
            ColumnCount = 2;
            RowCount = 3;

            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Controls.Add(_gameSetupTablePlayer1Name, 0, 0);
            Controls.Add(_gameSetupTablePlayer2Name, 1, 0);
        }

        internal void Setup(string userName, string v)
        {
            _gameSetupTablePlayer1Name.Text = userName;
            _gameSetupTablePlayer2Name.Text = v;
        }
    }
}
