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

        

        private void Button_Click(object sender, RoutedEventArgs e)   // btn vue d'ensemble , btn option
        {
            Process.Start(@"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\PcCleaner\bin\Release\netcoreapp3.1\PcCleaner.exe");
            this.Close();
        }




        public long size;
        public int Nombre;
        public void Scan()    // methode pour scan les fichiers temporaire
        {
            List<string> listFiles = new List<string>();
            var tmpPath = System.IO.Path.GetTempPath();
            var files = Directory.GetFiles(tmpPath, "*.*", SearchOption.AllDirectories);
            listFiles.AddRange(files);
            Nombre = listFiles.Count();
            size = 0;
            
            foreach (var file in files)
            {
                size += file.Length;
                
            }
        }
       

        private void Loadprogressbar() // methode pour lancer progressbar
        {
            Duration duré = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation animation = new DoubleAnimation(200.0, duré);
            pb1.BeginAnimation(ProgressBar.ValueProperty, animation);
            
           
        }






        public string timeAnalys;
        private void Analys_Click(object sender, RoutedEventArgs e)
        {

            Loadprogressbar();
            Scan();

            timeAnalys = DateTime.Now.ToString();
            txt1.Text = "Espace à nettoyer : " + size / 1024 + " Ko (" + Nombre + " files)";
            txt2.Text = "Derniére analyse : " + timeAnalys;

            pb1.Visibility = Visibility.Visible;
            title.Text = "L'analyse en cours";
            txt1.Visibility = Visibility.Visible;
            txt2.Visibility = Visibility.Visible;
            txt3.Visibility = Visibility.Visible;
            //list_1.IsEnabled = false;
            //list_2.IsEnabled = false;
            //list_3.IsEnabled = false;
            //list_4.IsEnabled = false;
            //list_5.IsEnabled = false;
            nettoyer.IsEnabled = true;
            msj.IsEnabled = true;
            historique.IsEnabled = true;


        } 
        
        

        

        
        public string timeClean;
        public string info;
        public string[] paths = { @"C:\Windows\Temp", System.IO.Path.GetTempPath(), Environment.GetFolderPath(Environment.SpecialFolder.Cookies) };
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            //BUG NOT SOLVED 
            /*
            List<string> listFiles = new List<string>();
            var tmpPath = System.IO.Path.GetTempPath();
            var files = Directory.GetFiles(tmpPath, "*.*", SearchOption.AllDirectories);
            listFiles.AddRange(files);

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
            }
            */


            Scan();

            title.Text = "Nettoyage en cours ";
            timeClean = DateTime.Now.ToString();
            info ="Operation de nettoyage : " + size / 1024 + "ko" + "   " + timeClean ;
            

            MessageBox.Show("Nettoyage est términé");

        }

        public void GetStory()
        {

            string path = @"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\story.txt";
            List<string> infos = File.ReadAllLines(path).ToList();
            infos.Add(info);
            File.WriteAllLines(path, infos);
            foreach (string info in infos)
            {
                listBox1.Items.Add(info);
            }

        }



    private void Story_Click(object sender, RoutedEventArgs e)


        {
            nettoyer.Visibility = Visibility.Hidden;
            msj.Visibility = Visibility.Hidden;
            historique.Visibility = Visibility.Hidden;
            txt1_story.Visibility = Visibility.Visible;
            listBox1.Visibility = Visibility.Visible;

            GetStory();
            

            
            
        }




        double clientVersion = 1.0;
        WebClient webClient;
        private void Maj_Click(object sender, RoutedEventArgs e)
        {

            webClient = new WebClient();
            Uri webVersion = new Uri("https://sendeyo.com/up/d/dc4418b341");
            webClient.DownloadStringAsync(webVersion);
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;


        }

        private void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string strWebVersion = e.Result;
            double webVersion = double.Parse(strWebVersion);

            if(clientVersion < webVersion)
            {
                MessageBox.Show("Une nouvelle version est disponible !");
                
                Process.Start(@"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\UpdateApp\bin\Release\UpdateApp.exe");
                this.Close();





            }else
            {
                MessageBox.Show(" l'application est déja à jour !");

            }

            
        }

        
    }
}
