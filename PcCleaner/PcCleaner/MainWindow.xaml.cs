using System;
using System.IO;
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
using System.ComponentModel;
using System.Windows.Media.Animation;

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
            //1: start analys
            pb1.Visibility = Visibility.Visible;
            //txt1.Visibility = Visibility.Hidden;
            txt2.Visibility = Visibility.Hidden;
            txt3.Visibility = Visibility.Hidden;
            title.Text = "Analyse en cours";
            list_1.IsEnabled = false;
            list_2.IsEnabled = false;
            list_3.IsEnabled = false;
            list_4.IsEnabled = false;
            list_5.IsEnabled = false;
            nettoyer.IsEnabled = false;
            msj.IsEnabled = false;
            historique.IsEnabled = false;
            Loadprogressbar();

            // 2: show result of scan all files found
            Scanner();

        }
        private void Scanner()
        {
            
            List<string> listFiles = new List<string>();
            var tmpPath = System.IO.Path.GetTempPath();
            var files = Directory.GetFiles(tmpPath, "*.*", SearchOption.AllDirectories);
            listFiles.AddRange(files);
            var Nombre = listFiles.Count();
            long size = 0;

            StreamWriter writer = new StreamWriter(@"C:\Users\youcode\source\repos\story.txt");
            foreach (var file in files)
            {

                size += file.Length;
                writer.Write(file + "\n");
            }
            txt1.Text = "Espace à nettoyer : " + size/1000 + " Ko (" + Nombre + " files)";
            txt2.Text = "Derniére analyse : " + DateTime.Now.ToString();
            




            /*pb1.Visibility = Visibility.Hidden;
            title.Text = "L'analyse est terminée";
            txt1.Visibility = Visibility.Visible;
            txt2.Visibility = Visibility.Visible;
            txt3.Visibility = Visibility.Visible;
            list_1.IsEnabled = true;
            list_2.IsEnabled = true;
            list_3.IsEnabled = true;
            list_4.IsEnabled = true;
            list_5.IsEnabled = true;
            nettoyer.IsEnabled = true;
            msj.IsEnabled = true;
            historique.IsEnabled = true;
            */
        }

        private void Loadprogressbar()
        {
            Duration duré = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation animation = new DoubleAnimation(200.0, duré);
            pb1.BeginAnimation(ProgressBar.ValueProperty, animation);
           
           
        }
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("clean");
        }
        private void Story_Click(object sender, RoutedEventArgs e)
        {
            String line;

            // StreamReader reader = new StreamReader(@"C:\Users\youcode\source\repos\story.txt");
            //string fileContent = reader.ReadToEnd();
            //string[] lines = File.ReadAllLines(@"C:\Users\youcode\source\repos\story.txt");
            StreamReader sr = new StreamReader(@"C: \story.txt");
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the lie to console window
                Console.WriteLine(line);
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            Console.ReadLine();
        }




    
        private void Maj_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("mise a jour");
            //String URLString = "https://github.com/sana-ben036/WPFapplication-Brief3.git";
            // import from ;
        }




    }
}
