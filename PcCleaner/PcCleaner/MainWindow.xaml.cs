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
            txt1.Text = "Espace à nettoyer : " + size/1000 + " Ko (" + Nombre + " files)";
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
            nettoyer.IsEnabled = true;
            msj.IsEnabled = true;
            historique.IsEnabled = true;
           
           
        }

        private void Loadprogressbar()
        {
            Duration duré = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation animation = new DoubleAnimation(200.0, duré);
            pb1.BeginAnimation(ProgressBar.ValueProperty, animation);
            
           
        }

        private void Analys_Click(object sender, RoutedEventArgs e)
        {

            Loadprogressbar();
            Scanner();

        }


        public string timeclean;
        private void Clean_Click(object sender, RoutedEventArgs e)
        {
            List<string> listFiles = new List<string>();
            var tmpPath = System.IO.Path.GetTempPath();
            var files = Directory.GetFiles(tmpPath, "*.*", SearchOption.AllDirectories);

           

            foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            timeclean = DateTime.Now.ToString();
            MessageBox.Show("delete done");
        }


        private void Story_Click(object sender, RoutedEventArgs e)
        {

           MessageBox.Show(size.ToString()+ "\n" + timeclean);

        }




        double clientVersion = 1.0;
        string updatePath;
        string packageFile;
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
                
                /*
                updatePath = System.IO.Path.Combine(@"update\", strWebVersion.Replace(",", "."));
                Uri package = new Uri("");
                string zipPath = @".\UPDATE.zip";

                 Directory.CreateDirectory(updatePath);
                 packageFile = System.IO.Path.Combine(updatePath, "update.exe");
                 webClient.DownloadFileCompleted += WebClient_downloadfileCompleted;
                 webClient.DownloadFileAsync(package, packageFile);
                */

                Process.Start(@"C:\Users\youcode\source\repos\sana-ben036\WPFapplication-Brief3\PcCleaner\UpdateApp\bin\Release\UpdateApp.exe");
                this.Close();





            }else
            {
                MessageBox.Show(" l'application est déja à jour !");

            }

            
        }

        private void WebClient_downloadfileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Process.Start(packageFile);
        }
    }
}
