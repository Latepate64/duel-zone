using System.Windows.Forms;

namespace Client
{
    class GameSetupPanel : TableLayoutPanel
    {
        readonly TextBox _player1Name = new() { Dock = DockStyle.Fill, ReadOnly = true };
        readonly TextBox _player2Name = new() { Dock = DockStyle.Fill, ReadOnly = true };
        readonly Button _startButton = new() { Dock = DockStyle.Fill, Text = "Start" };
        readonly Client _client;

        public GameSetupPanel(Client client)
        {
            _client = client;

            Dock = DockStyle.Fill;
            ColumnCount = 2;
            RowCount = 2;

            _startButton.Click += StartGame;

            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            Controls.Add(_player1Name, 0, 0);
            Controls.Add(_player2Name, 1, 0);
            Controls.Add(_startButton, 1, 0);
        }

        private void StartGame(object sender, System.EventArgs e)
        {
            _client.WriteAsync(new Common.StartGame());
        }

        internal void Setup(string userName, string opponent)
        {
            _player1Name.Text = userName;
            _player2Name.Text = opponent;
        }
    }
}
