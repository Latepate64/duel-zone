﻿using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
        #endregion Constants

        #region DependencyProperties
        public static readonly DependencyProperty CardNameProperty = DependencyProperty.Register("CardName", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardNameChanged));

        public static readonly DependencyProperty CivilizationProperty = DependencyProperty.Register("Civilizations", typeof(Collection<Civilization>), typeof(CardCanvas), new PropertyMetadata(OnCivilizationsChanged));

        public static readonly DependencyProperty SetAndIdProperty = DependencyProperty.Register("SetAndId", typeof(SetAndId), typeof(CardCanvas), new PropertyMetadata(OnSetAndIdChanged));

        public static readonly DependencyProperty CardTextProperty = DependencyProperty.Register("CardText", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardTextChanged));
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

        private Canvas _cardCanvas = new Canvas() { Background = Brushes.Black };
        private Grid _mainGrid = new Grid() { ShowGridLines = true };
        #endregion Fields

        public CardCanvas()
        {
            Grid gridCostAndName = new Grid();
            gridCostAndName.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.2, GridUnitType.Star) });
            gridCostAndName.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.8, GridUnitType.Star) });
            gridCostAndName.RowDefinitions.Add(new RowDefinition());

            /*Grid.SetColumn(, 0);
            Grid.SetRow(, 0);
            gridCostAndName.Children.Add();*/


            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionCardName", Height = new GridLength(0.1, GridUnitType.Star) });
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionArtwork", Height = new GridLength(0.4, GridUnitType.Star) });
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Name = "RowDefinitionTextRow", Height = new GridLength(0.4, GridUnitType.Star) });

            Grid.SetColumn(_textBoxCardName, 0);
            Grid.SetRow(_textBoxCardName, CardNameRow);
            _mainGrid.Children.Add(_textBoxCardName);

            Grid.SetColumn(_artwork, 0);
            Grid.SetRow(_artwork, ArtworkRow);
            _mainGrid.Children.Add(_artwork);

            Grid.SetColumn(_textBoxCardText, 0);
            Grid.SetRow(_textBoxCardText, TextRow);
            _mainGrid.Children.Add(_textBoxCardText);

            _cardCanvas.Children.Add(_mainGrid);
            Children.Add(_cardCanvas);

            SizeChanged += CardCanvas_SizeChanged;
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

            //RenderTransform = new RotateTransform(45, e.NewSize.Height / 2, e.NewSize.Height / 2);
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
            //_labelCardName.Content = e.NewValue.ToString();
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
            var civilizations = e.NewValue as Collection<Civilization>;
            if (civilizations.Count == 1)
            {
                _mainGrid.Background = _civilizationDictionary[civilizations[0]];
            }
            else
            {
                throw new NotImplementedException("Implement multicolor painting");
            }
        }


    }
}
