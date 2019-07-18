using DuelMastersModels.Cards;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DuelMastersApplication
{
    public struct SetAndId
    {
        public string Set { get; set; }
        public string Id { get; set; }
    }

    public class CardCanvas : AbstractCardCanvas
    {
        #region Constants
        const int CardNameRow = 0;
        const int ArtworkRow = 1;
        const int TextRow = 2;
        const int CardTypeRow = 3;

        const double TextOpacity = 0.7;
        #endregion Constants

        #region DependencyProperties
        public static readonly DependencyProperty CardTextProperty = DependencyProperty.Register("CardText", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardTextChanged));
        public static readonly DependencyProperty CostProperty = DependencyProperty.Register("Cost", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCostChanged));
        public static readonly DependencyProperty CardTypeProperty = DependencyProperty.Register("CardType", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardTypeChanged));
        public static readonly DependencyProperty RaceProperty = DependencyProperty.Register("Races", typeof(Collection<string>), typeof(CardCanvas), new PropertyMetadata(OnRaceChanged));
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

        public bool Tapped
        {
            get { return (bool)GetValue(TappedProperty); }
            set { SetValue(TappedProperty, value); }
        }
        #endregion Other properties

        #region Fields
        private TextBox _textBoxCardText = new TextBox() { TextWrapping = TextWrapping.Wrap, IsReadOnly = true, VerticalScrollBarVisibility = ScrollBarVisibility.Auto, Opacity = TextOpacity, FontFamily = new FontFamily("Microsoft Sans Serif") };
        private TextBox _textBoxCost = new TextBox() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Background = Brushes.Black, Foreground = Brushes.White, FontWeight = FontWeights.Bold };
        private TextBox _textBoxCardType = new TextBox() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Opacity = TextOpacity };
        private TextBox _textBoxRace = new TextBox() { HorizontalAlignment = HorizontalAlignment.Right, VerticalAlignment = VerticalAlignment.Center, Visibility = Visibility.Hidden, Opacity = TextOpacity };
        #endregion Fields

        public CardCanvas()
        {
            Grid gridCostAndName = new Grid();
            gridCostAndName.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.2, GridUnitType.Star) });
            gridCostAndName.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.8, GridUnitType.Star) });
            gridCostAndName.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(_textBoxCost, 0);
            Grid.SetRow(_textBoxCost, 0);
            gridCostAndName.Children.Add(_textBoxCost);

            Grid.SetColumn(TextBoxCardName, 1);
            Grid.SetRow(TextBoxCardName, 0);
            gridCostAndName.Children.Add(TextBoxCardName);

            MainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            MainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionCardName", Height = new GridLength(0.1, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionArtwork", Height = new GridLength(0.3, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionTextRow", Height = new GridLength(0.4, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionCardType", Height = new GridLength(0.1, GridUnitType.Star) });

            Grid.SetColumn(gridCostAndName, 0);
            Grid.SetRow(gridCostAndName, CardNameRow);
            MainGrid.Children.Add(gridCostAndName);

            Grid.SetColumn(Artwork, 0);
            Grid.SetRow(Artwork, ArtworkRow);
            MainGrid.Children.Add(Artwork);

            Grid.SetColumn(_textBoxCardText, 0);
            Grid.SetRow(_textBoxCardText, TextRow);
            MainGrid.Children.Add(_textBoxCardText);

            Grid gridType = new Grid();
            gridType.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            gridType.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            gridType.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            gridType.RowDefinitions.Add(new RowDefinition());

            Grid.SetColumn(TextBoxPower, 0);
            Grid.SetRow(TextBoxPower, CardTypeRow);
            gridType.Children.Add(TextBoxPower);

            Grid.SetColumn(_textBoxCardType, 1);
            Grid.SetRow(_textBoxCardType, CardTypeRow);
            gridType.Children.Add(_textBoxCardType);

            Grid.SetColumn(_textBoxRace, 2);
            Grid.SetRow(_textBoxRace, CardTypeRow);
            gridType.Children.Add(_textBoxRace);

            Grid.SetColumn(gridType, 0);
            Grid.SetRow(gridType, CardTypeRow);
            MainGrid.Children.Add(gridType);

            SizeChanged += CardCanvas_SizeChanged;
        }

        #region Events
        private void CardCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AdjustSize(e.NewSize.Width, e.NewSize.Height, e.NewSize.Height * 222 / 307, e.NewSize.Height);

            const double FontScale = 0.06;
            double fontSize = Math.Max(MinimumFontSize, e.NewSize.Height * FontScale);
            _textBoxCardText.FontSize = fontSize;
            _textBoxCost.FontSize = fontSize;

            const double FontScaleCardType = 0.04;
            double fontSizeCardType = Math.Max(MinimumFontSize, e.NewSize.Height * FontScaleCardType);
            _textBoxCardType.FontSize = fontSizeCardType;
            _textBoxRace.FontSize = fontSizeCardType;
        }

        private static void OnCardTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas)._textBoxCardText.Text = e.NewValue.ToString();
        }

        private static void OnCostChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas)._textBoxCost.Text = e.NewValue.ToString();
        }

        private static void OnCardTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas)._textBoxCardType.Text = e.NewValue.ToString();
        }

        private static void OnRaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardCanvas canvas = d as CardCanvas;
            string raceText = string.Join("/", (Collection<string>)e.NewValue);
            if (!string.IsNullOrEmpty(raceText))
            {
                canvas._textBoxRace.Visibility = Visibility.Visible;
                canvas._textBoxRace.Text = raceText;
            }
        }
        #endregion Events
    }
}
