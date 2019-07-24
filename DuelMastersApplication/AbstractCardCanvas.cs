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
        public static readonly DependencyProperty TappedProperty = DependencyProperty.Register("Tapped", typeof(bool), typeof(AbstractCardCanvas), new PropertyMetadata(OnTapStatusChanged));
        public static readonly DependencyProperty SetAndIdProperty = DependencyProperty.Register("SetAndId", typeof(SetAndId), typeof(AbstractCardCanvas), new PropertyMetadata(OnSetAndIdChanged));
        public static readonly DependencyProperty MainWindowProperty = DependencyProperty.Register("MainWindow", typeof(MainWindow), typeof(AbstractCardCanvas));

        public static readonly DependencyProperty CandidateGameIdsProperty = DependencyProperty.Register("CandidateGameIds", typeof(Collection<int>), typeof(AbstractCardCanvas));
        public static readonly DependencyProperty SelectedGameIdsProperty = DependencyProperty.Register("SelectedGameIds", typeof(Collection<int>), typeof(AbstractCardCanvas));
        #endregion DependencyProperties

        #region Properties
        /// <summary>
        /// A canvas for the card frame which contains elements for the card object.
        /// </summary>
        protected Canvas CanvasFrame = new Canvas();

        protected Image Artwork = new Image();
        
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

        protected double TappedDegree = 10.0;
        #endregion Properties

        private bool _candidate;

        protected AbstractCardCanvas()
        {
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

        protected void AbstractCardCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindow?.ZoomCardCanvas(GameId);
        }

        protected void AbstractCardCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindow?.UnzoomCardCanvas();
        }

        #region Events
        private static void OnTapStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AbstractCardCanvas canvas = d as AbstractCardCanvas;
            bool tapped = (bool)e.NewValue;
            if (tapped != (bool)e.OldValue)
            {
                double fromValue = UntappedDegree;
                double toValue = canvas.TappedDegree;
                if (!tapped)
                {
                    fromValue = canvas.TappedDegree;
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
            (d as AbstractCardCanvas).Artwork.Source = GetArtwork((SetAndId)e.NewValue);
        }
        #endregion Events

        protected static BitmapImage GetArtwork(SetAndId setAndId)
        {
            const string RootPath = "C:/DuelMastersCardImages";
            string path = System.IO.Path.Combine(RootPath, setAndId.Set, string.Format("{0} {1}.jpg", setAndId.Set, setAndId.Id));
            if (System.IO.File.Exists(path))
            {
                return new BitmapImage(new Uri(path));
            }
            else
            {
                return null;
            }
        }

        protected Size MeasureString(string text, double fontSize, double width, double height, FontWeight fontWeight, FontStyle fontStyle, FontFamily fontFamily)
        {
            TextBlock textBlock = new TextBlock { Text = text, TextWrapping = TextWrapping.NoWrap, FontSize = fontSize, FontWeight = fontWeight, FontStyle = fontStyle, FontFamily = fontFamily };
            textBlock.Measure(new Size(width, height));
            textBlock.Arrange(new Rect(textBlock.DesiredSize));
            return textBlock.RenderSize;
        }

        protected void CandidateGameIdsChanged(Collection<int> gameIds, Shape frameShape)
        {
            if (gameIds.Contains(GameId))
            {
                BeginCandidateAnimation(frameShape);
                _candidate = true;
            }
            else
            {
                frameShape.Fill.BeginAnimation(SolidColorBrush.ColorProperty, null);
                _candidate = false;
            }
        }

        private void BeginCandidateAnimation(Shape frameShape)
        {
            ColorAnimation colorAnimation = new ColorAnimation(Colors.Black, Colors.White, new Duration(new TimeSpan(0, 0, 0, 1, 0)))
            {
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
            };
            frameShape.Fill.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
        }

        protected void SelectedGameIdsChanged(Collection<int> gameIds, Shape frameShape)
        {
            if (gameIds.Contains(GameId))
            {
                ColorAnimation colorAnimation = new ColorAnimation(Colors.White, Colors.Red, new Duration(new TimeSpan(0, 0, 0, 0, 250)))
                {
                    AutoReverse = true,
                    RepeatBehavior = RepeatBehavior.Forever,
                };
                frameShape.Fill.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
            }
            else if (_candidate)
            {
                BeginCandidateAnimation(frameShape);
            }
            else
            {
                frameShape.Fill.BeginAnimation(SolidColorBrush.ColorProperty, null);
            }
        }
    }
}
