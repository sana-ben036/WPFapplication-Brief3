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
using System.Net;
using System.Diagnostics;
using System.Security.AccessControl;
using System.IO.Compression;


namespace UpdateApp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public long size;

        private void Scanner()
        {
            List<string> listFiles = new List<string>();
            var tmpPath = System.IO.Path.GetTempPath();
            var files = Directory.GetFiles(tmpPath, "*.*", SearchOption.AllDirectories);
            listFiles.AddRange(files);
            var Nombre = listFiles.Count();
            size = 0;

            FileStream fs = new FileStream(@"C:\Users\youcode\source\repos\story.txt", FileMode.OpenOrCreate); // create file
            StreamWriter sw = new StreamWriter(fs); // write in the file
            foreach (var file in files)
            {
                size += file.Length;
                sw.Write(file + "\n");
            }
            txt1.Text = "Espace à nettoyer : " + size / 1000 + " Ko (" + Nombre + " files)";
            txt2.Text = "Derniére analyse : " + DateTime.Now.ToString();

            pb1.Visibility = Visibility.Visible;
            title.Text = "L'analyse en cours";
            txt1.Visibility = Visibility.Visible;
            txt2.Visibility = Visibility.Visible;
            txt3.Visibility = Visibility.Visible;
            list_1.IsEnabled = false;
            list_2.IsEnabled = false;
            list_3.IsEnabled = false;
            list_4.IsEnabled = false;
            list_5.IsEnabled = false;
            //nettoyer.IsEnabled = true;
            //msj.IsEnabled = true;
            //historique.IsEnabled = true;


        }

        private void Loadprogressbar()
        {
            Duration duré = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation animation = new DoubleAnimation(200.0, duré);
            //pb1.BeginAnimation(ProgressBar.ValueProperty, animation);
            pb2.BeginAnimation(ProgressBar.ValueProperty, animation);



        }

        private void Analys_Click(object sender, RoutedEventArgs e)
        {

            Loadprogressbar();
            Scanner();

        }

        private void Clean_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Story_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Maj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetVersion_Click(object sender, RoutedEventArgs e)
        {
            
            
            pb2.Visibility = Visibility.Visible;
            GetVersion.Visibility = Visibility.Hidden;
            NoGetVersion.Visibility = Visibility.Hidden;
            Loadprogressbar();

            WebClient webClient = new WebClient();
            var client = new WebClient();

            try
            {
                System.Threading.Thread.Sleep(1000);
                client.DownloadFile("https://sendeyo.com/up/d/0598c98a7f", @"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\PcCleaner\bin\Release\netcoreapp3.1\UPDATE.zip");
                string zipPath = @"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\PcCleaner\bin\Release\netcoreapp3.1\UPDATE.zip";
                string extractPath = @"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\PcCleaner\bin\Release\netcoreapp3.1";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                File.Delete(@"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\PcCleaner\bin\Release\netcoreapp3.1\UPDATE.zip");

                Process.Start(@"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\PcCleaner\bin\Release\netcoreapp3.1\PcCleaner.exe");
                this.Close();
            }

            catch
            {

            }

        }

        private void NoGetVersion_Click(object sender, RoutedEventArgs e)
        {

            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = @"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\PcCleaner\bin\Release\netcoreapp3.1\PcCleaner.exe";

            Process.Start(@"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\PcCleaner\bin\Release\netcoreapp3.1\PcCleaner.exe");
            this.Close();
        }
    }
}
