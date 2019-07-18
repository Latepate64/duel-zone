using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuelMastersApplication
{
    public class AbilityIconCanvas : Canvas
    {
        Ellipse _ellipse = new Ellipse() { Fill = Brushes.Black };
        Image _iconImage = new Image() { Stretch = Stretch.Fill };

        public AbilityIconCanvas(Uri imagePath, ItemsControl parentItemsControl)
        {
            _iconImage.Source = new BitmapImage(imagePath);
            Children.Add(_ellipse);
            Children.Add(_iconImage);
            SetBinding(WidthProperty, new System.Windows.Data.Binding("ActualWidth") { Source = parentItemsControl });
            SetBinding(HeightProperty, new System.Windows.Data.Binding("ActualWidth") { Source = this });
            SizeChanged += AbilityIconCanvas_SizeChanged;
        }

        private void AbilityIconCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            const double Scale = 0.8;
            _iconImage.Width = Scale * e.NewSize.Width;
            _iconImage.Height = Scale * e.NewSize.Height;
            SetLeft(_iconImage, (e.NewSize.Width - _iconImage.Width) / 2);
            SetTop(_iconImage, (e.NewSize.Height - _iconImage.Height) / 2);

            _ellipse.Width = e.NewSize.Width;
            _ellipse.Height = e.NewSize.Height;
        }
    }
}
