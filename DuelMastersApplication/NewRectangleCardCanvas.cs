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
using System.Windows.Shapes;

namespace DuelMastersApplication
{
    public abstract class NewRectangleCardCanvas : NewAbstractCardCanvas
    {
        private string _cardName;
        public string CardName 
        { 
            get { return _cardName; }
            private set
            {
                _cardName = value;
                TextBoxCardName.Text = value;
            }
        }

        private string _power;
        public string Power 
        { 
            get { return _power; }
            private set
            {
                _power = value;
                if (!string.IsNullOrEmpty(value))
                {
                    TextBoxPower.Visibility = Visibility.Visible;
                    TextBoxPower.Text = value;
                    DoubleAnimation animation = new DoubleAnimation(0, 1, new Duration(new TimeSpan(0, 0, 3)))
                    {
                        RepeatBehavior = new RepeatBehavior(1),
                    };
                    TextBoxPower.BeginAnimation(OpacityProperty, animation);
                    TextBoxPower.BeginAnimation(OpacityProperty, animation);
                }
                else
                {
                    TextBoxPower.Visibility = Visibility.Hidden;
                }
            }
        }

        #region Protected properties
        /// <summary>
        /// The background frame of the card that is (usually) painted black.
        /// </summary>
        protected Rectangle RectangleCardFrame = new Rectangle() { Fill = new SolidColorBrush(Colors.Black) };
        protected TextBox TextBoxCardName = new TextBox() { HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, FontFamily = new FontFamily("Microsoft Sans Serif"), FontWeight = FontWeights.Bold, Background = Brushes.Transparent, Cursor = System.Windows.Input.Cursors.Arrow, Focusable = false, BorderThickness = new Thickness(0) };
        protected TextBlock TextBoxPower = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Visibility = Visibility.Hidden, FontFamily = new FontFamily("Microsoft Sans Serif"), FontWeight = FontWeights.Bold, Foreground = Brushes.White };
        protected Rectangle RectangleColorFrame = new Rectangle();
        #endregion Protected properties

        protected NewRectangleCardCanvas(MainWindow mainWindow, Card card) : base(mainWindow, card.GameId, card.Set, card.Id)
        {
            CardName = card.Name;
            if (card is Creature creature)
            {
                Power = creature.Power.ToString();
            }
            Children.Add(RectangleCardFrame);
            Children.Add(CanvasFrame);
        }

        public void AdjustCardNameSize(double frameWidth, double frameHeight, double fontScale = 0.09, double yPositionScale = 0.0875)
        {
            TextBoxCardName.Width = 0.69 * Width;
            TextBoxCardName.Height = 0.1 * Height;

            double fontSize = Math.Max(MinimumFontSize, frameWidth * fontScale);
            TextBoxCardName.FontSize = fontSize;

            while (true)
            {
                double nameWidth = MeasureString(TextBoxCardName.Text, TextBoxCardName.FontSize, frameWidth, frameHeight, TextBoxCardName.FontWeight, TextBoxCardName.FontStyle, TextBoxCardName.FontFamily).Width;
                if (nameWidth < 0.985 * TextBoxCardName.Width)
                {
                    break;
                }
                else
                {
                    TextBoxCardName.FontSize = 0.99 * TextBoxCardName.FontSize;
                }
            }

            SetLeft(TextBoxCardName, (CanvasFrame.Width - TextBoxCardName.Width) / 2);
            SetTop(TextBoxCardName, 0.085 * frameHeight - TextBoxCardName.Height / 2);
        }

        protected void AdjustSize(double cardCanvasWidth, double cardCanvasHeight, double frameWidth, double frameHeight)
        {
            RectangleCardFrame.Width = frameWidth;
            RectangleCardFrame.Height = frameHeight;
            SetLeft(RectangleCardFrame, (cardCanvasWidth - frameWidth) / 2);
            SetTop(RectangleCardFrame, (cardCanvasHeight - frameHeight) / 2);

            CanvasFrame.Width = frameWidth;
            CanvasFrame.Height = frameHeight;
            SetLeft(CanvasFrame, (cardCanvasWidth - frameWidth) / 2);
            SetTop(CanvasFrame, (cardCanvasHeight - frameHeight) / 2);

            RectangleCardFrame.RadiusX = 0.03 * cardCanvasWidth;
            RectangleCardFrame.RadiusY = RectangleCardFrame.RadiusX;
        }
    }
}
