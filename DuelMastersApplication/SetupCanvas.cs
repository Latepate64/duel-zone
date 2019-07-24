using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace DuelMastersApplication
{
    public class SetupCanvas : Canvas
    {
        #region Constants
        const int Player1Column = 0;
        const int MiddleColumn = 1;
        const int Player2Column = 2;

        const int NameRow = 0;
        const int DeckRow = 1;
        const int AIRow = 2;

        const string AIText = "Controlled by computer";

        const double RowHeight = 45.0;
        #endregion Constants

        #region Fields
        Grid _mainGrid = new Grid() { Background = System.Windows.Media.Brushes.LightGray };
        TextBox _textBoxPlayer1Deck = new TextBox() { HorizontalScrollBarVisibility = ScrollBarVisibility.Auto };
        TextBox _textBoxPlayer2Deck = new TextBox() { HorizontalScrollBarVisibility = ScrollBarVisibility.Auto };
        TextBox _textBoxPlayer1Name = new TextBox();
        TextBox _textBoxPlayer2Name = new TextBox();
        MainWindow _mainWindow;
        
        CheckBox _checkBoxPlayer1AI = new CheckBox() { Content = AIText };
        CheckBox _checkBoxPlayer2AI = new CheckBox() { Content = AIText };
        ComboBox _comboBoxStarter = new ComboBox();
        Configuration _configuration;
        #endregion Fields

        public SetupCanvas(MainWindow mainWindow, Configuration configuration)
        {
            _mainWindow = mainWindow;
            _configuration = configuration;

            Height = 250;
            Width = 600;
            Grid playerGrid = SetupPlayerGrid();

            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(RowHeight, GridUnitType.Pixel) });
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(RowHeight, GridUnitType.Pixel) });

            Grid.SetColumn(playerGrid, 0);
            Grid.SetRow(playerGrid, 0);
            _mainGrid.Children.Add(playerGrid);

            Label labelStarter = new Label() { Content = "Who goes first" };

            _comboBoxStarter.Items.Add(new ComboBoxItem() { Content = "Player 1" });
            _comboBoxStarter.Items.Add(new ComboBoxItem() { Content = "Player 2" });
            _comboBoxStarter.Items.Add(new ComboBoxItem() { Content = "Random" });
            _comboBoxStarter.SelectedIndex = 0;

            Grid gridStarter = new Grid();
            gridStarter.ColumnDefinitions.Add(new ColumnDefinition());
            gridStarter.ColumnDefinitions.Add(new ColumnDefinition());
            gridStarter.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(labelStarter, 0);
            Grid.SetRow(labelStarter, 0);
            gridStarter.Children.Add(labelStarter);

            Grid.SetColumn(_comboBoxStarter, 1);
            Grid.SetRow(_comboBoxStarter, 0);
            gridStarter.Children.Add(_comboBoxStarter);

            Grid.SetColumn(gridStarter, 0);
            Grid.SetRow(gridStarter, 1);
            _mainGrid.Children.Add(gridStarter);

            Button startDuelButton = new Button() { Content = "Start duel" };
            startDuelButton.Click += StartDuelButton_Click;
            Grid.SetColumn(startDuelButton, 0);
            Grid.SetRow(startDuelButton, 2);
            _mainGrid.Children.Add(startDuelButton);

            SizeChanged += SetupCanvas_SizeChanged;

            Children.Add(_mainGrid);

            _textBoxPlayer1Name.Text = configuration.Player1Configuration.Name;
            _textBoxPlayer1Deck.Text = configuration.Player1Configuration.DeckPath;
            _checkBoxPlayer1AI.IsChecked = configuration.Player1Configuration.ControlledByComputer;
            _textBoxPlayer2Name.Text = configuration.Player2Configuration.Name;
            _textBoxPlayer2Deck.Text = configuration.Player2Configuration.DeckPath;
            _checkBoxPlayer2AI.IsChecked = configuration.Player2Configuration.ControlledByComputer;
            _comboBoxStarter.SelectedIndex = configuration.WhoGoesFirst;
        }

        private Grid SetupPlayerGrid()
        {
            Grid playerGrid = new Grid() { Background = System.Windows.Media.Brushes.LightGray };
            playerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            playerGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(60) });
            playerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            playerGrid.RowDefinitions.Add(new RowDefinition());
            playerGrid.RowDefinitions.Add(new RowDefinition());
            playerGrid.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(_textBoxPlayer1Name, Player1Column);
            Grid.SetRow(_textBoxPlayer1Name, NameRow);
            playerGrid.Children.Add(_textBoxPlayer1Name);

            Grid.SetColumn(_textBoxPlayer2Name, Player2Column);
            Grid.SetRow(_textBoxPlayer2Name, NameRow);
            playerGrid.Children.Add(_textBoxPlayer2Name);

            Label labelPlayerName = new Label() { Content = "Name", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            Grid.SetColumn(labelPlayerName, MiddleColumn);
            Grid.SetRow(labelPlayerName, NameRow);
            playerGrid.Children.Add(labelPlayerName);

            GridLength gridLengthBrowseDeck = new GridLength(RowHeight);

            #region Player1Deck
            Grid gridPlayer1Deck = new Grid();
            gridPlayer1Deck.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayer1Deck.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLengthBrowseDeck });
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
            playerGrid.Children.Add(gridPlayer1Deck);
            #endregion Player1Deck

            #region Player2Deck
            Grid gridPlayer2Deck = new Grid();
            gridPlayer2Deck.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayer2Deck.ColumnDefinitions.Add(new ColumnDefinition() { Width = gridLengthBrowseDeck });
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
            playerGrid.Children.Add(gridPlayer2Deck);
            #endregion Player2Deck

            Label labelPlayerDeck = new Label() { Content = "Deck", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            Grid.SetColumn(labelPlayerDeck, MiddleColumn);
            Grid.SetRow(labelPlayerDeck, DeckRow);
            playerGrid.Children.Add(labelPlayerDeck);

            Label labelAI = new Label() { Content = "Control", HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
            Grid.SetColumn(labelAI, MiddleColumn);
            Grid.SetRow(labelAI, AIRow);
            playerGrid.Children.Add(labelAI);

            Grid.SetColumn(_checkBoxPlayer1AI, Player1Column);
            Grid.SetRow(_checkBoxPlayer1AI, AIRow);
            playerGrid.Children.Add(_checkBoxPlayer1AI);

            Grid.SetColumn(_checkBoxPlayer2AI, Player2Column);
            Grid.SetRow(_checkBoxPlayer2AI, AIRow);
            playerGrid.Children.Add(_checkBoxPlayer2AI);

            return playerGrid;
        }

        #region Events
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

        private void StartDuelButton_Click(object sender, RoutedEventArgs e)
        {
            Configuration configuration = new Configuration()
            {
                Player1Configuration = new PlayerConfiguration()
                {
                    ControlledByComputer = _checkBoxPlayer1AI.IsChecked.Value,
                    DeckPath = _textBoxPlayer1Deck.Text,
                    Name = _textBoxPlayer1Name.Text,
                },
                Player2Configuration = new PlayerConfiguration()
                {
                    ControlledByComputer = _checkBoxPlayer2AI.IsChecked.Value,
                    DeckPath = _textBoxPlayer2Deck.Text,
                    Name = _textBoxPlayer2Name.Text,
                },
                WhoGoesFirst = _comboBoxStarter.SelectedIndex,
                FetchJsonOnline = _configuration.FetchJsonOnline,
                JsonUrlOrPath = _configuration.JsonUrlOrPath,
            };
            _mainWindow.InitializeDuel(configuration);
            Visibility = Visibility.Hidden;
        }

        private void SetupCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _mainGrid.Height = e.NewSize.Height;
            _mainGrid.Width = e.NewSize.Width;
        }
        #endregion Events
    }
}
