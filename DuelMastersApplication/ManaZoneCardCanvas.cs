using DuelMastersModels.Cards;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DuelMastersApplication
{
    public class ManaZoneCardCanvas : AbstractCardCanvas
    {
        public static readonly DependencyProperty CivilizationProperty = DependencyProperty.Register("Civilizations", typeof(Collection<Civilization>), typeof(ManaZoneCardCanvas), new PropertyMetadata(OnCivilizationsChanged));

        private Ellipse _ellipseCardFrame = new Ellipse() { Fill = new SolidColorBrush(Colors.Black) };
        private Ellipse _ellipseColorFrame = new Ellipse();
        private Ellipse _ellipseArtWork = new Ellipse();
        private Ellipse _ellipseManaNumberOuterFrame = new Ellipse() { Fill = new SolidColorBrush(Colors.Black) };
        private Ellipse _ellipseManaNumberInnerFrame = new Ellipse();
        private TextBlock _textBlockManaNumber = new TextBlock() { Text = "1", FontWeight = FontWeights.Bold, TextAlignment = TextAlignment.Center };

        static ManaZoneCardCanvas()
        {
            CandidateGameIdsProperty.OverrideMetadata(typeof(ManaZoneCardCanvas), new PropertyMetadata(OnCandidateGameIdsChanged));
            SelectedGameIdsProperty.OverrideMetadata(typeof(ManaZoneCardCanvas), new PropertyMetadata(OnSelectedGameIdsChanged));
            SetAndIdProperty.OverrideMetadata(typeof(ManaZoneCardCanvas), new PropertyMetadata(OnManaSetAndIdChanged)); 
        }

        public ManaZoneCardCanvas()
        {
            Children.Add(_ellipseCardFrame);
            Children.Add(_ellipseColorFrame);
            Children.Add(_ellipseArtWork);
            Children.Add(_ellipseManaNumberOuterFrame);
            Children.Add(_ellipseManaNumberInnerFrame);
            Children.Add(_textBlockManaNumber);
            SizeChanged += ManaZoneCardCanvas_SizeChanged;

            TappedDegree = 45.0;
            _ellipseManaNumberOuterFrame.SetBinding(Shape.FillProperty, new Binding("Fill") { Source = _ellipseCardFrame });
            _textBlockManaNumber.SetBinding(TextBlock.ForegroundProperty, new Binding("Fill") { Source = _ellipseCardFrame });
        }

        private void ManaZoneCardCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double width = e.NewSize.Width;
            double height = e.NewSize.Height;

            _ellipseCardFrame.Width = width;
            _ellipseCardFrame.Height = height;
            SetLeft(_ellipseCardFrame, (width - width) / 2);
            SetTop(_ellipseCardFrame, (height - height) / 2);

            CanvasFrame.Width = width;
            CanvasFrame.Height = height;
            SetLeft(CanvasFrame, (width - width) / 2);
            SetTop(CanvasFrame, (height - height) / 2);

            _ellipseColorFrame.Width = width * (1 - FrameOffset);
            _ellipseColorFrame.Height = height * (1 - FrameOffset);
            SetLeft(_ellipseColorFrame, (width - _ellipseColorFrame.Width) / 2);
            SetTop(_ellipseColorFrame, (height - _ellipseColorFrame.Height) / 2);

            const double ArtworkOffset = 3 * FrameOffset;
            _ellipseArtWork.Width = width * (1 - ArtworkOffset);
            _ellipseArtWork.Height = height * (1 - ArtworkOffset);
            SetLeft(_ellipseArtWork, (width - _ellipseArtWork.Width) / 2);
            SetTop(_ellipseArtWork, (height - _ellipseArtWork.Height) / 2);

            double manaNumberOuterFrameWidth = 0.3 * width;
            _ellipseManaNumberOuterFrame.Width = manaNumberOuterFrameWidth;
            _ellipseManaNumberOuterFrame.Height = manaNumberOuterFrameWidth;
            SetLeft(_ellipseManaNumberOuterFrame, (width - _ellipseManaNumberOuterFrame.Width) / 2);
            SetTop(_ellipseManaNumberOuterFrame, 0);

            double manaNumberInnerFrameWidth = (0.3 - FrameOffset) * width;
            _ellipseManaNumberInnerFrame.Width = manaNumberInnerFrameWidth;
            _ellipseManaNumberInnerFrame.Height = manaNumberInnerFrameWidth;
            SetLeft(_ellipseManaNumberInnerFrame, (width - _ellipseManaNumberInnerFrame.Width) / 2);
            SetTop(_ellipseManaNumberInnerFrame, (manaNumberOuterFrameWidth - manaNumberInnerFrameWidth) / 2);

            _textBlockManaNumber.FontSize = 0.16 * width;

            _textBlockManaNumber.Width = manaNumberInnerFrameWidth;
            _textBlockManaNumber.Height = manaNumberInnerFrameWidth;
            SetLeft(_textBlockManaNumber, (width - _textBlockManaNumber.Width) / 2);
            SetTop(_textBlockManaNumber, (manaNumberOuterFrameWidth - _textBlockManaNumber.Width) / 2);
        }

        private static void OnCandidateGameIdsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ManaZoneCardCanvas canvas = d as ManaZoneCardCanvas;
            canvas.CandidateGameIdsChanged((Collection<int>)e.NewValue, canvas._ellipseCardFrame);
        }

        private static void OnSelectedGameIdsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ManaZoneCardCanvas).OnSelectedGameIdsChanged(e);
        }

        private void OnSelectedGameIdsChanged(DependencyPropertyChangedEventArgs e)
        {
            SelectedGameIdsChanged((Collection<int>)e.NewValue, _ellipseCardFrame);
        }

        private static void OnCivilizationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Brush brush = GetBrushForCivilizations(e.NewValue as Collection<Civilization>);
            ManaZoneCardCanvas manaZoneCardCanvas = d as ManaZoneCardCanvas;
            manaZoneCardCanvas._ellipseColorFrame.Fill = brush;
            manaZoneCardCanvas._ellipseManaNumberInnerFrame.Fill = brush;
        }

        private static void OnManaSetAndIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ManaZoneCardCanvas)._ellipseArtWork.Fill = new ImageBrush(GetArtwork((SetAndId)e.NewValue)) { Stretch = Stretch.Fill };
        }
    }
}
