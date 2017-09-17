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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace StayHydrated
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : MetroWindow
    {
        MainWindow window;

        public Settings(MainWindow mainWindow)
        {
            InitializeComponent();
            window = mainWindow;
            setTextboxes();
        }

        private void setTextboxes()
        {
            tbDuration.Value = (Properties.Settings.Default.Duration / 1000);
            tbFrequency.Value = Properties.Settings.Default.Frequency;
        }
            
        private void applySavedSettings()
        {
            System.Console.WriteLine("Apply settings");            
            Properties.Settings.Default.Duration = ((int) tbDuration.Value)*1000;
            Properties.Settings.Default.Frequency = (int) tbFrequency.Value;
            setTextboxes();
            Properties.Settings.Default.Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            applySavedSettings();
            window.resetJob();
        }
    }
}
