using ShutdownTimer.Authorization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;


namespace ShutdownTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            List<string> data = new List<string>();
            data.Add("5m");
            data.Add("10m");
            data.Add("15m");
            data.Add("20m");
            data.Add("30m");
            data.Add("1h");
            data.Add("2h");
            data.Add("3h");
            data.Add("4h");
            comboBox.ItemsSource = data;
        }

        private void Button_Shutdown(object sender, RoutedEventArgs e)
        {
            Process shutDown = new Process();
            shutDown.ShutdownComputer(GetTime());  
        }
        private void Button_Abort(object sender, RoutedEventArgs e)
        {
            Process shutDown = new Process();
            shutDown.AbortShutdown();  
        }
      
        private void Button_Hibernate(object sender, RoutedEventArgs e)
        {
            Process shutDown = new Process();
            MessageBoxResult messageBoxResult = MessageBox.Show("Hibernate command will close all of your apps, would you like to contunie?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                shutDown.Hibernate(GetTime());
            }

        }

        private void Button_LogOff(object sender, RoutedEventArgs e)
        {
            Process shutDown = new Process();
            MessageBoxResult messageBoxResult = MessageBox.Show("Log Off command will close all of your apps, would you like to contunie?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                shutDown.LogOff();
            }
        }
        private void Button_Restart(object sender, RoutedEventArgs e)
        {
            Process shutDown = new Process();
            shutDown.Restart(GetTime());
        }

        private void Button_AdditionOptions(object sender, RoutedEventArgs e)
        {
            string root = Directory.GetCurrentDirectory();
            string mainFolder = root.Substring(0, root.Length - 10);
            string path = string.Concat(mainFolder + "\\Password");

            if (Directory.Exists(path))
            {
                MessageBox.Show(path);
            }
            else
            {
                SetPassword setpass = new SetPassword();
                setpass.Show();
                this.Close();
            }
        }

        private int GetTime()
        {
            string input = combobox.SelectedValue.ToString();
            string digitValue = input.Substring(0, input.Length - 1);
            int time = int.Parse(digitValue) * 60;

            if (input[1] == 'h')
            {
                time *= 60;
            }

            return time;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string root = Directory.GetCurrentDirectory();

            if (Directory.Exists(root))
            {
                MessageBox.Show(root);
            }
            else
            {
                MessageBox.Show("nothing");
            }

            //Test expPage = new Test();
            //expPage.Show();
            //this.Close();
        }
    }
}