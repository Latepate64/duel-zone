using DuelMastersModels;
using DuelMastersModels.Factories;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace DuelMastersApplication
{
    public class SetupCanvas : Canvas
    {
        const string JsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";
        const int Player1Column = 0;
        const int MiddleColumn = 1;
        const int Player2Column = 2;

        const int NameRow = 0;
        const int DeckRow = 1;

        Grid _mainGrid = new Grid() { ShowGridLines = true };
        TextBox _textBoxPlayer1Deck = new TextBox();
        TextBox _textBoxPlayer2Deck = new TextBox();
        TextBox _textBoxPlayer1Name = new TextBox() { Text = "Player1" };
        TextBox _textBoxPlayer2Name = new TextBox() { Text = "Player2" };
        Duel _duel;

        public event EventHandler StartDuel;

        public SetupCanvas(Duel duel)
        {
            _duel = duel;
            Height = 300;
            Width = 600;
            //HorizontalAlignment = HorizontalAlignment.Center;
            //VerticalAlignment = VerticalAlignment.Center;

            Grid grid = new Grid() { ShowGridLines = true };
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

            ColumnDefinition columnDefinition = new ColumnDefinition();
            _mainGrid.ColumnDefinitions.Add(columnDefinition);
            RowDefinition rowDefinitionTop = new RowDefinition();
            RowDefinition rowDefinitionBottom = new RowDefinition();
            _mainGrid.RowDefinitions.Add(rowDefinitionTop);
            _mainGrid.RowDefinitions.Add(rowDefinitionBottom);

            Grid.SetColumn(grid, 0);
            Grid.SetRow(grid, 0);
            _mainGrid.Children.Add(grid);

            Button startDuelButton = new Button() { Content = "Start duel" };
            startDuelButton.Click += StartDuelButton_Click;
            Grid.SetColumn(grid, 0);
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
            _duel.Player1 = new Player() { Id = 0, Name = _textBoxPlayer1Name.Text };
            _duel.Player2 = new Player() { Id = 1, Name = _textBoxPlayer2Name.Text };
            _duel.Player1.SetDeckBeforeDuel(CardFactory.GetCardsFromJsonCards(JsonCardFactory.GetJsonCards(JsonPath, Deserialize(_textBoxPlayer1Deck.Text))));
            _duel.Player2.SetDeckBeforeDuel(CardFactory.GetCardsFromJsonCards(JsonCardFactory.GetJsonCards(JsonPath, Deserialize(_textBoxPlayer2Deck.Text))));
            _duel.Player1.SetupDeck();
            _duel.Player2.SetupDeck();

            Visibility = Visibility.Hidden;
            //StartDuel.Invoke(this, null);
            //StartDuel.i
        }

        private static XmlDeck Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XmlDeck));
            using (StreamReader reader = new StreamReader(path))
            {
                XmlDeck deck = (XmlDeck)serializer.Deserialize(reader);
                return deck;
            }
        }

        private void SetupCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _mainGrid.Height = e.NewSize.Height;
            _mainGrid.Width = e.NewSize.Width;
        }
    }
}
