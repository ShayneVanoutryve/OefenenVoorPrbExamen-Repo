using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace Prb.TrafficLights.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SetTrafficLightImagePath(string fileName)
        {
            string pad = Environment.CurrentDirectory;
            DirectoryInfo directoryInfo = new DirectoryInfo(pad);
            directoryInfo = new DirectoryInfo(directoryInfo.Parent.Parent.Parent.FullName);
            Uri uri = new Uri(directoryInfo.FullName + "/afbeeldingen/" + fileName);
            imgTrafficLight.Source = new BitmapImage(uri);

        }



    }
}
