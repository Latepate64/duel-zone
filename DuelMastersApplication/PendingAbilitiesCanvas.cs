using DuelMastersModels.Abilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace DuelMastersApplication
{
    public class PendingAbilitiesCanvas : Canvas
    {
        const int TitleHeight = 25;

        Grid _mainGrid = new Grid();
        ListView _listViewAbilities = new ListView();

        public PendingAbilitiesCanvas(MainWindow mainWindow)
        {
            Background = Brushes.LightGray;
            Visibility = Visibility.Hidden;

            _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            _mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(TitleHeight) });
            _mainGrid.RowDefinitions.Add(new RowDefinition());

            TextBlock textBlockTitle = new TextBlock() { TextAlignment = TextAlignment.Center, Text = "Pending abilities", VerticalAlignment = VerticalAlignment.Center };
            Grid.SetColumn(textBlockTitle, 0);
            Grid.SetRow(textBlockTitle, 0);
            _mainGrid.Children.Add(textBlockTitle);

            Grid.SetColumn(_listViewAbilities, 0);
            Grid.SetRow(_listViewAbilities, 1);
            _mainGrid.Children.Add(_listViewAbilities);

            Children.Add(_mainGrid);

            SizeChanged += CanvasSizeChanged;

            FrameworkElementFactory abilityCanvasFactory = new FrameworkElementFactory(typeof(AbilityCanvas));
            FrameworkElementFactory stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            _listViewAbilities.ItemsPanel = new ItemsPanelTemplate() { VisualTree = stackPanelFactory };

            abilityCanvasFactory.SetBinding(HeightProperty, new Binding("ActualHeight") { Source = _listViewAbilities, Converter = new ListViewSizeToCardCanvasSizeConverter(), ConverterParameter = 0.96 });
            abilityCanvasFactory.SetBinding(WidthProperty, new Binding("ActualHeight") { Source = _listViewAbilities, Converter = new ListViewSizeToCardCanvasSizeConverter(), ConverterParameter = 0.96 });

            MultiBinding multiBinding = new MultiBinding() { Converter = new SetAndIdConverter() };
            multiBinding.Bindings.Add(new Binding("Source.Set"));
            multiBinding.Bindings.Add(new Binding("Source.Id"));
            abilityCanvasFactory.SetBinding(AbilityCanvas.SetAndIdProperty, multiBinding);
            abilityCanvasFactory.SetBinding(AbilityCanvas.AbilityProperty, new Binding(""));

            abilityCanvasFactory.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(mainWindow.AbilityCanvas_MouseLeftButtonDown));
            _listViewAbilities.ItemTemplate = new DataTemplate() { VisualTree = abilityCanvasFactory };
        }

        private void CanvasSizeChanged(object sender, SizeChangedEventArgs e)
        {
            _mainGrid.Width = e.NewSize.Width;
            _mainGrid.Height = e.NewSize.Height;
        }

        public void SetItemsSource(ObservableCollection<NonStaticAbility> pendingAbilities)
        {
            _listViewAbilities.ItemsSource = pendingAbilities;
        }
    }
}
