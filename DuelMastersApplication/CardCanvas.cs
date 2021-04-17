using DuelMastersModels.Cards;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DuelMastersApplication
{
    public struct SetAndId
    {
        public string Set { get; set; }
        public string Id { get; set; }
    }

    public class CardCanvas : RectangleCardCanvas
    {
        #region Constants
        const double TextOpacity = 0.7;
        const double TypeRowHeightScale = 0.93;
        #endregion Constants

        #region DependencyProperties
        public static readonly DependencyProperty CardTextProperty = DependencyProperty.Register("CardText", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardTextChanged));
        public static readonly DependencyProperty CostProperty = DependencyProperty.Register("Cost", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCostChanged));
        public static readonly DependencyProperty CardTypeProperty = DependencyProperty.Register("CardType", typeof(string), typeof(CardCanvas), new PropertyMetadata(OnCardTypeChanged));
        public static readonly DependencyProperty RaceProperty = DependencyProperty.Register("Races", typeof(Collection<string>), typeof(CardCanvas), new PropertyMetadata(OnRaceChanged));
        public static readonly DependencyProperty CivilizationProperty = DependencyProperty.Register("Civilizations", typeof(ReadOnlyCivilizationCollection), typeof(CardCanvas), new PropertyMetadata(OnCivilizationsChanged));
        public static readonly DependencyProperty KnownToPlayerWithPriorityProperty = DependencyProperty.Register("KnownToPlayerWithPriority", typeof(bool), typeof(CardCanvas), new PropertyMetadata(OnKnownToPlayerWithPriorityChanged));
        public static readonly DependencyProperty KnownToPlayerWithoutPriorityProperty = DependencyProperty.Register("KnownToPlayerWithoutPriority", typeof(bool), typeof(CardCanvas), new PropertyMetadata(OnKnownToPlayerWithoutPriorityChanged));
        #endregion DependencyProperties

        #region Other properties
        public ReadOnlyCivilizationCollection Civilizations
        {
            get { return (ReadOnlyCivilizationCollection)GetValue(CivilizationProperty); }
            set { SetValue(CivilizationProperty, value); }
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

        public bool KnownToPlayerWithPriority
        {
            get { return (bool)GetValue(KnownToPlayerWithPriorityProperty); }
            set { SetValue(KnownToPlayerWithPriorityProperty, value); }
        }
        #endregion Other properties

        #region Fields
        private TextBox _textBoxCardText = new TextBox() { TextWrapping = TextWrapping.Wrap, VerticalScrollBarVisibility = ScrollBarVisibility.Hidden, Opacity = TextOpacity, FontFamily = new FontFamily("Microsoft Sans Serif"), Cursor = System.Windows.Input.Cursors.Arrow, Focusable = false };
        private TextBox _textBoxCost = new TextBox() { HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Top, Background = Brushes.Black, Foreground = Brushes.White, FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0) };
        private TextBox _textBoxCardType = new TextBox() { Opacity = TextOpacity, HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, Background = Brushes.Transparent, FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0), Cursor = System.Windows.Input.Cursors.Arrow, Focusable = false };
        private TextBox _textBoxRace = new TextBox() { HorizontalContentAlignment = HorizontalAlignment.Right, VerticalContentAlignment = VerticalAlignment.Center, Visibility = Visibility.Hidden, Opacity = TextOpacity, Cursor = System.Windows.Input.Cursors.Arrow, Focusable = false, Background = Brushes.Transparent, FontWeight = FontWeights.Bold, BorderThickness = new Thickness(0), };
        private Image _imageCardBack = new Image()
        {
            Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("../../Images/card_back.png", UriKind.Relative)),
            Stretch = Stretch.Fill,
        };
        private Image _imageKnownToPlayerWithoutPriority = new Image()
        {
            Opacity = 0.0,
            Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("../../Images/eye.png", UriKind.Relative)),
            Stretch = Stretch.Fill,
        };
        #endregion Fields

        public CardCanvas()
        {
            SizeChanged += CardCanvas_SizeChanged;

            CanvasFrame.Children.Add(RectangleColorFrame);
            CanvasFrame.Children.Add(_textBoxCost);
            CanvasFrame.Children.Add(Artwork);
            CanvasFrame.Children.Add(TextBoxCardName);
            CanvasFrame.Children.Add(_textBoxCardText);
            CanvasFrame.Children.Add(TextBoxPower);
            CanvasFrame.Children.Add(_textBoxCardType);
            CanvasFrame.Children.Add(_textBoxRace);
            CanvasFrame.Children.Add(_imageCardBack);
            CanvasFrame.Children.Add(_imageKnownToPlayerWithoutPriority);

            _textBoxCost.SetBinding(Control.BackgroundProperty, new System.Windows.Data.Binding("Fill") { Source = RectangleCardFrame });

            MouseEnter -= AbstractCardCanvas_MouseEnter;
            MouseLeave -= AbstractCardCanvas_MouseLeave;
        }

        #region Events
        private void CardCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double frameWidth = e.NewSize.Width;
            double frameHeight = e.NewSize.Height;
            AdjustSize(frameWidth, frameHeight, frameWidth, frameHeight);

            const double FontScaleCardType = 0.04;
            double fontSizeCardType = Math.Max(MinimumFontSize, frameHeight * FontScaleCardType);
            _textBoxCardType.FontSize = fontSizeCardType;
            _textBoxRace.FontSize = 0.7 * fontSizeCardType;

            RectangleColorFrame.Width = CanvasFrame.Width * (1 - FrameOffset);
            RectangleColorFrame.Height = CanvasFrame.Height * (1 - FrameOffset);
            SetLeft(RectangleColorFrame, (frameWidth - RectangleColorFrame.Width) / 2);
            SetTop(RectangleColorFrame, (frameHeight - RectangleColorFrame.Height) / 2);

            _textBoxCost.FontSize = frameHeight * 0.07;

            double costLength = CanvasFrame.Width * 0.115;
            _textBoxCost.Width = costLength;
            _textBoxCost.Height = costLength;

            double leftAndTop = (frameWidth - RectangleColorFrame.Width) / 2;

            SetLeft(_textBoxCost, leftAndTop);
            SetTop(_textBoxCost, leftAndTop);

            AdjustCardNameSize(frameWidth, frameHeight);

            Artwork.Width = RectangleColorFrame.Width;
            Artwork.Height = 0.48 * frameHeight;
            SetLeft(Artwork, (CanvasFrame.Width - RectangleColorFrame.Width) / 2);
            SetTop(Artwork, 0.14 * frameHeight);

            const double FontScale = 0.029;
            double fontSize = frameHeight * FontScale;
            _textBoxCardText.FontSize = fontSize;

            _textBoxCardText.Width = CanvasFrame.Width * (1 - 2 * FrameOffset);
            _textBoxCardText.Height = 0.27 * frameHeight;
            SetLeft(_textBoxCardText, 0.07 * frameWidth);
            SetTop(_textBoxCardText, 0.63 * frameHeight);

            double typeRowHeight = TypeRowHeightScale * frameHeight; 

            const double FontScalePower = 0.06;
            double fontSizePower = Math.Max(MinimumFontSize, Height * FontScalePower);
            TextBoxPower.FontSize = fontSizePower;

            TextBoxPower.Measure(new Size(frameWidth, 0.2 * frameHeight));
            TextBoxPower.Arrange(new Rect(TextBoxPower.DesiredSize));
            SetLeft(TextBoxPower, 0.05 * frameWidth);
            SetTop(TextBoxPower, typeRowHeight - TextBoxPower.ActualHeight / 2);

            _textBoxCardType.Width = 0.3 * frameWidth;
            _textBoxCardType.Height = TextBoxPower.ActualHeight;
            SetLeft(_textBoxCardType, (CanvasFrame.Width - _textBoxCardType.Width) / 2);
            SetTop(_textBoxCardType, typeRowHeight - _textBoxCardType.Height / 2);

            AdjustRaceSize(frameWidth, frameHeight);

            _imageCardBack.Width = CanvasFrame.Width * (1 - FrameOffset);
            _imageCardBack.Height = CanvasFrame.Height * (1 - FrameOffset);
            SetLeft(_imageCardBack, (frameWidth - _imageCardBack.Width) / 2);
            SetTop(_imageCardBack, (frameHeight - _imageCardBack.Height) / 2);

            _imageKnownToPlayerWithoutPriority.Width = 0.7 * CanvasFrame.Width;
            _imageKnownToPlayerWithoutPriority.Height = 0.3 * CanvasFrame.Height;
            SetLeft(_imageKnownToPlayerWithoutPriority, (frameWidth - _imageKnownToPlayerWithoutPriority.Width) / 2);
            SetTop(_imageKnownToPlayerWithoutPriority, (frameHeight - _imageKnownToPlayerWithoutPriority.Height) / 2);
        }

        public void AdjustRaceSize(double frameWidth, double frameHeight)
        {
            double typeRowHeight = TypeRowHeightScale * Height;
            _textBoxRace.Width = 0.32 * Width;
            _textBoxRace.Height = TextBoxPower.ActualHeight;

            while (true)
            {
                double raceWidth = MeasureString(_textBoxRace.Text, _textBoxRace.FontSize, frameWidth, frameHeight, _textBoxRace.FontWeight, _textBoxRace.FontStyle, _textBoxRace.FontFamily).Width;
                if (raceWidth < 0.95 * _textBoxRace.Width)
                {
                    break;
                }
                else
                {
                    _textBoxRace.FontSize = 0.99 * _textBoxRace.FontSize;
                }
            }

            SetLeft(_textBoxRace, 0.95 * CanvasFrame.Width - _textBoxRace.Width);
            SetTop(_textBoxRace, typeRowHeight - _textBoxRace.Height / 2);
        }

        private static void OnCardTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                string cardText = e.NewValue.ToString();
                if (!string.IsNullOrEmpty(cardText))
                {
                    string newCardText = System.Text.RegularExpressions.Regex.Replace(cardText, "\\(.*?\\)", string.Empty);
                    if (newCardText.StartsWith("\n"))
                    {
                        newCardText.Remove(0, 2);
                    }
                    if (!string.IsNullOrEmpty(newCardText))
                    {
                        newCardText = "■ " + newCardText.Replace("\n", "\n■ ");
                        newCardText = newCardText.Replace("■ \n", string.Empty);
                    }
                    (d as CardCanvas)._textBoxCardText.Text = newCardText;
                }
            }
        }

        private static void OnCostChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas)._textBoxCost.Text = e.NewValue.ToString();
        }

        private static void OnCardTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardCanvas canvas = d as CardCanvas;
            string cardType = e.NewValue.ToString();
            canvas._textBoxCardType.Text = cardType;
            if (cardType.Contains("Creature"))
            {
                canvas.Artwork.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else if (cardType == "Spell")
            {
                canvas.Artwork.HorizontalAlignment = HorizontalAlignment.Center;
            }
        }

        private static void OnRaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardCanvas canvas = d as CardCanvas;
            if (e.NewValue != null)
            {
                string raceText = string.Join("/", (Collection<string>)e.NewValue);
                if (!string.IsNullOrEmpty(raceText))
                {
                    canvas._textBoxRace.Visibility = Visibility.Visible;
                    canvas._textBoxRace.Text = raceText;
                }
            }
            else
            {
                canvas._textBoxRace.Visibility = Visibility.Hidden;
            }
        }

        private static void OnCivilizationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as CardCanvas).RectangleColorFrame.Fill = GetBrushForCivilizations(e.NewValue as ReadOnlyCivilizationCollection);
        }

        private static void OnKnownToPlayerWithPriorityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardCanvas canvas = d as CardCanvas;
            bool known = (bool)e.NewValue;
            if (known)
            {
                canvas._imageCardBack.Visibility = Visibility.Hidden;
                canvas.MouseEnter += canvas.AbstractCardCanvas_MouseEnter;
                canvas.MouseLeave += canvas.AbstractCardCanvas_MouseLeave;
            }
            else
            {
                canvas._imageCardBack.Visibility = Visibility.Visible;
                canvas.MouseEnter -= canvas.AbstractCardCanvas_MouseEnter;
                canvas.MouseLeave -= canvas.AbstractCardCanvas_MouseLeave;
            }
        }

        private static void OnKnownToPlayerWithoutPriorityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CardCanvas canvas = d as CardCanvas;
            bool known = (bool)e.NewValue;
            if (known)
            {

                DoubleAnimation doubleAnimation = new DoubleAnimation(1.0, 0.0, new Duration(new TimeSpan(0, 0, 1)))
                {
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever,
                };
                canvas._imageKnownToPlayerWithoutPriority.BeginAnimation(OpacityProperty, doubleAnimation);
            }
            else
            {
                canvas._imageKnownToPlayerWithoutPriority.BeginAnimation(OpacityProperty, null);
            }
        }
        #endregion Events
    }
}
