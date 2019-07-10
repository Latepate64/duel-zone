using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace DuelMastersApplication
{
    public struct SetAndId
    {
        public string Set { get; set; }
        public string Id { get; set; }
    }

    public class CardCanvas : Canvas
    {
        #region Constants
        const int CardNameRow = 0;
        const int ArtworkRow = 1;
        const int TextRow = 2;
        const int CardTypeRow = 3;
        #endregion Constants

        #region DependencyProperties
        public static readonly DependencyProperty CardNameProperty = DependencyProperty.Register("CardName", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardNameChanged));

        public static readonly DependencyProperty CivilizationProperty = DependencyProperty.Register("Civilizations", typeof(Collection<Civilization>), typeof(CardCanvas), new PropertyMetadata(OnCivilizationsChanged));

        public static readonly DependencyProperty SetAndIdProperty = DependencyProperty.Register("SetAndId", typeof(SetAndId), typeof(CardCanvas), new PropertyMetadata(OnSetAndIdChanged));

        public static readonly DependencyProperty CardTextProperty = DependencyProperty.Register("CardText", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardTextChanged));

        public static readonly DependencyProperty CostProperty = DependencyProperty.Register("Cost", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCostChanged));

        public static readonly DependencyProperty CardTypeProperty = DependencyProperty.Register("CardType", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardTypeChanged));

        public static readonly DependencyProperty PowerProperty = DependencyProperty.Register("Power", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnPowerChanged));

        public static readonly DependencyProperty RaceProperty = DependencyProperty.Register("Races", typeof(Collection<string>), typeof(CardCanvas), new PropertyMetadata(OnRaceChanged));

        public static readonly DependencyProperty GameIdProperty = DependencyProperty.Register("GameId", typeof(int), typeof(CardCanvas));

        public static readonly DependencyProperty GameIdsProperty = DependencyProperty.Register("GameIds", typeof(Collection<int>), typeof(CardCanvas), new PropertyMetadata(OnGameIdsChanged));

        public static readonly DependencyProperty TappedProperty = DependencyProperty.Register("Tapped", typeof(bool), typeof(CardCanvas), new PropertyMetadata(OnTapStatusChanged));
        #endregion DependencyProperties

        #region Other properties
        public string CardName
        {
            get { return (string)GetValue(CardNameProperty); }
            set { SetValue(CardNameProperty, value); }
        }

        public Collection<Civilization> Civilizations
        {
            get { return (Collection<Civilization>)GetValue(CivilizationProperty); }
            set { SetValue(CivilizationProperty, value); }
        }

        public SetAndId SetAndId
        {
            get { return (SetAndId)GetValue(SetAndIdProperty); }
            set { SetValue(SetAndIdProperty, value); }
        }

        public string CardText
        {
            get { return (string)GetValue(CardTextProperty); }
            set { SetValue(CardTextProperty, value); }
        }

        public int GameId
        {
            get { return (int)GetValue(GameIdProperty); }
            set { SetValue(GameIdProperty, value); }
        }

        public bool Tapped
        {
            get { return (bool)GetValue(TappedProperty); }
            set { SetValue(TappedProperty, value); }
        }
        #endregion Other properties

        #region Fields
        private static readonly Dictionary<Civilization, Brush> _civilizationDictionary = new Dictionary<Civilization, Brush>()
        {
            { Civilization.Light, Brushes.LightYellow },
            { Civilization.Water, Brushes.LightBlue },
            { Civilization.Darkness, Brushes.Gray },
            { Civilization.Fire, Brushes.Red },
            { Civilization.Nature, Brushes.LightGreen },
        };

        private TextBox _textBoxCardName = new TextBox() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Top };
        private Image _artwork = new Image();
        private TextBox _textBoxCardText = new TextBox() { TextWrapping = TextWrapping.Wrap, IsReadOnly = true, VerticalScrollBarVisibility = ScrollBarVisibility.Auto };
        private TextBox _textBoxCost = new TextBox() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Background = Brushes.Black, Foreground = Brushes.White, FontWeight = FontWeights.Bold };
        private TextBox _textBoxPower = new TextBox() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Visibility = Visibility.Hidden };
        private TextBox _textBoxCardType = new TextBox() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center };
        private TextBox _textBoxRace = new TextBox() { HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center, Visibility = Visibility.Hidden };

        private Canvas _cardCanvas = new Canvas();
        private Grid _mainGrid = new Grid();
        #endregion Fields

        public CardCanvas()
        {
            _cardCanvas.Background = new SolidColorBrush(Colors.Black);

            Grid gridCostAndName = new Grid();
            gridCostAndName.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.2, GridUnitType.Star) });
            gridCostAndName.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.8, GridUnitType.Star) });
            gridCostAndName.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(_textBoxCost, 0);
            Grid.SetRow(_textBoxCost, 0);
            gridCostAndName.Children.Add(_textBoxCost);

            Grid.SetColumn(_textBoxCardName, 1);
            Grid.SetRow(_textBoxCardName, 0);
            gridCostAndName.Children.Add(_textBoxCardName);

            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionCardName", Height = new GridLength(0.1, GridUnitType.Star) });
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionArtwork", Height = new GridLength(0.3, GridUnitType.Star) });
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionTextRow", Height = new GridLength(0.4, GridUnitType.Star) });
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionCardType", Height = new GridLength(0.1, GridUnitType.Star) });

            Grid.SetColumn(gridCostAndName, 0);
            Grid.SetRow(gridCostAndName, CardNameRow);
            _mainGrid.Children.Add(gridCostAndName);

            Grid.SetColumn(_artwork, 0);
            Grid.SetRow(_artwork, ArtworkRow);
            _mainGrid.Children.Add(_artwork);

            Grid.SetColumn(_textBoxCardText, 0);
            Grid.SetRow(_textBoxCardText, TextRow);
            _mainGrid.Children.Add(_textBoxCardText);

            Grid gridType = new Grid();
            gridType.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            gridType.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            gridType.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            gridType.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(_textBoxPower, 0);
            Grid.SetRow(_textBoxPower, CardTypeRow);
            gridType.Children.Add(_textBoxPower);

            Grid.SetColumn(_textBoxCardType, 1);
            Grid.SetRow(_textBoxCardType, CardTypeRow);
            gridType.Children.Add(_textBoxCardType);

            Grid.SetColumn(_textBoxRace, 2);
            Grid.SetRow(_textBoxRace, CardTypeRow);
            gridType.Children.Add(_textBoxRace);

            Grid.SetColumn(gridType, 0);
            Grid.SetRow(gridType, CardTypeRow);
            _mainGrid.Children.Add(gridType);

            _cardCanvas.Children.Add(_mainGrid);
            Children.Add(_cardCanvas);

            SizeChanged += CardCanvas_SizeChanged;

            DoubleAnimation loadedAnimation = new DoubleAnimation(0.0, 1.0, new Duration(new TimeSpan(0, 0, 0, 1, 5)));
            Storyboard.SetTargetProperty(loadedAnimation, new PropertyPath(OpacityProperty)); 
            var eventTrigger = new EventTrigger(LoadedEvent);
            var storyboard = new Storyboard();
            storyboard.Children.Add(loadedAnimation);
            eventTrigger.Actions.Add(new BeginStoryboard() { Storyboard = storyboard });
            Triggers.Add(eventTrigger);
        }

        private void CardCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _cardCanvas.Height = e.NewSize.Height;
            _cardCanvas.Width = e.NewSize.Height * 222 / 307;
            SetLeft(_cardCanvas, (e.NewSize.Width - _cardCanvas.Width) / 2);
            SetTop(_cardCanvas, (e.NewSize.Height - _cardCanvas.Height) / 2);

            const double Scale = 0.1;
            _mainGrid.Height = e.NewSize.Height - e.NewSize.Height * Scale;
            _mainGrid.Width = _cardCanvas.Width - e.NewSize.Height * Scale;

            SetLeft(_mainGrid, (_cardCanvas.Width - _mainGrid.Width) / 2);
            SetTop(_mainGrid, (e.NewSize.Height - _mainGrid.Height) / 2);

            const double FontScale = 0.06;
            const double MinimumFontSize = 9;
            double fontSize = Math.Max(MinimumFontSize, e.NewSize.Height * FontScale);
            _textBoxCardName.FontSize = fontSize;
            _textBoxCardText.FontSize = fontSize;
            _textBoxCost.FontSize = fontSize;

            const double FontScaleCardType = 0.04;
            double fontSizeCardType = Math.Max(MinimumFontSize, e.NewSize.Height * FontScaleCardType);
            _textBoxPower.FontSize = fontSizeCardType;
            _textBoxCardType.FontSize = fontSizeCardType;
            _textBoxRace.FontSize = fontSizeCardType;
        }

        private static void OnCardNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnCardNameChanged(e);
        }

        private void OnCardNameChanged(DependencyPropertyChangedEventArgs e)
        {
            _textBoxCardName.Text = e.NewValue.ToString();
        }

        private static void OnCardTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnCardTextChanged(e);
        }

        private void OnCardTextChanged(DependencyPropertyChangedEventArgs e)
        {
            _textBoxCardText.Text = e.NewValue.ToString();
        }

        private static void OnSetAndIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnSetAndIdChanged(e);
        }

        private void OnSetAndIdChanged(DependencyPropertyChangedEventArgs e)
        {
            const string RootPath = "C:/DuelMastersCardImages";
            SetAndId setAndId = (SetAndId)e.NewValue;
            string path = Path.Combine(RootPath, setAndId.Set, string.Format("{0} {1}.jpg", setAndId.Set, setAndId.Id));
            _artwork.Source = new BitmapImage(new Uri(path));
        }

        private static void OnCivilizationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnCivilizationsChanged(e);
        }

        private void OnCivilizationsChanged(DependencyPropertyChangedEventArgs e)
        {
            Collection<Civilization> civilizations = e.NewValue as Collection<Civilization>;
            if (civilizations.Count == 1)
            {
                _mainGrid.Background = _civilizationDictionary[civilizations[0]];
            }
            else
            {
                throw new NotImplementedException("Implement multicolor painting");
            }
        }

        private static void OnCostChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnCostChanged(e);
        }

        private void OnCostChanged(DependencyPropertyChangedEventArgs e)
        {
            _textBoxCost.Text = e.NewValue.ToString();
        }

        private static void OnCardTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnCardTypeChanged(e);
        }

        private void OnCardTypeChanged(DependencyPropertyChangedEventArgs e)
        {
            _textBoxCardType.Text = e.NewValue.ToString();
        }

        private static void OnPowerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnPowerChanged(e);
        }

        private void OnPowerChanged(DependencyPropertyChangedEventArgs e)
        {
            string power = e.NewValue.ToString();
            if (!string.IsNullOrEmpty(power))
            {
                _textBoxPower.Visibility = Visibility.Visible;
                _textBoxPower.Text = power;
            }
        }

        private static void OnRaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnRaceChanged(e);
        }

        private void OnRaceChanged(DependencyPropertyChangedEventArgs e)
        {
            string raceText = string.Join("/", (Collection<string>)e.NewValue);
            if (!string.IsNullOrEmpty(raceText))
            {
                _textBoxRace.Visibility = Visibility.Visible;
                _textBoxRace.Text = raceText;
            }
        }

        private static void OnGameIdsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnGameIdsChanged(e);
        }

        private void OnGameIdsChanged(DependencyPropertyChangedEventArgs e)
        {
            var gameIds = (Collection<int>)e.NewValue;
            if (gameIds.Contains(GameId))
            {
                var colorAnimation = new ColorAnimation(Colors.Black, Colors.White, new Duration(new TimeSpan(0, 0, 0, 1, 5)))
                {
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever,
                };
                _cardCanvas.Background.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            }
            else
            {
                _cardCanvas.Background.BeginAnimation(SolidColorBrush.ColorProperty, null);
            }
        }

        private static void OnTapStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).OnTapStatusChanged(e);
        }

        private void OnTapStatusChanged(DependencyPropertyChangedEventArgs e)
        {
            bool tapped = (bool)e.NewValue;
            if (tapped != (bool)e.OldValue)
            {
                double fromValue = 0.0;
                double toValue = 90.0;
                if (!tapped)
                {
                    fromValue = 90.0;
                    toValue = 0.0;
                }
                RenderTransform = new RotateTransform(0, Height / 2, Height / 2);
                DoubleAnimation animation = new DoubleAnimation(fromValue, toValue, new Duration(new TimeSpan(0, 0, 1)))
                {
                    RepeatBehavior = new RepeatBehavior(1)
                };
                RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
            }
        }
    }
}
