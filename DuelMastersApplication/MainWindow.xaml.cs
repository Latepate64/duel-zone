using DuelMastersModels;
using DuelMastersModels.Cards;
using DuelMastersModels.Factories;
using DuelMastersModels.PlayerActions;
using DuelMastersModels.PlayerActions.CardSelections;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml.Serialization;

namespace DuelMastersApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int SideColumnWidth = 150;
        const string JsonPath = "C:\\duel-masters-json\\DuelMastersCards.json";

        #region Fields
        Duel _duel = new Duel();
        Grid _mainGrid = new Grid() { ShowGridLines = true };
        Canvas _setupCanvas;
        ListView _listViewActiveHand = new ListView() { Background = Brushes.Aqua, ToolTip = "Active player's hand.", Name = "ListViewActiveHand" };
        #endregion Fields

        public MainWindow()
        {
            _setupCanvas = new SetupCanvas(_duel, this);
            InitializeComponent();
            Title = "Duel Masters Application";

            Canvas mainCanvas = new Canvas()
            {
                //Background = Brushes.Aquamarine,
            };
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(SideColumnWidth) });
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(SideColumnWidth) });
            _mainGrid.RowDefinitions.Add(new RowDefinition());

            TextBlock testButton = new TextBlock() { Text = "Jee" };
            Grid.SetColumn(testButton, 0);
            Grid.SetRow(testButton, 0);
            _mainGrid.Children.Add(testButton);

            Grid centerGrid = new Grid() { ShowGridLines = true };
            centerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 5; ++i)
            {
                centerGrid.RowDefinitions.Add(new RowDefinition());
            }
            Grid.SetColumn(centerGrid, 1);
            _mainGrid.Children.Add(centerGrid);

            //Duel duel = new Duel();
            //_listViewActiveHand.ItemsSource = duel.Player1.Hand.Cards;

            Grid.SetColumn(_listViewActiveHand, 0);
            Grid.SetRow(_listViewActiveHand, 5);
            centerGrid.Children.Add(_listViewActiveHand);

            mainCanvas.Children.Add(_mainGrid);
            mainCanvas.Children.Add(_setupCanvas);

            Content = mainCanvas;

            mainCanvas.SizeChanged += MainCanvas_SizeChanged;
            //_setupCanvas.star            //mainGrid.Children.Add(canvas);
            //Content = canvas;

            
        }

        #region Public methods
        public void InitializeDuel(string player1Name, string player2Name, string player1DeckPath, string player2DeckPath)
        {
            _duel.Player1 = new Player() { Id = 0, Name = player1Name };
            _duel.Player2 = new Player() { Id = 1, Name = player2Name };
            _duel.Player1.SetDeckBeforeDuel(CardFactory.GetCardsFromJsonCards(JsonCardFactory.GetJsonCards(JsonPath, Deserialize(player1DeckPath))));
            _duel.Player2.SetDeckBeforeDuel(CardFactory.GetCardsFromJsonCards(JsonCardFactory.GetJsonCards(JsonPath, Deserialize(player2DeckPath))));
            _duel.Player1.SetupDeck();
            _duel.Player2.SetupDeck();
            UpdateViewToShowPlayerAction(_duel.StartDuel());
            TestHandBinding();
        }
        #endregion Public methods

        #region Private methods
        private void UpdateViewToShowPlayerAction(PlayerAction playerAction)
        {
            if  (playerAction is CardSelection cardSelection)
            {
                //todo: animate selectable cards
                if (cardSelection is ChargeMana chargeMana)
                {

                    //chargeMana.
                    throw new NotImplementedException();
                }
                else
                {
                    throw new ArgumentException("Unknown card selection.");
                }
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

        private void TestHandBinding()
        {
            _listViewActiveHand.ItemsSource = _duel.CurrentTurn.ActivePlayer.Hand.Cards;

            FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            _listViewActiveHand.ItemsPanel = new ItemsPanelTemplate() { VisualTree = stackPanelFactory };

            FrameworkElementFactory cardCanvasFactory = new FrameworkElementFactory(typeof(CardCanvas));

            cardCanvasFactory.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = _listViewActiveHand });
            cardCanvasFactory.SetBinding(WidthProperty, new Binding("ActualHeight") { Source = _listViewActiveHand });

            //cardCanvasFactory.SetBinding()

            cardCanvasFactory.SetBinding(CardCanvas.CardNameProperty, new Binding("Name"));
            cardCanvasFactory.SetBinding(CardCanvas.CivilizationProperty, new Binding("Civilizations"));
            cardCanvasFactory.SetBinding(CardCanvas.CardTextProperty, new Binding("Text"));
            cardCanvasFactory.SetBinding(CardCanvas.CostProperty, new Binding("Cost"));
            cardCanvasFactory.SetBinding(CardCanvas.PowerProperty, new Binding("Power"));
            cardCanvasFactory.SetBinding(CardCanvas.RaceProperty, new Binding("Races"));
            cardCanvasFactory.SetBinding(CardCanvas.CardTypeProperty, new Binding() { Converter = new ObjectToCardTypeConverter() });
            MultiBinding multiBinding = new MultiBinding() { Converter = new SetAndIdConverter() };
            multiBinding.Bindings.Add(new Binding("Set"));
            multiBinding.Bindings.Add(new Binding("Id"));
            cardCanvasFactory.SetBinding(CardCanvas.SetAndIdProperty, multiBinding);

            _listViewActiveHand.ItemTemplate = new DataTemplate() { VisualTree = cardCanvasFactory };
            /*
            FrameworkElementFactory textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory.SetValue(TextBlock.TextProperty, new Binding("Name"));
            textBlockFactory.SetValue(TextBlock.BackgroundProperty, Brushes.Red);
            textBlockFactory.SetValue(TextBlock.ForegroundProperty, Brushes.Wheat);
            textBlockFactory.SetValue(TextBlock.FontSizeProperty, 18.0);

            _listViewActiveHand.ItemTemplate = new DataTemplate() { VisualTree = textBlockFactory };
            */

            //var cardCanvas = _listViewActiveHand.Items[0] as CardCanvas;
            //var left = cardCanvas.p
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
}
