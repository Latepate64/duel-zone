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
        private const int CornerRadius = 5;
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
        public static readonly DependencyProperty CivilizationProperty = DependencyProperty.Register("Civilizations", typeof(Collection<Civilization>), typeof(AbstractCardCanvas), new PropertyMetadata(OnCivilizationsChanged));
        public static readonly DependencyProperty GameIdProperty = DependencyProperty.Register("GameId", typeof(int), typeof(AbstractCardCanvas));
        public static readonly DependencyProperty CandidateGameIdsProperty = DependencyProperty.Register("CandidateGameIds", typeof(Collection<int>), typeof(AbstractCardCanvas), new PropertyMetadata(OnCandidateGameIdsChanged));
        public static readonly DependencyProperty SelectedGameIdsProperty = DependencyProperty.Register("SelectedGameIds", typeof(Collection<int>), typeof(AbstractCardCanvas), new PropertyMetadata(OnSelectedGameIdsChanged));
        public static readonly DependencyProperty CardNameProperty = DependencyProperty.Register("CardName", typeof(string), typeof(AbstractCardCanvas), new PropertyMetadata(OnCardNameChanged));
        public static readonly DependencyProperty PowerProperty = DependencyProperty.Register("Power", typeof(string), typeof(AbstractCardCanvas), new PropertyMetadata(OnPowerChanged));
        public static readonly DependencyProperty TappedProperty = DependencyProperty.Register("Tapped", typeof(bool), typeof(AbstractCardCanvas), new PropertyMetadata(OnTapStatusChanged));
        public static readonly DependencyProperty SetAndIdProperty = DependencyProperty.Register("SetAndId", typeof(SetAndId), typeof(AbstractCardCanvas), new PropertyMetadata(OnSetAndIdChanged));
        #endregion DependencyProperties

        #region Properties
        protected Grid MainGrid = new Grid();

        /// <summary>
        /// The background frame of the card that is (usually) painted black.
        /// </summary>
        protected Rectangle RectangleCardFrame = new Rectangle() { Fill = new SolidColorBrush(Colors.Black), RadiusX = CornerRadius, RadiusY = CornerRadius };

        /// <summary>
        /// A canvas for the card frame which contains elements for the card object.
        /// </summary>
        protected Canvas CanvasFrame = new Canvas();

        protected TextBlock TextBoxCardName = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Top, FontFamily = new FontFamily("Microsoft Sans Serif"), FontWeight = FontWeights.Bold };
        protected Image Artwork = new Image() { Stretch = Stretch.Fill };
        protected TextBlock TextBoxPower = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center, Visibility = Visibility.Hidden, FontFamily = new FontFamily("Microsoft Sans Serif"), FontWeight = FontWeights.Bold, Foreground = Brushes.White };

        public int GameId
        {
            get { return (int)GetValue(GameIdProperty); }
            set { SetValue(GameIdProperty, value); }
        }
        #endregion Properties

        private bool _candidate;
        
        protected AbstractCardCanvas()
        {
            CanvasFrame.Children.Add(MainGrid);

            Children.Add(RectangleCardFrame);
            Children.Add(CanvasFrame);

            DoubleAnimation loadedAnimation = new DoubleAnimation(0.0, 1.0, new Duration(new TimeSpan(0, 0, 0, 1, 5)));
            Storyboard.SetTargetProperty(loadedAnimation, new PropertyPath(OpacityProperty));
            EventTrigger eventTrigger = new EventTrigger(LoadedEvent);
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(loadedAnimation);
            eventTrigger.Actions.Add(new BeginStoryboard() { Storyboard = storyboard });
            Triggers.Add(eventTrigger);
        }

        #region Events
        private static void OnCivilizationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AbstractCardCanvas canvas = d as AbstractCardCanvas;
            Collection<Civilization> civilizations = e.NewValue as Collection<Civilization>;
            if (civilizations.Count == 1)
            {
                canvas.MainGrid.Background = new SolidColorBrush(_civilizationDictionary[civilizations[0]]);
            }
            else if (civilizations.Count == 2)
            {
                List<Color> brushes = new List<Color>();
                foreach (Civilization civilization in civilizations)
                {
                    brushes.Add(_civilizationDictionary[civilization]);
                }
                canvas.MainGrid.Background = new LinearGradientBrush(brushes[0], brushes[1], 45);
            }
            else
            {
                throw new Exception();
            }
        }

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
            string power = e.NewValue.ToString();
            if (!string.IsNullOrEmpty(power))
            {
                canvas.TextBoxPower.Visibility = Visibility.Visible;
                canvas.TextBoxPower.Text = power;
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
            (d as AbstractCardCanvas).Artwork.Source = new BitmapImage(new Uri(path));
        }
        #endregion Events

        private void BeginCandidateAnimation()
        {
            var colorAnimation = new ColorAnimation(Colors.Black, Colors.White, new Duration(new TimeSpan(0, 0, 0, 1, 0)))
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

            MainGrid.Width = frameWidth - frameWidth * FrameOffset;
            MainGrid.Height = frameHeight - frameHeight * FrameOffset;

            SetLeft(MainGrid, (frameWidth - MainGrid.Width) / 2);
            SetTop(MainGrid, (frameHeight - MainGrid.Height) / 2);

            const double FontScale = 0.07;
            double fontSize = Math.Max(MinimumFontSize, cardCanvasHeight * FontScale);
            TextBoxCardName.FontSize = fontSize;

            const double FontScalePower = 0.12;
            double fontSizeCardType = Math.Max(MinimumFontSize, cardCanvasHeight * FontScalePower);
            TextBoxPower.FontSize = fontSizeCardType;
        }
    }
}
