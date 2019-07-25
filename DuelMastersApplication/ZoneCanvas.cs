using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace DuelMastersApplication
{
    public class ZoneCanvas : Canvas
    {
        const int TitleHeight = 25;

        Grid _mainGrid = new Grid();
        ListView _listViewZone = new ListView();

        public ZoneCanvas()
        {
            Background = Brushes.LightGray;
            Visibility = Visibility.Hidden;

            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(TitleHeight) });
            _mainGrid.RowDefinitions.Add(new RowDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(TitleHeight) });

            Button hideButton = new Button() { Content = "Close" };
            hideButton.Click += HideButton_Click;

            Grid.SetColumn(_listViewZone, 0);
            Grid.SetRow(_listViewZone, 1);
            _mainGrid.Children.Add(_listViewZone);

            Grid.SetColumn(hideButton, 0);
            Grid.SetRow(hideButton, 2);
            _mainGrid.Children.Add(hideButton);

            Children.Add(_mainGrid);

            SizeChanged += ZoneCanvas_SizeChanged;
        }

        private void ZoneCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _mainGrid.Width = e.NewSize.Width;
            _mainGrid.Height = e.NewSize.Height;
        }

        public void Initialize(string title, Binding listViewBinding, MainWindow mainWindow, bool showKnownToPlayerWithoutPriority = true)
        {
            TextBlock textBlockTitle = new TextBlock() { TextAlignment = TextAlignment.Center, Text = title, VerticalAlignment = VerticalAlignment.Center };
            Grid.SetColumn(textBlockTitle, 0);
            Grid.SetRow(textBlockTitle, 0);
            _mainGrid.Children.Add(textBlockTitle);

            _listViewZone.SetBinding(ItemsControl.ItemsSourceProperty, listViewBinding);
            mainWindow.BindCardCanvasToListView(_listViewZone, showKnownToPlayerWithoutPriority);
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }
    }
}
