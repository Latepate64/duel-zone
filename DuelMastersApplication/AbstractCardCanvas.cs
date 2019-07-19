using DuelMastersModels.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuelMastersApplication
{
    public abstract class AbstractCardCanvas : Canvas
    {
        #region Constants
        private const double UntappedDegree = 0.0;
        private const double TappedDegree = 10.0;

        protected const double MinimumFontSize = 9;
        protected const double FrameOffset = 0.07;
        #endregion Constants

        private static readonly Dictionary<Civilization, Color> _civilizationDictionary = new Dictionary<Civilization, Color>()
        {
            { Civilization.Light, Color.FromRgb(250, 250, 140) },
            { Civilization.Water, Color.FromRgb(120, 180, 215) },
            { Civilization.Darkness, Color.FromRgb(75, 75, 75) },
            { Civilization.Fire, Color.FromRgb(210, 35, 40) },
            { Civilization.Nature, Color.FromRgb(80, 100, 50) },
        };

        #region DependencyProperties
        public static readonly DependencyProperty GameIdProperty = DependencyProperty.Register("GameId", typeof(int), typeof(AbstractCardCanvas));
        public static readonly DependencyProperty CandidateGameIdsProperty = DependencyProperty.Register("CandidateGameIds", typeof(Collection<int>), typeof(AbstractCardCanvas), new PropertyMetadata(OnCandidateGameIdsChanged));
        public static readonly DependencyProperty SelectedGameIdsProperty = DependencyProperty.Register("SelectedGameIds", typeof(Collection<int>), typeof(AbstractCardCanvas), new PropertyMetadata(OnSelectedGameIdsChanged));
        public static readonly DependencyProperty CardNameProperty = DependencyProperty.Register("CardName", typeof(string), typeof(AbstractCardCanvas), new PropertyMetadata(OnCardNameChanged));
        public static readonly DependencyProperty PowerProperty = DependencyProperty.Register("Power", typeof(string), typeof(AbstractCardCanvas), new PropertyMetadata(OnPowerChanged));
        public static readonly DependencyProperty TappedProperty = DependencyProperty.Register("Tapped", typeof(bool), typeof(AbstractCardCanvas), new PropertyMetadata(OnTapStatusChanged));
        public static readonly DependencyProperty SetAndIdProperty = DependencyProperty.Register("SetAndId", typeof(SetAndId), typeof(AbstractCardCanvas), new PropertyMetadata(OnSetAndIdChanged));
        public static readonly DependencyProperty MainWindowProperty = DependencyProperty.Register("MainWindow", typeof(MainWindow), typeof(AbstractCardCanvas));
        #endregion DependencyProperties

        #region Properties
        /// <summary>
        /// The background frame of the card that is (usually) painted black.
        /// </summary>
        protected Rectangle RectangleCardFrame = new Rectangle() { Fill = new SolidColorBrush(Colors.Black) };

        /// <summary>
        /// A canvas for the card frame which contains elements for the card object.
        /// </summary>
        protected Canvas CanvasFrame = new Canvas();

        protected TextBox TextBoxCardName = new TextBox() { HorizontalContentAlignment = HorizontalAlignment.Center, VerticalContentAlignment = VerticalAlignment.Center, FontFamily = new FontFamily("Microsoft Sans Serif"), FontWeight = FontWeights.Bold, Background = Brushes.Transparent, Cursor = System.Windows.Input.Cursors.Arrow, Focusable = false, BorderThickness = new Thickness(0) };
        protected Image Artwork = new Image();
        protected TextBlock TextBoxPower = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Visibility = Visibility.Hidden, FontFamily = new FontFamily("Microsoft Sans Serif"), FontWeight = FontWeights.Bold, Foreground = Brushes.White };
        protected Rectangle _rectangleColorFrame = new Rectangle();

        public int GameId
        {
            get { return (int)GetValue(GameIdProperty); }
            set { SetValue(GameIdProperty, value); }
        }

        public MainWindow MainWindow
        {
            get { return (MainWindow)GetValue(MainWindowProperty); }
            set { SetValue(MainWindowProperty, value); }
        }
        #endregion Properties

        private bool _candidate;
        
        protected AbstractCardCanvas()
        {
            Children.Add(RectangleCardFrame);
            Children.Add(CanvasFrame);

            DoubleAnimation loadedAnimation = new DoubleAnimation(0.0, 1.0, new Duration(new TimeSpan(0, 0, 0, 1, 5)));
            Storyboard.SetTargetProperty(loadedAnimation, new PropertyPath(OpacityProperty));
            EventTrigger eventTrigger = new EventTrigger(LoadedEvent);
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(loadedAnimation);
            eventTrigger.Actions.Add(new BeginStoryboard() { Storyboard = storyboard });
            Triggers.Add(eventTrigger);

            MouseEnter += AbstractCardCanvas_MouseEnter;
            MouseLeave += AbstractCardCanvas_MouseLeave;
        }

        protected static Brush GetBrushForCivilizations(Collection<Civilization> civilizations)
        {
            if (civilizations.Count == 1)
            {
                return new SolidColorBrush(_civilizationDictionary[civilizations[0]]);
            }
            else if (civilizations.Count == 2)
            {
                List<Color> brushes = new List<Color>();
                foreach (Civilization civilization in civilizations)
                {
                    brushes.Add(_civilizationDictionary[civilization]);
                }
                return new LinearGradientBrush(brushes[0], brushes[1], 45);
            }
            else
            {
                throw new Exception();
            }
        }

        private void AbstractCardCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindow?.ZoomCardCanvas(GameId);
        }

        private void AbstractCardCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindow?.UnzoomCardCanvas();
        }

        #region Events
        private static void OnCandidateGameIdsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AbstractCardCanvas canvas = d as AbstractCardCanvas;
            Collection<int> gameIds = (Collection<int>)e.NewValue;
            if (gameIds.Contains(canvas.GameId))
            {
                canvas.BeginCandidateAnimation();
                canvas._candidate = true;
            }
            else
            {
                canvas.RectangleCardFrame.Fill.BeginAnimation(SolidColorBrush.ColorProperty, null);
                canvas._candidate = false;
            }
        }

        private static void OnSelectedGameIdsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as AbstractCardCanvas).OnSelectedGameIdsChanged(e);
        }

        private void OnSelectedGameIdsChanged(DependencyPropertyChangedEventArgs e)
        {
            Collection<int> gameIds = (Collection<int>)e.NewValue;
            if (gameIds.Contains(GameId))
            {
                ColorAnimation colorAnimation = new ColorAnimation(Colors.White, Colors.Red, new Duration(new TimeSpan(0, 0, 0, 0, 250)))
                {
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever,
                };
                RectangleCardFrame.Fill.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            }
            else if (_candidate)
            {
                BeginCandidateAnimation();
            }
            else
            {
                RectangleCardFrame.Fill.BeginAnimation(SolidColorBrush.ColorProperty, null);
            }
        }

        private static void OnCardNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as AbstractCardCanvas).TextBoxCardName.Text = e.NewValue.ToString();
        }

        private static void OnPowerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AbstractCardCanvas canvas = d as AbstractCardCanvas;
            if (e.NewValue != null)
            {
                string power = e.NewValue.ToString();
                if (!string.IsNullOrEmpty(power))
                {
                    canvas.TextBoxPower.Visibility = Visibility.Visible;
                    canvas.TextBoxPower.Text = power;
                }
            }
            else
            {
                canvas.TextBoxPower.Visibility = Visibility.Hidden;
            }
        }

        private static void OnTapStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AbstractCardCanvas canvas = d as AbstractCardCanvas;
            bool tapped = (bool)e.NewValue;
            if (tapped != (bool)e.OldValue)
            {
                double fromValue = UntappedDegree;
                double toValue = TappedDegree;
                if (!tapped)
                {
                    fromValue = TappedDegree;
                    toValue = UntappedDegree;
                }
                canvas.RenderTransform = new RotateTransform(0, canvas.Height / 2, canvas.Height / 2);
                DoubleAnimation animation = new DoubleAnimation(fromValue, toValue, new Duration(new TimeSpan(0, 0, 0, 0, 500)))
                {
                    RepeatBehavior = new RepeatBehavior(1)
                };
                canvas.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, animation);
            }
        }

        private static void OnSetAndIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            const string RootPath = "C:/DuelMastersCardImages";
            SetAndId setAndId = (SetAndId)e.NewValue;
            string path = System.IO.Path.Combine(RootPath, setAndId.Set, string.Format("{0} {1}.jpg", setAndId.Set, setAndId.Id));
            if (System.IO.File.Exists(path))
            {
                (d as AbstractCardCanvas).Artwork.Source = new BitmapImage(new Uri(path));
            }
            else
            {
                (d as AbstractCardCanvas).Artwork.Source = null;
            }
        }
        #endregion Events

        private void BeginCandidateAnimation()
        {
            ColorAnimation colorAnimation = new ColorAnimation(Colors.Black, Colors.White, new Duration(new TimeSpan(0, 0, 0, 1, 0)))
            {
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
            };
            RectangleCardFrame.Fill.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
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

        protected Size MeasureString(string text, double fontSize, double width, double height, FontWeight fontWeight, FontStyle fontStyle, FontFamily fontFamily)
        {
            TextBlock textBlock = new TextBlock { Text = text, TextWrapping = TextWrapping.NoWrap, FontSize = fontSize, FontWeight = fontWeight, FontStyle = fontStyle, FontFamily = fontFamily };
            textBlock.Measure(new Size(width, height));
            textBlock.Arrange(new Rect(textBlock.DesiredSize));
            return textBlock.RenderSize;
        }
    }
}
