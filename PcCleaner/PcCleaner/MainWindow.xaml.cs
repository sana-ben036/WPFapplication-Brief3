﻿using System;
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void btn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void btn_Copy1_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
