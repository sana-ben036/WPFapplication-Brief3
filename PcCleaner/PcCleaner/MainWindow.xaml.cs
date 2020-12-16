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

namespace PcCleaner
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




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("testing");
        }
        private void Analys_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("analys");
        }
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("clean");
        }
        private void Story_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("story");
        }
        private void Maj_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("mise a jour");
        }
    }
}
