using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Einheit_2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<GeoObject> Shapes = new List<GeoObject>();
        public MainWindow()
        {
            InitializeComponent();
            combo.ItemsSource = new List<string>() { "Rechteck", "Kreis" };
        }

        private void Neu_Click(object sender, RoutedEventArgs e)
        {
            Shapes.Add(new GeoObject(
                            combo.SelectedItem.ToString(), 
                            int.Parse(PosX.Text), 
                            int.Parse(PosY.Text), 
                            int.Parse(Breite.Text), 
                            int.Parse(Laenge.Text)));

            dtgListing.ItemsSource = null;
            dtgListing.ItemsSource = Shapes;
        }

        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            var temp = dtgListing.SelectedItem as GeoObject;
            Shape geoObject; // unten geo object = new rectangle und dann Canvas.Children.Add(geoObject)
            switch (temp.Shape)
            {
                case "Rechteck":
                    geoObject = new Rectangle()
                    {
                        Height = temp.Height,
                        Width = temp.Width,
                        Stroke = new SolidColorBrush(Colors.Red),
                        StrokeThickness = 1
                    };
                    Canvas.Children.Add(geoObject);
                    // Positionierung
                    geoObject.SetValue(Canvas.TopProperty, (double)temp.PosY);
                    geoObject.SetValue(Canvas.LeftProperty, (double)temp.PosX);
                    break;

                case "Kreis":
                    geoObject = new Ellipse()
                    {
                        Height = temp.Height,
                        Width = temp.Width,
                        Stroke = new SolidColorBrush(Colors.Red),
                        StrokeThickness = 1
                    };
                    Canvas.Children.Add(geoObject);
                    // Positionierung
                    geoObject.SetValue(Canvas.TopProperty, (double)temp.PosY);
                    geoObject.SetValue(Canvas.LeftProperty, (double)temp.PosX);
                    break;
            }

           
        }
    }
}
