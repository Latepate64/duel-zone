using DuelMastersModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DuelMastersApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int SideColumnWidth = 150;

        #region Fields
        Duel _duel = new Duel();
        Grid _mainGrid = new Grid() { ShowGridLines = true };
        Canvas _setupCanvas;
        ListView _listViewActiveHand = new ListView() { Background = Brushes.Aqua, ToolTip = "Active player's hand." };
        #endregion Fields

        public MainWindow()
        {
            _setupCanvas = new SetupCanvas(_duel);
            InitializeComponent();
            Title = "Duel Masters Application";

            Canvas mainCanvas = new Canvas()
            {
                //Background = Brushes.Aquamarine,
            };
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(SideColumnWidth) });
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(SideColumnWidth) });
            _mainGrid.RowDefinitions.Add(new RowDefinition());

            TextBlock testButton = new TextBlock() { Text = "Jee" };
            Grid.SetColumn(testButton, 0);
            Grid.SetRow(testButton, 0);
            _mainGrid.Children.Add(testButton);

            Grid centerGrid = new Grid() { ShowGridLines = true };
            centerGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 6; ++i)
            {
                centerGrid.RowDefinitions.Add(new RowDefinition());
            }
            Grid.SetColumn(centerGrid, 1);
            _mainGrid.Children.Add(centerGrid);

            //Duel duel = new Duel();
            //_listViewActiveHand.ItemsSource = duel.Player1.Hand.Cards;

            Grid.SetColumn(_listViewActiveHand, 0);
            Grid.SetRow(_listViewActiveHand, 5);
            centerGrid.Children.Add(_listViewActiveHand);

            mainCanvas.Children.Add(_mainGrid);
            mainCanvas.Children.Add(_setupCanvas);

            Content = mainCanvas;

            mainCanvas.SizeChanged += MainCanvas_SizeChanged;
            //_setupCanvas.star            //mainGrid.Children.Add(canvas);
            //Content = canvas;
        }

        #region Events
        private void MainCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _mainGrid.Height = e.NewSize.Height;
            _mainGrid.Width = e.NewSize.Width;

            Canvas.SetLeft(_setupCanvas, (e.NewSize.Width - _setupCanvas.Width) / 2);
            Canvas.SetTop(_setupCanvas, (e.NewSize.Height - _setupCanvas.Height) / 2);
        }
        #endregion Events
    }
}
