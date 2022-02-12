using System.Windows.Forms;

namespace Client
{
    internal class GameSetupPanel : TableLayoutPanel
    {
        private readonly TextBox _player1Name = new() { Dock = DockStyle.Fill, ReadOnly = true };
        private readonly TextBox _player2Name = new() { Dock = DockStyle.Fill, ReadOnly = true };
        private readonly Button _startButton = new() { Dock = DockStyle.Fill, Text = "Start" };
        private readonly Client _client;

        internal GameSetupPanel(Client client)
        {
            _client = client;
            _startButton.Click += StartGame;
            SetProperties();
            SetColumnAndRowStyles();
            AddControls();
        }

        private void SetProperties()
        {
            Dock = DockStyle.Fill;
            ColumnCount = 2;
            RowCount = 2;
        }

        private void SetColumnAndRowStyles()
        {
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 50));
        }

        private void AddControls()
        {
            Controls.Add(_player1Name, 0, 0);
            Controls.Add(_player2Name, 1, 0);
            Controls.Add(_startButton, 1, 0);
        }

        internal void Setup(string userName, string opponent)
        {
            _player1Name.Text = userName;
            _player2Name.Text = opponent;
        }

        private void StartGame(object sender, System.EventArgs e)
        {
            _client.WriteAsync(new Common.StartGame());
        }
    }
}
