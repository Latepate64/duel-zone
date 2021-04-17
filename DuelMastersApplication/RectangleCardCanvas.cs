using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DuelMastersApplication
{
    public abstract class RectangleCardCanvas : AbstractCardCanvas
    {
        public static readonly DependencyProperty CardNameProperty = DependencyProperty.Register("CardName", typeof(string), typeof(RectangleCardCanvas), new PropertyMetadata(OnCardNameChanged));
        public static readonly DependencyProperty PowerProperty = DependencyProperty.Register("Power", typeof(string), typeof(RectangleCardCanvas), new PropertyMetadata(OnPowerChanged));

        /// <summary>
        /// The background frame of the card that is (usually) painted black.
        /// </summary>
        protected Rectangle RectangleCardFrame = new Rectangle() { Fill = new SolidColorBrush(Colors.Black) };
        protected TextBox TextBoxCardName = new TextBox() { HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, FontFamily = new FontFamily("Microsoft Sans Serif"), FontWeight = FontWeights.Bold, Background = Brushes.Transparent, Cursor = System.Windows.Input.Cursors.Arrow, Focusable = false, BorderThickness = new Thickness(0) };
        protected TextBlock TextBoxPower = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Visibility = Visibility.Hidden, FontFamily = new FontFamily("Microsoft Sans Serif"), FontWeight = FontWeights.Bold, Foreground = Brushes.White };
        protected Rectangle RectangleColorFrame = new Rectangle();

        static RectangleCardCanvas()
        {
            CandidateGameIdsProperty.OverrideMetadata(typeof(RectangleCardCanvas), new PropertyMetadata(OnCandidateGameIdsChanged));
            SelectedGameIdsProperty.OverrideMetadata(typeof(RectangleCardCanvas), new PropertyMetadata(OnSelectedGameIdsChanged));
        }

        protected RectangleCardCanvas()
        {
            Children.Add(RectangleCardFrame);
            Children.Add(CanvasFrame);
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

        #region Events
        private static void OnCardNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RectangleCardCanvas).TextBoxCardName.Text = e.NewValue.ToString();
        }

        private static void OnPowerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RectangleCardCanvas canvas = d as RectangleCardCanvas;
            if (e.NewValue != null)
            {
                string power = e.NewValue.ToString();
                if (!string.IsNullOrEmpty(power))
                {
                    canvas.TextBoxPower.Visibility = Visibility.Visible;
                    canvas.TextBoxPower.Text = power;
                }
                canvas.TextBoxPower.BeginAnimation(OpacityProperty, GetPowerAnimation(canvas.TextBoxPower.ActualWidth));
                canvas.TextBoxPower.BeginAnimation(OpacityProperty, GetPowerAnimation(canvas.TextBoxPower.ActualHeight));
            }
            else
            {
                canvas.TextBoxPower.Visibility = Visibility.Hidden;
            }
        }

        private static DoubleAnimation GetPowerAnimation(double size)
        {
            if (!double.IsNaN(size))
            {
                return new DoubleAnimation(/*2 * size, size*/0, 1, new Duration(new TimeSpan(0, 0, 3)))
                {
                    RepeatBehavior = new RepeatBehavior(1),
                };
            }
            else
            {
                return null;
            }
        }

        private static void OnCandidateGameIdsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RectangleCardCanvas canvas = d as RectangleCardCanvas;
            canvas.CandidateGameIdsChanged((Collection<int>)e.NewValue, canvas.RectangleCardFrame);
        }

        private static void OnSelectedGameIdsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as RectangleCardCanvas).OnSelectedGameIdsChanged(e);
        }

        private void OnSelectedGameIdsChanged(DependencyPropertyChangedEventArgs e)
        {
            SelectedGameIdsChanged((Collection<int>)e.NewValue, RectangleCardFrame);
        }
        #endregion Events
    }
}
