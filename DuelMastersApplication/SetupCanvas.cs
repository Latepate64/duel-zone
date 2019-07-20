using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace DuelMastersApplication
{
    public class SetupCanvas : Canvas
    {
        const int Player1Column = 0;
        const int MiddleColumn = 1;
        const int Player2Column = 2;

        const int NameRow = 0;
        const int DeckRow = 1;

        Grid _mainGrid = new Grid();
        TextBox _textBoxPlayer1Deck = new TextBox() { Text = "C:/DuelMastersArenaUnity/Decks/LWN Tempo.xml" };
        TextBox _textBoxPlayer2Deck = new TextBox() { Text = "C:/DuelMastersArenaUnity/Decks/LWN Tempo.xml" };
        TextBox _textBoxPlayer1Name = new TextBox() { Text = "Player1" };
        TextBox _textBoxPlayer2Name = new TextBox() { Text = "Player2" };
        MainWindow _mainWindow;

        public SetupCanvas(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;

            Height = 300;
            Width = 600;

            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(_textBoxPlayer1Name, Player1Column);
            Grid.SetRow(_textBoxPlayer1Name, NameRow);
            grid.Children.Add(_textBoxPlayer1Name);

            Grid.SetColumn(_textBoxPlayer2Name, Player2Column);
            Grid.SetRow(_textBoxPlayer2Name, NameRow);
            grid.Children.Add(_textBoxPlayer2Name);

            Label labelPlayerName = new Label() { Content = "Name", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            Grid.SetColumn(labelPlayerName, MiddleColumn);
            Grid.SetRow(labelPlayerName, NameRow);
            grid.Children.Add(labelPlayerName);

            #region Player1Deck
            Grid gridPlayer1Deck = new Grid();
            gridPlayer1Deck.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayer1Deck.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayer1Deck.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(_textBoxPlayer1Deck, 0);
            Grid.SetRow(_textBoxPlayer1Deck, 0);
            gridPlayer1Deck.Children.Add(_textBoxPlayer1Deck);

            Button buttonPlayer1Deck = new Button() { Content = "Browse" };
            buttonPlayer1Deck.Click += ButtonPlayer1Deck_Click;
            Grid.SetColumn(buttonPlayer1Deck, 1);
            Grid.SetRow(buttonPlayer1Deck, 0);
            gridPlayer1Deck.Children.Add(buttonPlayer1Deck);

            Grid.SetColumn(gridPlayer1Deck, Player1Column);
            Grid.SetRow(gridPlayer1Deck, DeckRow);
            grid.Children.Add(gridPlayer1Deck);
            #endregion Player1Deck

            #region Player2Deck
            Grid gridPlayer2Deck = new Grid();
            gridPlayer2Deck.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayer2Deck.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayer2Deck.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(_textBoxPlayer2Deck, 0);
            Grid.SetRow(_textBoxPlayer2Deck, 0);
            gridPlayer2Deck.Children.Add(_textBoxPlayer2Deck);

            Button buttonPlayer2Deck = new Button() { Content = "Browse" };
            buttonPlayer2Deck.Click += ButtonPlayer2Deck_Click;
            Grid.SetColumn(buttonPlayer2Deck, 1);
            Grid.SetRow(buttonPlayer2Deck, 0);
            gridPlayer2Deck.Children.Add(buttonPlayer2Deck);

            Grid.SetColumn(gridPlayer2Deck, Player2Column);
            Grid.SetRow(gridPlayer2Deck, DeckRow);
            grid.Children.Add(gridPlayer2Deck);
            #endregion Player2Deck

            Label labelPlayerDeck = new Label() { Content = "Deck", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            Grid.SetColumn(labelPlayerDeck, MiddleColumn);
            Grid.SetRow(labelPlayerDeck, DeckRow);
            grid.Children.Add(labelPlayerDeck);

            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(grid, 0);
            Grid.SetRow(grid, 0);
            _mainGrid.Children.Add(grid);

            Button startDuelButton = new Button() { Content = "Start duel" };
            startDuelButton.Click += StartDuelButton_Click;
            Grid.SetColumn(startDuelButton, 0);
            Grid.SetRow(startDuelButton, 1);
            _mainGrid.Children.Add(startDuelButton);

            SizeChanged += SetupCanvas_SizeChanged;

            Children.Add(_mainGrid);
        }

        private void ButtonPlayer1Deck_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "XML Files (*.xml)|*.xml" };
            if (openFileDialog.ShowDialog() == true)
            {
                _textBoxPlayer1Deck.Text = openFileDialog.FileName;
            }
        }

        private void ButtonPlayer2Deck_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "XML Files (*.xml)|*.xml" };
            if (openFileDialog.ShowDialog() == true)
            {
                _textBoxPlayer2Deck.Text = openFileDialog.FileName;
            }
        }

        /*protected virtual void OnStartDuel(EventArgs e)
        {
            EventHandler handler = StartDuel;
            handler?.Invoke(this, e);
        }*/

        private void StartDuelButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.InitializeDuel(_textBoxPlayer1Name.Text, _textBoxPlayer2Name.Text, _textBoxPlayer1Deck.Text, _textBoxPlayer2Deck.Text);
            Visibility = Visibility.Hidden;
            //StartDuel.Invoke(this, null);
            //StartDuel.i
        }

        private void SetupCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _mainGrid.Height = e.NewSize.Height;
            _mainGrid.Width = e.NewSize.Width;
        }
    }
}
