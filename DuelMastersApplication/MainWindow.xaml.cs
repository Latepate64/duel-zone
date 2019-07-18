using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.AutomaticActions;
using DuelMastersModels.PlayerActions.CardSelections;
using DuelMastersModels.PlayerActions.CreatureSelections;
using DuelMastersModels.PlayerActions.OptionalActions;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace DuelMastersApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, System.ComponentModel.INotifyPropertyChanged
    {
        const int SideColumnWidth = 200;
        const string JsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";

        #region Fields
        Duel _duel = new Duel();
        Grid _mainGrid = new Grid();
        Grid _centerGrid = new Grid();
        Grid _rightGrid = new Grid();

        Grid _actionButtonGrid = new Grid();

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
        Button _declineButton = new Button() { Content = "Decline" };
        TextBox _actionTextBox = new TextBox() { IsReadOnly = true, TextWrapping = TextWrapping.Wrap, /*TextAlignment = TextAlignment.Center,*/ HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        TextBox _textBoxLog = new TextBox() { IsReadOnly = true, TextWrapping = TextWrapping.Wrap, VerticalScrollBarVisibility = ScrollBarVisibility.Auto };

        ObservableCollection<string> LogMessages { get; } = new ObservableCollection<string>();

        Button _buttonPlayer1Shields = new Button();
        Button _buttonPlayer1Hand = new Button();
        Button _buttonPlayer1Graveyard = new Button() { Content = new Image() { Source = new BitmapImage(new Uri("Images/graveyard.png", UriKind.Relative)), Stretch = Stretch.Fill } };
        Button _buttonPlayer2Shields = new Button();
        Button _buttonPlayer2Hand = new Button();
        Button _buttonPlayer2Graveyard = new Button() { Content = new Image() { Source = new BitmapImage(new Uri("Images/graveyard.png", UriKind.Relative)), Stretch = Stretch.Fill } };

        TextBlock _textBlockPlayer1Shields = new TextBlock() { FontSize = 70, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        TextBlock _textBlockPlayer2Shields = new TextBlock() { FontSize = 70, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        TextBlock _textBlockPlayer1Hand = new TextBlock() { FontSize = 70, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        TextBlock _textBlockPlayer2Hand = new TextBlock() { FontSize = 70, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        TextBlock _textBlockPlayer1Graveyard = new TextBlock() { FontSize = 70, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        TextBlock _textBlockPlayer2Graveyard = new TextBlock() { FontSize = 70, HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };

        Grid _gridPlayer1DeckAndGraveyard = new Grid();
        Grid _gridPlayer1ShieldsAndHand = new Grid();
        Grid _gridPlayer2DeckAndGraveyard = new Grid();
        Grid _gridPlayer2ShieldsAndHand = new Grid();

        Image _player1DeckImage = new Image() { Source = new BitmapImage(new Uri("Images/card_back.jpg", UriKind.Relative)), Stretch = Stretch.Fill };
        Image _player2DeckImage = new Image() { Source = new BitmapImage(new Uri("Images/card_back.jpg", UriKind.Relative)), Stretch = Stretch.Fill };
        TextBlock _textBlockPlayer1Deck = new TextBlock();
        TextBlock _textBlockPlayer2Deck = new TextBlock();

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<Card> _selectedCards = new ObservableCollection<Card>();
        public ObservableCollection<Card> SelectedCards
        {
            get { return _selectedCards; }
            set
            {
                _selectedCards = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        //public ObservableCollection<Card> SelectedCards { get; set; } = new ObservableCollection<Card>();

        Player _previousPriorityPlayer;
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

            _rightGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            _rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            _rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            _rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            _rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            _rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            _rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            _rightGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            #region gridPlayer2DeckAndGraveyard
            _gridPlayer2DeckAndGraveyard.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            _gridPlayer2DeckAndGraveyard.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            _gridPlayer2DeckAndGraveyard.RowDefinitions.Add(new RowDefinition());

            SetupGraveyardButton(false);
            _textBlockPlayer2Deck.SetBinding(TextBlock.TextProperty, new Binding("Player2.Deck.Cards.Count") { Source = _duel });
            _player2DeckImage.ToolTip = _textBlockPlayer2Deck;
            _buttonPlayer2Graveyard.Click += _buttonPlayer2Graveyard_Click;

            Grid.SetColumn(_player2DeckImage, 0);
            Grid.SetRow(_player2DeckImage, 0);
            _gridPlayer2DeckAndGraveyard.Children.Add(_player2DeckImage);

            Grid.SetColumn(_buttonPlayer2Graveyard, 1);
            Grid.SetRow(_buttonPlayer2Graveyard, 0);
            _gridPlayer2DeckAndGraveyard.Children.Add(_buttonPlayer2Graveyard);
            #endregion gridPlayer2DeckAndGraveyard

            #region gridPlayer2ShieldsAndHand
            _gridPlayer2ShieldsAndHand.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            _gridPlayer2ShieldsAndHand.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            _gridPlayer2ShieldsAndHand.RowDefinitions.Add(new RowDefinition());

            SetupShieldsButton(false);
            SetupHandButton(false);

            _buttonPlayer2Shields.Click += _buttonPlayer2Shields_Click;
            _buttonPlayer2Hand.Click += _buttonPlayer2Hand_Click;

            Grid.SetColumn(_buttonPlayer2Shields, 0);
            Grid.SetRow(_buttonPlayer2Shields, 0);
            _gridPlayer2ShieldsAndHand.Children.Add(_buttonPlayer2Shields);

            Grid.SetColumn(_buttonPlayer2Hand, 1);
            Grid.SetRow(_buttonPlayer2Hand, 0);
            _gridPlayer2ShieldsAndHand.Children.Add(_buttonPlayer2Hand);
            #endregion gridPlayer2ShieldsAndHand

            #region gridPlayer1DeckAndGraveyard
            _gridPlayer1DeckAndGraveyard.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            _gridPlayer1DeckAndGraveyard.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            _gridPlayer1DeckAndGraveyard.RowDefinitions.Add(new RowDefinition());

            SetupGraveyardButton(true);
            _textBlockPlayer1Deck.SetBinding(TextBlock.TextProperty, new Binding("Player1.Deck.Cards.Count") { Source = _duel });
            _player1DeckImage.ToolTip = _textBlockPlayer1Deck;
            _buttonPlayer1Graveyard.Click += _buttonPlayer1Graveyard_Click;

            Grid.SetColumn(_player1DeckImage, 0);
            Grid.SetRow(_player1DeckImage, 0);
            _gridPlayer1DeckAndGraveyard.Children.Add(_player1DeckImage);

            Grid.SetColumn(_buttonPlayer1Graveyard, 1);
            Grid.SetRow(_buttonPlayer1Graveyard, 0);
            _gridPlayer1DeckAndGraveyard.Children.Add(_buttonPlayer1Graveyard);
            #endregion gridPlayer1DeckAndGraveyard

            #region gridPlayer1ShieldsAndHand
            _gridPlayer1ShieldsAndHand.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            _gridPlayer1ShieldsAndHand.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            _gridPlayer1ShieldsAndHand.RowDefinitions.Add(new RowDefinition());

            SetupShieldsButton(true);
            SetupHandButton(true);

            _buttonPlayer1Shields.Click += _buttonPlayer1Shields_Click;
            _buttonPlayer1Hand.Click += _buttonPlayer1Hand_Click;

            Grid.SetColumn(_buttonPlayer1Shields, 0);
            Grid.SetRow(_buttonPlayer1Shields, 0);
            _gridPlayer1ShieldsAndHand.Children.Add(_buttonPlayer1Shields);

            Grid.SetColumn(_buttonPlayer1Hand, 1);
            Grid.SetRow(_buttonPlayer1Hand, 0);
            _gridPlayer1ShieldsAndHand.Children.Add(_buttonPlayer1Hand);
            #endregion gridPlayer1ShieldsAndHand

            Grid.SetColumn(_rightGrid, 2);
            _mainGrid.Children.Add(_rightGrid);

            _mainCanvas.Children.Add(_mainGrid);
            _mainCanvas.Children.Add(_setupCanvas);

            Content = _mainCanvas;

            _actionButtonGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _actionButtonGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            _actionButtonGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Star) });
            Grid.SetRow(_actionButton, 0);
            _actionButtonGrid.Children.Add(_actionButton);
            Grid.SetRow(_declineButton, 1);
            _actionButtonGrid.Children.Add(_declineButton);

            _mainCanvas.SizeChanged += MainCanvas_SizeChanged;
            _actionButton.Click += _actionButton_Click;
            _declineButton.Click += _declineButton_Click;
        }

        #region Public methods
        public void InitializeDuel(string player1Name, string player2Name, string player1DeckPath, string player2DeckPath)
        {
            //TODO: implement checkbox for toggling ai
            _duel.Player1 = new Player() { Id = 0, Name = player1Name };
            _duel.Player2 = new AIPlayer() { Id = 1, Name = player2Name };
            int gameId = 0;
            _duel.Player1.SetDeckBeforeDuel(CardFactory.GetCardsFromJsonCards(JsonCardFactory.GetJsonCards(JsonPath, Deserialize(player1DeckPath)), ref gameId, _duel.Player1));
            _duel.Player2.SetDeckBeforeDuel(CardFactory.GetCardsFromJsonCards(JsonCardFactory.GetJsonCards(JsonPath, Deserialize(player2DeckPath)), ref gameId, _duel.Player2));

            //todo: not parsed abilities
            if (Duel.NotParsedAbilities.Count > 0)
            {
                string message = "The following abilities could not be parsed (the game can still be played without those abilities):";
                var abilities = Duel.NotParsedAbilities.Distinct().ToList();
                MessageBox.Show(string.Join("\r\n\r\n", message, string.Join("\r\n", abilities)));
            }

            _duel.Player1.SetupDeck(_duel);
            _duel.Player2.SetupDeck(_duel);
            PlayerAction playerAction = _duel.StartDuel();

            _textBoxNonPriorityName.SetBinding(TextBox.TextProperty, new Binding("PlayerWithoutPriority.Name") { Source = _duel });
            _textBoxPriorityName.SetBinding(TextBox.TextProperty, new Binding("PlayerWithPriority.Name") { Source = _duel });

            _listViewPlayer1BattleZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player1.BattleZone.Cards") { Source = _duel });
            _listViewPlayer1Hand.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player1.Hand.Cards") { Source = _duel });
            _listViewPlayer1ManaZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player1.ManaZone.Cards") { Source = _duel });
            _listViewPlayer2BattleZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player2.BattleZone.Cards") { Source = _duel });
            _listViewPlayer2Hand.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player2.Hand.Cards") { Source = _duel });
            _listViewPlayer2ManaZone.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Player2.ManaZone.Cards") { Source = _duel });
            
            BindCardCanvasToListView(_listViewPlayer1Hand);
            BindCardCanvasToListView(_listViewPlayer1ManaZone);
            BindCardCanvasToListView(_listViewPlayer2Hand);
            BindCardCanvasToListView(_listViewPlayer2ManaZone);

            BindBattleZoneCreatureCanvasToListView(_listViewPlayer1BattleZone);
            BindBattleZoneCreatureCanvasToListView(_listViewPlayer2BattleZone);

            //_previousPriorityPlayer = _duel.CurrentPlayerAction.Player;
            UpdateViewToShowPlayerAction(playerAction);
        }
        #endregion Public methods

        #region Private methods
        private void UpdateViewToShowPlayerAction(PlayerAction playerAction)
        {
            if (playerAction == null)
            {
                if (_duel.Ended)
                {
                    _actionTextBox.Text = string.Format("{0} won the duel!", _duel.Winner.Name);
                }
                else
                {
                    throw new Exception("Expected player action.");
                }
            }
            else
            {
                if (playerAction.Player != _previousPriorityPlayer)
                {
                    _previousPriorityPlayer = playerAction.Player;
                    _centerGrid.Children.Clear();
                    _rightGrid.Children.Clear();

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


                        Grid.SetColumn(_gridPlayer2ShieldsAndHand, 0);
                        Grid.SetRow(_gridPlayer2ShieldsAndHand, 1);
                        _rightGrid.Children.Add(_gridPlayer2ShieldsAndHand);

                        Grid.SetColumn(_gridPlayer2DeckAndGraveyard, 0);
                        Grid.SetRow(_gridPlayer2DeckAndGraveyard, 2);
                        _rightGrid.Children.Add(_gridPlayer2DeckAndGraveyard);

                        Grid.SetColumn(_gridPlayer1DeckAndGraveyard, 0);
                        Grid.SetRow(_gridPlayer1DeckAndGraveyard, 5);
                        _rightGrid.Children.Add(_gridPlayer1DeckAndGraveyard);

                        Grid.SetColumn(_gridPlayer1ShieldsAndHand, 0);
                        Grid.SetRow(_gridPlayer1ShieldsAndHand, 6);
                        _rightGrid.Children.Add(_gridPlayer1ShieldsAndHand);
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

                        Grid.SetColumn(_gridPlayer2ShieldsAndHand, 0);
                        Grid.SetRow(_gridPlayer2ShieldsAndHand, 6);
                        _rightGrid.Children.Add(_gridPlayer2ShieldsAndHand);

                        Grid.SetColumn(_gridPlayer2DeckAndGraveyard, 0);
                        Grid.SetRow(_gridPlayer2DeckAndGraveyard, 5);
                        _rightGrid.Children.Add(_gridPlayer2DeckAndGraveyard);

                        Grid.SetColumn(_gridPlayer1DeckAndGraveyard, 0);
                        Grid.SetRow(_gridPlayer1DeckAndGraveyard, 2);
                        _rightGrid.Children.Add(_gridPlayer1DeckAndGraveyard);

                        Grid.SetColumn(_gridPlayer1ShieldsAndHand, 0);
                        Grid.SetRow(_gridPlayer1ShieldsAndHand, 1);
                        _rightGrid.Children.Add(_gridPlayer1ShieldsAndHand);
                    }

                    Grid.SetColumn(_textBoxNonPriorityName, 0);
                    Grid.SetRow(_textBoxNonPriorityName, 0);
                    _rightGrid.Children.Add(_textBoxNonPriorityName);

                    Grid.SetColumn(_actionTextBox, 0);
                    Grid.SetRow(_actionTextBox, 3);
                    _rightGrid.Children.Add(_actionTextBox);

                    Grid.SetColumn(_actionButtonGrid, 0);
                    Grid.SetRow(_actionButtonGrid, 4);
                    _rightGrid.Children.Add(_actionButtonGrid);

                    Grid.SetColumn(_textBoxPriorityName, 0);
                    Grid.SetRow(_textBoxPriorityName, 7);
                    _rightGrid.Children.Add(_textBoxPriorityName);

                    _centerGrid.BeginAnimation(OpacityProperty, new DoubleAnimation(0.5, 1.0, new Duration(new TimeSpan(0, 0, 2))));
                }

                _textBoxPriorityName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                _textBoxNonPriorityName.GetBindingExpression(TextBox.TextProperty).UpdateTarget();

                _textBlockPlayer1Shields.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
                _textBlockPlayer2Shields.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
                _textBlockPlayer1Hand.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
                _textBlockPlayer2Hand.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
                _textBlockPlayer1Graveyard.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
                _textBlockPlayer2Graveyard.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
                _textBlockPlayer1Deck.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
                _textBlockPlayer2Deck.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();

                _actionButton.Content = "";
                _actionButton.IsEnabled = false;

                _actionButtonGrid.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Star);

                if (playerAction is CardSelection cardSelection)
                {
                    if (cardSelection is OptionalCardSelection optionalCardSelection)
                    {
                        _actionButton.IsEnabled = true;
                        if (optionalCardSelection is ChargeMana chargeMana)
                        {
                            _actionTextBox.Text = "You may charge mana.";
                            _actionButton.Content = "Skip";
                        }
                        else if (optionalCardSelection is UseCard useCard)
                        {
                            _actionTextBox.Text = "You may use a card.";
                            _actionButton.Content = "Skip";
                        }
                        else
                        {
                            throw new ArgumentException("Unknown card selection.");
                        }
                    }
                    else if (cardSelection is PayCost payCost)
                    {
                        _actionTextBox.Text = string.Format("Pay the mana cost for {0}.", (_duel.CurrentTurn.CurrentStep as MainStep).CardToBeUsed.Name);
                    }
                    else if (cardSelection is MultipleCardSelection multipleCardSelection)
                    {
                        _actionButton.IsEnabled = true;
                        if (multipleCardSelection is DeclareShieldTriggers)
                        {
                            _actionTextBox.Text = "Declare shield triggers to be used.";
                            _actionButton.Content = "Confirm";
                        }
                        else
                        {
                            throw new ArgumentException("Unknown multiple card selection.");
                        }
                    }
                    else if (cardSelection is MandatoryCardSelection mandatoryCardSelection)
                    {
                        if (mandatoryCardSelection is UseShieldTrigger)
                        {
                            _actionTextBox.Text = "Declare shield trigger to be used.";
                        }
                        else
                        {
                            throw new ArgumentException("Unknown mandatory card selection.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Unknown card selection.");
                    }
                }
                else if (playerAction is OptionalCreatureSelection optionalCreatureSelection)
                {
                    _actionButton.IsEnabled = true;
                    if (optionalCreatureSelection is DeclareAttacker)
                    {
                        _actionTextBox.Text = "You may declare a creature to attack with.";
                        _actionButton.Content = "Do not attack";
                    }
                    else if (optionalCreatureSelection is DeclareTargetOfAttack)
                    {
                        _actionTextBox.Text = "Declare the target of the attack.";
                        if (_duel.CanAttackOpponent((_duel.CurrentTurn.CurrentStep as AttackDeclarationStep).AttackingCreature))
                        {
                            _actionButton.Content = "Attack opponent";
                        }
                        else
                        {
                            _actionButton.IsEnabled = false;
                        }
                    }
                    else if (optionalCreatureSelection is DeclareBlock)
                    {
                        _actionTextBox.Text = "You may declare a creature to block the attack with.";
                        _actionButton.Content = "Do not block";
                    }
                    else if (optionalCreatureSelection is YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand)
                    {
                        _actionTextBox.Text = "You may choose a creature in the battle zone and return it to its owner's hand.";
                        _actionButton.Content = "Decline";
                    }
                    else
                    {
                        throw new ArgumentException("Unknown optional creature selection.");
                    }
                }
                else if (playerAction is OptionalAction optionalAction)
                {
                    _actionButton.IsEnabled = true;
                    _actionButton.Content = "Take action";
                    _actionButtonGrid.RowDefinitions[1].Height = new GridLength(1, GridUnitType.Star);
                    if (optionalAction is YouMayDrawACard youMayDrawACard)
                    {
                        _actionTextBox.Text = "You may draw a card.";
                    }
                    else
                    {
                        throw new ArgumentException("Unknown optional action.");
                    }
                }
                else
                {
                    throw new ArgumentException("Unknown player action.");
                }
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

        private void BindCardCanvasToListView(ListView listView)
        {
            FrameworkElementFactory cardCanvasFactory = new FrameworkElementFactory(typeof(CardCanvas));
            BindAbstractCardCanvas(listView, cardCanvasFactory);

            cardCanvasFactory.SetBinding(CardCanvas.CardTextProperty, new Binding("Text"));
            cardCanvasFactory.SetBinding(CardCanvas.CostProperty, new Binding("Cost"));
            cardCanvasFactory.SetBinding(CardCanvas.RaceProperty, new Binding("Races"));  
            cardCanvasFactory.SetBinding(CardCanvas.CardTypeProperty, new Binding() { Converter = new ObjectToCardTypeConverter() });
        }

        private void BindBattleZoneCreatureCanvasToListView(ListView listView)
        {
            FrameworkElementFactory canvasFactory = new FrameworkElementFactory(typeof(BattleZoneCreatureCanvas));
            BindAbstractCardCanvas(listView, canvasFactory);

            canvasFactory.SetBinding(BattleZoneCreatureCanvas.SummoningSicknessProperty, new Binding("SummoningSickness"));
            canvasFactory.SetBinding(BattleZoneCreatureCanvas.AbilitiesProperty, new Binding("Abilities"));
        }

        private void BindAbstractCardCanvas(ListView listView, FrameworkElementFactory cardCanvasFactory)
        {
            listView.ItemsPanel = new ItemsPanelTemplate() { VisualTree = GetStackPanelFactory() };

            cardCanvasFactory.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = listView, Converter = new ListViewSizeToCardCanvasSizeConverter(), ConverterParameter = 0.96 });
            cardCanvasFactory.SetBinding(WidthProperty, new Binding("ActualHeight") { Source = listView, Converter = new ListViewSizeToCardCanvasSizeConverter(), ConverterParameter = 0.96 });

            cardCanvasFactory.SetBinding(AbstractCardCanvas.CardNameProperty, new Binding("Name"));
            cardCanvasFactory.SetBinding(AbstractCardCanvas.CivilizationProperty, new Binding("Civilizations"));
            cardCanvasFactory.SetBinding(AbstractCardCanvas.PowerProperty, new Binding("Power"));
            cardCanvasFactory.SetBinding(AbstractCardCanvas.GameIdProperty, new Binding("GameId"));
            cardCanvasFactory.SetBinding(AbstractCardCanvas.TappedProperty, new Binding("Tapped"));
            MultiBinding multiBinding = new MultiBinding() { Converter = new SetAndIdConverter() };
            multiBinding.Bindings.Add(new Binding("Set"));
            multiBinding.Bindings.Add(new Binding("Id"));
            cardCanvasFactory.SetBinding(AbstractCardCanvas.SetAndIdProperty, multiBinding);
            cardCanvasFactory.SetBinding(AbstractCardCanvas.CandidateGameIdsProperty, new Binding("CurrentPlayerAction") { Converter = new PlayerActionToIntCollectionConverter(), Source = _duel });
            cardCanvasFactory.SetBinding(AbstractCardCanvas.SelectedGameIdsProperty, new Binding("SelectedCards") { Converter = new CardCollectionToIntCollectionConverter(), Source = this });

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
                    if (useCard.SelectedCard is Creature creature)
                    {
                        LogMessages.Add(string.Format("{0} summoned {1}.", useCard.Player.Name, creature.Name));
                    }
                    else if (useCard.SelectedCard is Spell spell)
                    {
                        LogMessages.Add(string.Format("{0} cast {1}.", useCard.Player.Name, spell.Name));
                    }
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
            else if (playerAction is DeclareBlock declareBlock)
            {
                if (declareBlock.SelectedCreature != null)
                {
                    LogMessages.Add(string.Format("{0} blocked the attack with {1}.", declareBlock.Player.Name, declareBlock.SelectedCreature.Name));
                }
            }
            else if (playerAction is DeclareShieldTriggers declareShieldTriggers)
            {
                if (declareShieldTriggers.SelectedCards.Count > 0)
                {
                    LogMessages.Add(string.Format("{0} declared to use the following shield triggers: {1}", declareShieldTriggers.Player.Name, string.Join("; ", declareShieldTriggers.SelectedCards.Select(c => c.Name))));
                }
            }
            else if (playerAction is UseShieldTrigger useShieldTrigger)
            {
                LogMessages.Add(string.Format("{0} used the shield trigger ability of {1}.", useShieldTrigger.Player.Name, useShieldTrigger.SelectedCard.Name));
            }
            else if (playerAction is PutTheTopCardOfYourDeckIntoYourManaZone/* || playerAction is PutTheTopCardOfYourDeckIntoYourManaZoneThenAddTheTopCardOfYourDeckToYourShieldsFaceDown*/) //TODO: remove commented part
            {
                LogMessages.Add(string.Format("{0} put the top card of their deck into their mana zone.", playerAction.Player.Name));
            }
            else if (playerAction is AddTheTopCardOfYourDeckToYourShieldsFaceDown)
            {
                LogMessages.Add(string.Format("{0} added the top card of their deck to their shields face down.", playerAction.Player.Name));
            }
            else if (playerAction is YouMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand youMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand)
            {
                if (youMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand.SelectedCreature != null)
                {
                    LogMessages.Add(string.Format("{0} returned {1} to its owner's hand.", youMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand.Player.Name, youMayChooseACreatureInTheBattleZoneAndReturnItToItsOwnersHand.SelectedCreature.Name));
                }
            }
            else if (!(playerAction is OptionalAction))
            {
                throw new ArgumentOutOfRangeException("Unknown player action.");
            }
        }

        private void SetupShieldsButton(bool player1)
        {
            Button buttonShields = _buttonPlayer1Shields;
            TextBlock textBlockShields = _textBlockPlayer1Shields;
            string playerName = "Player1";
            if (!player1)
            {
                buttonShields = _buttonPlayer2Shields;
                textBlockShields = _textBlockPlayer2Shields;
                playerName = "Player2";
            }
            Canvas canvasPlayerShields = new Canvas()
            {
                Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("../../Images/shield.png", UriKind.Relative)),
                    Stretch = Stretch.Fill,
                },
            };
            canvasPlayerShields.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = buttonShields });
            canvasPlayerShields.SetBinding(WidthProperty, new Binding("ActualWidth") { Source = buttonShields });

            Grid gridPlayerShields = new Grid();
            gridPlayerShields.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayerShields.RowDefinitions.Add(new RowDefinition());

            gridPlayerShields.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = canvasPlayerShields });
            gridPlayerShields.SetBinding(WidthProperty, new Binding("ActualWidth") { Source = canvasPlayerShields });

            textBlockShields.SetBinding(TextBlock.TextProperty, new Binding(string.Format("{0}.ShieldZone.Cards.Count", playerName)) { Source = _duel });
            gridPlayerShields.Children.Add(textBlockShields);
            canvasPlayerShields.Children.Add(gridPlayerShields);

            buttonShields.Content = canvasPlayerShields;
        }

        private void SetupHandButton(bool player1)
        {
            Button buttonHand = _buttonPlayer1Hand;
            TextBlock textBlockHand = _textBlockPlayer1Hand;
            string playerName = "Player1";
            if (!player1)
            {
                buttonHand = _buttonPlayer2Hand;
                textBlockHand = _textBlockPlayer2Hand;
                playerName = "Player2";
            }
            Canvas canvasPlayerHand = new Canvas()
            {
                Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("../../Images/hand.png", UriKind.Relative)),
                    Stretch = Stretch.Fill,
                },
            };
            canvasPlayerHand.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = buttonHand });
            canvasPlayerHand.SetBinding(WidthProperty, new Binding("ActualWidth") { Source = buttonHand });

            Grid gridPlayerHand = new Grid();
            gridPlayerHand.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayerHand.RowDefinitions.Add(new RowDefinition());

            gridPlayerHand.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = canvasPlayerHand });
            gridPlayerHand.SetBinding(WidthProperty, new Binding("ActualWidth") { Source = canvasPlayerHand });

            textBlockHand.SetBinding(TextBlock.TextProperty, new Binding(string.Format("{0}.Hand.Cards.Count", playerName)) { Source = _duel });
            gridPlayerHand.Children.Add(textBlockHand);
            canvasPlayerHand.Children.Add(gridPlayerHand);

            buttonHand.Content = canvasPlayerHand;
        }

        private void SetupGraveyardButton(bool player1)
        {
            Button buttonGraveyard = _buttonPlayer1Graveyard;
            TextBlock textBlockGraveyard = _textBlockPlayer1Graveyard;
            string playerName = "Player1";
            if (!player1)
            {
                buttonGraveyard = _buttonPlayer2Graveyard;
                textBlockGraveyard = _textBlockPlayer2Graveyard;
                playerName = "Player2";
            }
            Canvas canvasPlayerGraveyard = new Canvas()
            {
                Background = new ImageBrush
                {
                    ImageSource = new BitmapImage(new Uri("../../Images/graveyard.png", UriKind.Relative)),
                    Stretch = Stretch.Fill,
                },
            };
            canvasPlayerGraveyard.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = buttonGraveyard });
            canvasPlayerGraveyard.SetBinding(WidthProperty, new Binding("ActualWidth") { Source = buttonGraveyard });

            Grid gridPlayerGraveyard = new Grid();
            gridPlayerGraveyard.ColumnDefinitions.Add(new ColumnDefinition());
            gridPlayerGraveyard.RowDefinitions.Add(new RowDefinition());

            gridPlayerGraveyard.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = canvasPlayerGraveyard });
            gridPlayerGraveyard.SetBinding(WidthProperty, new Binding("ActualWidth") { Source = canvasPlayerGraveyard });

            textBlockGraveyard.SetBinding(TextBlock.TextProperty, new Binding(string.Format("{0}.Graveyard.Cards.Count", playerName)) { Source = _duel });
            gridPlayerGraveyard.Children.Add(textBlockGraveyard);
            canvasPlayerGraveyard.Children.Add(gridPlayerGraveyard);

            buttonGraveyard.Content = canvasPlayerGraveyard;
        }

        private void GetJsonCardsTest()
        {
            Collection<JsonCard> jsonCards = JsonCardFactory.GetJsonCards(JsonPath);
            System.Collections.Generic.List<XmlCard> xmlCards = jsonCards.Select(j => new XmlCard() { Set = j.Set, Id = j.Id, Amount = 1 }).ToList();
            XmlSerializer writer = new XmlSerializer(typeof(System.Collections.Generic.List<XmlCard>));
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//AllCards.xml";
            FileStream file = File.Create(path);
            writer.Serialize(file, xmlCards);
            file.Close();
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
                    _textBoxLog.AppendText("\r\n");
                    if (text.Contains("started turn"))
                    {
                        _textBoxLog.AppendText("\r\n");
                    }
                }
                _textBoxLog.AppendText(text);
            }
            _textBoxLog.ScrollToEnd();
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
            var cardCanvas = sender as AbstractCardCanvas;
            if (_duel.CurrentPlayerAction is CardSelection cardSelection)
            {
                if (cardSelection.CardIds.Contains(cardCanvas.GameId))
                {
                    if (cardSelection is OptionalCardSelection optionalCardSelection)
                    {
                        UpdateViewToShowPlayerAction(_duel.Progress(new CardSelectionResponse(new Collection<Card>(optionalCardSelection.Cards.Where(c => c.GameId == cardCanvas.GameId).ToList()))));
                    }
                    else if (cardSelection is PayCost payCost)
                    {
                        UpdateSelectedCards(cardCanvas, payCost.Cards);
                        if (SelectedCards.Count == payCost.MaximumSelection && payCost.Validate(SelectedCards, (_duel.CurrentTurn.CurrentStep as MainStep).CardToBeUsed))
                        {
                            var response = new CardSelectionResponse(new Collection<Card>(SelectedCards));
                            UpdateViewToShowPlayerAction(_duel.Progress(response));
                            SelectedCards = new ObservableCollection<Card>();
                        }
                    }
                    else if (cardSelection is MultipleCardSelection multipleCardSelection)
                    {
                        UpdateSelectedCards(cardCanvas, multipleCardSelection.Cards);
                    }
                    else if (cardSelection is MandatoryCardSelection mandatoryCardSelection)
                    {
                        UpdateViewToShowPlayerAction(_duel.Progress(new CardSelectionResponse(new Collection<Card>(mandatoryCardSelection.Cards.Where(c => c.GameId == cardCanvas.GameId).ToList()))));
                    }
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
            else if (!(_duel.CurrentPlayerAction is OptionalAction))
            {
                throw new ArgumentException("Unknown player action.");
            }
        }

        private void UpdateSelectedCards(AbstractCardCanvas cardCanvas, Collection<Card> cards)
        {
            Card card = cards.First(c => c.GameId == cardCanvas.GameId);
            if (!SelectedCards.Contains(card))
            {
                SelectedCards = new ObservableCollection<Card>(SelectedCards) { card };
            }
            else
            {
                var newCards = new ObservableCollection<Card>(SelectedCards);
                newCards.Remove(card);
                SelectedCards = newCards;
            }
        }

        private void _actionButton_Click(object sender, RoutedEventArgs e)
        {
            if (_duel.CurrentPlayerAction is CardSelection)
            {
                UpdateViewToShowPlayerAction(_duel.Progress(new CardSelectionResponse(SelectedCards)));
                SelectedCards = new ObservableCollection<Card>();
            }
            else if (_duel.CurrentPlayerAction is OptionalCreatureSelection)
            {
                UpdateViewToShowPlayerAction(_duel.Progress(new CreatureSelectionResponse(new Collection<Creature>(SelectedCards.Cast<Creature>().ToList()))));
                SelectedCards = new ObservableCollection<Card>();
            }
            else if (_duel.CurrentPlayerAction is OptionalAction optionalAction)
            {
                UpdateViewToShowPlayerAction(_duel.Progress(new OptionalActionResponse(true)));
            }
            else
            {
                throw new ArgumentOutOfRangeException("Player action");
            }
        }

        private void _declineButton_Click(object sender, RoutedEventArgs e)
        {
            if (_duel.CurrentPlayerAction is OptionalAction optionalAction)
            {
                UpdateViewToShowPlayerAction(_duel.Progress(new OptionalActionResponse(false)));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private void _buttonPlayer1Hand_Click(object sender, RoutedEventArgs e)
        {
        }

        private void _buttonPlayer1Shields_Click(object sender, RoutedEventArgs e)
        {
        }

        private void _buttonPlayer1Graveyard_Click(object sender, RoutedEventArgs e)
        {
        }

        private void _buttonPlayer2Hand_Click(object sender, RoutedEventArgs e)
        {
        }

        private void _buttonPlayer2Shields_Click(object sender, RoutedEventArgs e)
        {
        }

        private void _buttonPlayer2Graveyard_Click(object sender, RoutedEventArgs e)
        {
        }
        #endregion Events
    }

    #region Converters
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

    [ValueConversion(typeof(Collection<Card>), typeof(Collection<int>))]
    public class CardCollectionToIntCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Collection<Card> cards = value as Collection<Card>;
            return new Collection<int>(cards.Select(c => c.GameId).ToList());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(double), typeof(double))]
    public class ListViewSizeToCardCanvasSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)parameter * (double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
    #endregion Converters
}
