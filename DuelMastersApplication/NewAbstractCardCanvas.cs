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
    public abstract class NewAbstractCardCanvas : Canvas
    {
        #region Constants
        private const double UntappedDegree = 0.0;

        protected const double MinimumFontSize = 9;
        public const double FrameOffset = 0.07;
        #endregion Constants

        private static readonly Dictionary<Civilization, Color> _civilizationDictionary = new Dictionary<Civilization, Color>()
        {
            { Civilization.Light, Color.FromRgb(250, 250, 140) },
            { Civilization.Water, Color.FromRgb(120, 180, 215) },
            { Civilization.Darkness, Color.FromRgb(75, 75, 75) },
            { Civilization.Fire, Color.FromRgb(210, 35, 40) },
            { Civilization.Nature, Color.FromRgb(80, 100, 50) },
        };

        #region Properties
        public int GameId { get; private set; }
        public string Set { get; private set; }
        public string Id { get; private set; }
        public bool Tapped { get; private set; }


        /// <summary>
        /// A canvas for the card frame which contains elements for the card object.
        /// </summary>
        protected Canvas CanvasFrame = new Canvas();

        protected Image Artwork = new Image();

        public MainWindow MainWindow { get; private set; }
        
        protected double TappedDegree = 10.0;
        #endregion Properties

        protected NewAbstractCardCanvas(MainWindow mainWindow, int gameId, string set, string id)
        {
            MainWindow = mainWindow;
            Set = set;
            Id = id;
            Artwork.Source = GetArtwork(new SetAndId() { Set = set, Id = id });
            GameId = gameId;

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

        #region Events
        protected void AbstractCardCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindow?.ZoomCardCanvas(GameId);
        }

        protected void AbstractCardCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainWindow?.UnzoomCardCanvas();
        }
        #endregion Events

        #region Methods
        public static BitmapImage GetArtwork(SetAndId setAndId)
        {
            const string RootPath = "Artworks";
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), RootPath, setAndId.Set, string.Format("{0} {1}.jpg", setAndId.Set, setAndId.Id));
            if (File.Exists(path))
            {
                return new BitmapImage(new Uri(path));
            }
            else
            {
                return null;
            }
        }
        #endregion Methods

        protected Size MeasureString(string text, double fontSize, double width, double height, FontWeight fontWeight, FontStyle fontStyle, FontFamily fontFamily)
        {
            TextBlock textBlock = new TextBlock { Text = text, TextWrapping = TextWrapping.NoWrap, FontSize = fontSize, FontWeight = fontWeight, FontStyle = fontStyle, FontFamily = fontFamily };
            textBlock.Measure(new Size(width, height));
            textBlock.Arrange(new Rect(textBlock.DesiredSize));
            return textBlock.RenderSize;
        }

        protected static Brush GetBrushForCivilizations(ReadOnlyCivilizationCollection civilizations)
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
    }
}
