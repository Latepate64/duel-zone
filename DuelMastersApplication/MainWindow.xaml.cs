using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using DuelMastersModels.PlayerActionResponses;
using DuelMastersModels.Steps;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;

namespace DuelMastersApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int SideColumnWidth = 200;
        const string JsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";

        #region Fields
        Duel _duel = new Duel();
        Grid _mainGrid = new Grid();
        Grid _centerGrid = new Grid();
        Canvas _setupCanvas;
        Canvas _mainCanvas = new Canvas();
        ListView _listViewPlayer1Hand = new ListView() { Background = Brushes.Aqua, Name = "ListViewPriorityHand" };
        ListView _listViewPlayer1ManaZone = new ListView() { Background = Brushes.LawnGreen, Name = "ListViewPriorityManaZone" };
        ListView _listViewPlayer1BattleZone = new ListView() { Background = Brushes.PaleVioletRed, Name = "ListViewPriorityBattleZone" };
        ListView _listViewPlayer2BattleZone = new ListView() { Background = Brushes.PaleVioletRed, Name = "ListViewNonPriorityBattleZone" };
        ListView _listViewPlayer2ManaZone = new ListView() { Background = Brushes.LawnGreen, Name = "ListViewNonPriorityManaZone" };
        ListView _listViewPlayer2Hand = new ListView() { Background = Brushes.Aqua, Name = "ListViewPriorityHand" };

        TextBox _textBoxPriorityName = new TextBox() { HorizontalAlignment = HorizontalAlignment.Center, IsReadOnly = true, VerticalAlignment = VerticalAlignment.Center };
        TextBox _textBoxNonPriorityName = new TextBox() { HorizontalAlignment = HorizontalAlignment.Center, IsReadOnly = true, VerticalAlignment = VerticalAlignment.Center };
        Button _actionButton = new Button() { Content = "Action button" };
        TextBox _actionTextBox = new TextBox() { IsReadOnly = true, TextWrapping = TextWrapping.Wrap };
        TextBox _textBoxLog = new TextBox() { IsReadOnly = true, TextWrapping = TextWrapping.Wrap };

        ObservableCollection<string> LogMessages { get; } = new ObservableCollection<string>();
        #endregion Fields

        public MainWindow()
        {
            _duel.Turns.CollectionChanged += Turns_CollectionChanged;
            LogMessages.CollectionChanged += LogMessages_CollectionChanged;

            _setupCanvas = new SetupCanvas(this);
            InitializeComponent();
            Title = "Duel Masters Application";
            WindowState = WindowState.Maximized;
            
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(SideColumnWidth) });
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(SideColumnWidth) });
            _mainGrid.RowDefinitions.Add(new RowDefinition());

            _centerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 5; ++i)
            {
                _centerGrid.RowDefinitions.Add(new RowDefinition());
            }
            Grid.SetColumn(_centerGrid, 1);
            _mainGrid.Children.Add(_centerGrid);

            Grid.SetColumn(_textBoxLog, 0);
            _mainGrid.Children.Add(_textBoxLog);

            Grid rightGrid = new Grid() { ShowGridLines = true };
            rightGrid.ColumnDefinitions.Add(new ColumnDefinition());
            rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            Grid.SetColumn(_textBoxNonPriorityName, 0);
            Grid.SetRow(_textBoxNonPriorityName, 0);
            rightGrid.Children.Add(_textBoxNonPriorityName);

            Grid.SetColumn(_actionTextBox, 0);
            Grid.SetRow(_actionTextBox, 2);
            rightGrid.Children.Add(_actionTextBox);

            Grid.SetColumn(_actionButton, 0);
            Grid.SetRow(_actionButton, 3);
            rightGrid.Children.Add(_actionButton);

            Grid.SetColumn(_textBoxPriorityName, 0);
            Grid.SetRow(_textBoxPriorityName, 5);
            rightGrid.Children.Add(_textBoxPriorityName);

            Grid.SetColumn(rightGrid, 2);
            _mainGrid.Children.Add(rightGrid);

            _mainCanvas.Children.Add(_mainGrid);
            _mainCanvas.Children.Add(_setupCanvas);

            Content = _mainCanvas;

            _mainCanvas.SizeChanged += MainCanvas_SizeChanged;
            _actionButton.Click += _actionButton_Click;
        }

        #region Public methods
        public void InitializeDuel(string player1Name, string player2Name, string player1DeckPath, string player2DeckPath)
        {
            _duel.Player1 = new Player() { Id = 0, Name = player1Name };
            _duel.Player2 = new Player() { Id = 1, Name = player2Name };
            int gameId = 0;
            _duel.Player1.SetDeckBeforeDuel(CardFactory.GetCardsFromJsonCards(JsonCardFactory.GetJsonCards(JsonPath, Deserialize(player1DeckPath)), ref gameId));
            _duel.Player2.SetDeckBeforeDuel(CardFactory.GetCardsFromJsonCards(JsonCardFactory.GetJsonCards(JsonPath, Deserialize(player2DeckPath)), ref gameId));
            _duel.Player1.SetupDeck();
            _duel.Player2.SetupDeck();
            PlayerAction playerAction = _duel.StartDuel();

            _textBoxNonPriorityName.SetBinding(TextBox.TextProperty, new Binding("PlayerWithoutPriority.Name") { Source = _duel });
            _textBoxPriorityName.SetBinding(TextBox.TextProperty, new Binding("PlayerWithPriority.Name") { Source = _duel });

            _listViewPlayer2BattleZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player2.BattleZone.Cards") { Source = _duel });
            _listViewPlayer2Hand.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player2.Hand.Cards") { Source = _duel });
            _listViewPlayer2ManaZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player2.ManaZone.Cards") { Source = _duel });
            _listViewPlayer1BattleZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player1.BattleZone.Cards") { Source = _duel });
            _listViewPlayer1Hand.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player1.Hand.Cards") { Source = _duel });
            _listViewPlayer1ManaZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player1.ManaZone.Cards") { Source = _duel });
            
            TestHandBinding(_listViewPlayer2BattleZone);
            TestHandBinding(_listViewPlayer2Hand);
            TestHandBinding(_listViewPlayer2ManaZone);
            TestHandBinding(_listViewPlayer1BattleZone);
            TestHandBinding(_listViewPlayer1Hand);
            TestHandBinding(_listViewPlayer1ManaZone);
            UpdateViewToShowPlayerAction(playerAction);
        }
        #endregion Public methods

        #region Private methods
        private void UpdateViewToShowPlayerAction(PlayerAction playerAction)
        {
            _centerGrid.Children.Clear();

            //TODO: if playerAction is null, check if duel has ended

            if (playerAction.Player == _duel.Player1)
            {
                Grid.SetColumn(_listViewPlayer1Hand, 0);
                Grid.SetRow(_listViewPlayer1Hand, 4);
                _centerGrid.Children.Add(_listViewPlayer1Hand);

                Grid.SetColumn(_listViewPlayer1ManaZone, 0);
                Grid.SetRow(_listViewPlayer1ManaZone, 3);
                _centerGrid.Children.Add(_listViewPlayer1ManaZone);

                Grid.SetColumn(_listViewPlayer1BattleZone, 0);
                Grid.SetRow(_listViewPlayer1BattleZone, 2);
                _centerGrid.Children.Add(_listViewPlayer1BattleZone);

                Grid.SetColumn(_listViewPlayer2BattleZone, 0);
                Grid.SetRow(_listViewPlayer2BattleZone, 1);
                _centerGrid.Children.Add(_listViewPlayer2BattleZone);

                Grid.SetColumn(_listViewPlayer2ManaZone, 0);
                Grid.SetRow(_listViewPlayer2ManaZone, 0);
                _centerGrid.Children.Add(_listViewPlayer2ManaZone);
            }
            else
            {
                Grid.SetColumn(_listViewPlayer1ManaZone, 0);
                Grid.SetRow(_listViewPlayer1ManaZone, 0);
                _centerGrid.Children.Add(_listViewPlayer1ManaZone);

                Grid.SetColumn(_listViewPlayer1BattleZone, 0);
                Grid.SetRow(_listViewPlayer1BattleZone, 1);
                _centerGrid.Children.Add(_listViewPlayer1BattleZone);

                Grid.SetColumn(_listViewPlayer2BattleZone, 0);
                Grid.SetRow(_listViewPlayer2BattleZone, 2);
                _centerGrid.Children.Add(_listViewPlayer2BattleZone);

                Grid.SetColumn(_listViewPlayer2ManaZone, 0);
                Grid.SetRow(_listViewPlayer2ManaZone, 3);
                _centerGrid.Children.Add(_listViewPlayer2ManaZone);

                Grid.SetColumn(_listViewPlayer2Hand, 0);
                Grid.SetRow(_listViewPlayer2Hand, 4);
                _centerGrid.Children.Add(_listViewPlayer2Hand);
            }

            _textBoxPriorityName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            _textBoxNonPriorityName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();

            if (playerAction is CardSelection cardSelection)
            {
                if (cardSelection is ChargeMana chargeMana)
                {
                    _actionTextBox.Text = "You may charge mana.";
                    _actionButton.Content = "Skip";
                }
                else if (cardSelection is UseCard useCard)
                {
                    _actionTextBox.Text = "You may use a card.";
                    _actionButton.Content = "Skip";
                }
                else if (cardSelection is PayCost payCost)
                {
                    _actionTextBox.Text = string.Format("Pay the mana cost for {0}.", (_duel.CurrentTurn.CurrentStep as MainStep).CardToBeUsed.Name);
                    _actionButton.Content = "Confirm";
                }
                else
                {
                    throw new ArgumentException("Unknown card selection.");
                }
            }
            else if (playerAction is DeclareAttacker)
            {
                _actionTextBox.Text = "You may declare a creature to attack with.";
                _actionButton.Content = "Do not attack";
            }
            else if (playerAction is DeclareTargetOfAttack)
            {
                _actionTextBox.Text = "Declare the target of the attack.";
                _actionButton.Content = "Attack opponent";
            }
            else
            {
                throw new ArgumentException("Unknown player action.");
            }
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

        private FrameworkElementFactory GetStackPanelFactory()
        {
            FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            return stackPanelFactory;
        }

        private void TestHandBinding(ListView listView)
        {
            listView.ItemsPanel = new ItemsPanelTemplate() { VisualTree = GetStackPanelFactory() };
            FrameworkElementFactory cardCanvasFactory = new FrameworkElementFactory(typeof(CardCanvas));

            cardCanvasFactory.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = listView });
            cardCanvasFactory.SetBinding(WidthProperty, new Binding("ActualHeight") { Source = listView });

            cardCanvasFactory.SetBinding(CardCanvas.CardNameProperty, new Binding("Name"));
            cardCanvasFactory.SetBinding(CardCanvas.CivilizationProperty, new Binding("Civilizations"));
            cardCanvasFactory.SetBinding(CardCanvas.CardTextProperty, new Binding("Text"));
            cardCanvasFactory.SetBinding(CardCanvas.CostProperty, new Binding("Cost"));
            cardCanvasFactory.SetBinding(CardCanvas.PowerProperty, new Binding("Power"));
            cardCanvasFactory.SetBinding(CardCanvas.RaceProperty, new Binding("Races"));
            cardCanvasFactory.SetBinding(CardCanvas.GameIdProperty, new Binding("GameId"));
            cardCanvasFactory.SetBinding(CardCanvas.TappedProperty, new Binding("Tapped"));
            cardCanvasFactory.SetBinding(CardCanvas.CardTypeProperty, new Binding() { Converter = new ObjectToCardTypeConverter() });
            MultiBinding multiBinding = new MultiBinding() { Converter = new SetAndIdConverter() };
            multiBinding.Bindings.Add(new Binding("Set"));
            multiBinding.Bindings.Add(new Binding("Id"));
            cardCanvasFactory.SetBinding(CardCanvas.SetAndIdProperty, multiBinding);

            cardCanvasFactory.SetBinding(CardCanvas.GameIdsProperty, new Binding("CurrentPlayerAction") { Converter = new PlayerActionToIntCollectionConverter(), Source = _duel });

            //cardCanvasFactory.SetBinding(CardCanvas.GameIdsProperty, new Binding("CurrentPlayerAction.CardIds") { Source = _duel });

            //_listViewPlayer1BattleZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player1.BattleZone.Cards") { Source = _duel });

            //cardCanvasFactory.SetBinding(CardCanvas.GameIdsProperty, _gameIdsBinding);

            cardCanvasFactory.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(CardCanvas_MouseLeftButtonDown));
            listView.ItemTemplate = new DataTemplate() { VisualTree = cardCanvasFactory };
        }

        private void LogPlayerAction(PlayerAction playerAction)
        {
            if (playerAction is DrawCard drawCard)
            {
                LogMessages.Add(string.Format("{0} drew a card.", drawCard.Player.Name));
            }
            else if (playerAction is ChargeMana chargeMana)
            {
                if (chargeMana.SelectedCard == null)
                {
                    LogMessages.Add(string.Format("{0} did not charge mana.", chargeMana.Player.Name));
                }
                else
                {
                    LogMessages.Add(string.Format("{0} charged {1} as mana.", chargeMana.Player.Name, chargeMana.SelectedCard.Name));
                }
            }
            else if (playerAction is UseCard useCard)
            {
                if (useCard.SelectedCard != null)
                {
                    LogMessages.Add(string.Format("{0} used {1}.", useCard.Player.Name, useCard.SelectedCard.Name));
                }
            }
            else if (playerAction is PayCost payCost)
            {
                //no need to log
            }
            else if (playerAction is DeclareAttacker declareAttacker)
            {
                if (declareAttacker.SelectedCreature != null)
                {
                    LogMessages.Add(string.Format("{0} declared {1} as an attacking creature.", declareAttacker.Player.Name, declareAttacker.SelectedCreature.Name));
                }
            }
            else if (playerAction is DeclareTargetOfAttack declareTargetOfAttack)
            {
                if (declareTargetOfAttack.SelectedCreature != null)
                {
                    LogMessages.Add(string.Format("{0} declared {1} as the target of attack.", declareTargetOfAttack.Player.Name, declareTargetOfAttack.SelectedCreature.Name));
                }
                else
                {
                    LogMessages.Add(string.Format("{0} declared {1} as the target of attack.", declareTargetOfAttack.Player.Name, _duel.GetOpponent(declareTargetOfAttack.Player).Name));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Unknown player action.");
            }
        }
        #endregion Private methods

        #region Events
        private void MainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _mainGrid.Height = e.NewSize.Height;
            _mainGrid.Width = e.NewSize.Width;

            Canvas.SetLeft(_setupCanvas, (e.NewSize.Width - _setupCanvas.Width) / 2);
            Canvas.SetTop(_setupCanvas, (e.NewSize.Height - _setupCanvas.Height) / 2);


        }

        private void PlayerActions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var newItem in e.NewItems)
                {
                    PlayerAction playerAction = newItem as PlayerAction;
                    LogPlayerAction(playerAction);
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void LogMessages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in e.NewItems)
            {
                string text = item as string;
                if (!string.IsNullOrEmpty(_textBoxLog.Text))
                {
                    _textBoxLog.Text += "\r\n";
                    if (text.Contains("started turn"))
                    {
                        _textBoxLog.Text += "\r\n";
                    }
                    //_textBoxLog.Text = string.Join("\r\n", _textBoxLog.Text, item as string);
                }
                _textBoxLog.Text += text;
            }
        }

        private void Turns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in e.NewItems)
            {
                var turn = item as Turn;
                turn.Steps.CollectionChanged += Steps_CollectionChanged;
                LogMessages.Add(string.Format("{0} started turn {1}.", turn.ActivePlayer.Name, turn.Number));
            }
        }

        private void Steps_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in e.NewItems)
            {
                var step = item as DuelMastersModels.Steps.Step;
                step.PlayerActions.CollectionChanged += PlayerActions_CollectionChanged1;
            }
        }

        private void PlayerActions_CollectionChanged1(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            foreach (var item in e.NewItems)
            {
                var playerAction = item as PlayerAction;
                LogPlayerAction(playerAction);
            }
        }

        private void CardCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cardCanvas = sender as CardCanvas;
            //TODO: consider other types of card selections
            if (_duel.CurrentPlayerAction is CardSelection cardSelection)
            {
                if (cardSelection.CardIds.Contains(cardCanvas.GameId))
                {
                    var cards = cardSelection.Cards.Where(c => c.GameId == cardCanvas.GameId);
                    var response = new CardSelectionResponse(new Collection<Card>(cards.ToList()));
                    UpdateViewToShowPlayerAction(_duel.Progress(response));
                }
            }
            else if (_duel.CurrentPlayerAction is CreatureSelection creatureSelection)
            {
                if (creatureSelection.CreatureIds.Contains(cardCanvas.GameId))
                {
                    var creatures = creatureSelection.Creatures.Where(c => c.GameId == cardCanvas.GameId);
                    var response = new CreatureSelectionResponse(new Collection<Creature>(creatures.ToList()));
                    UpdateViewToShowPlayerAction(_duel.Progress(response));
                }
            }
            else
            {
                throw new ArgumentException("Unknown card selection.");
            }
        }

        private void _actionButton_Click(object sender, RoutedEventArgs e)
        {
            if (_duel.CurrentPlayerAction is OptionalCardSelection)
            {
                UpdateViewToShowPlayerAction(_duel.Progress(new CardSelectionResponse()));
            }
            else if (_duel.CurrentPlayerAction is OptionalCreatureSelection)
            {
                UpdateViewToShowPlayerAction(_duel.Progress(new CreatureSelectionResponse()));
            }
            else
            {
                throw new ArgumentOutOfRangeException("Player action");
            }
        }
        #endregion Events
    }


    public class SetAndIdConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length == 2)
            {
                string wholeId = values[1].ToString();
                string id = wholeId.Split('/')[0];
                return new SetAndId() { Set = values[0].ToString(), Id = id };
            }
            else
            {
                throw new Exception("Expected 2 values.");
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(object), typeof(string))]
    public class ObjectToCardTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var type = value.GetType();
            if (type == typeof(EvolutionCreature))
            {
                return "Evolution Creature";
            }
            else if (type == typeof(Creature))
            {
                return "Creature";
            }
            else if (type == typeof(Spell))
            {
                return "Spell";
            }
            else if (type == typeof(CrossGear))
            {
                return "Cross Gear";
            }
            else
            {
                throw new Exception("Unknown card type.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }

    [ValueConversion(typeof(Collection<string>), typeof(string))]
    public class ListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Join("\r\n", ((Collection<string>)value).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(PlayerAction), typeof(Collection<int>))]
    public class PlayerActionToIntCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is CardSelection cardSelection)
            {
                return cardSelection.CardIds;
            }
            else if (value is CreatureSelection creatureSelection)
            {
                return creatureSelection.CreatureIds;
            }
            else
            {
                return new Collection<int>();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
