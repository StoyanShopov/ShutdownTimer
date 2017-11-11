
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
            CreateFolderWithBatFiles();
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
            comboBox.SelectedIndex = 4;
            comboBox.ItemsSource = data;
            
        }

        private void Button_Shutdown(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.ShutdownComputer(GetTime());
        }
        private void Button_Hibernate(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.Hibernate(GetTime());
        }
        private void Button_Restart(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.Restart(GetTime());
        }
        private void Button_LogOff(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.LogOff(GetTime());
        }
        private void Button_Abort(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.AbortShutdown();
        }
        private void Button_AdditionOptions(object sender, RoutedEventArgs e)
        {
            AdvancedOptions adv = new AdvancedOptions();
            adv.Show();
            this.Close();
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
        private void CreateFolderWithBatFiles()
        {
            string directory = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);

                string pathShutdown = directory + "\\Shutdown.bat";
                string pathRestart = directory + "\\Restart.bat";
                string pathHibernate = directory + "\\Hibernate.bat";
                string commandShutdown = "shutdown /s /f";
                string commandRestart = "shutdown /r /f";
                string commandHibernate = "shutdown /h /f";

                using (StreamWriter sw = File.CreateText(pathShutdown))
                {
                    sw.WriteLine(commandShutdown);
                }
                using (StreamWriter sw = File.CreateText(pathRestart))
                {
                    sw.WriteLine(commandRestart);
                }
                using (StreamWriter sw = File.CreateText(pathHibernate))
                {
                    sw.WriteLine(commandHibernate);
                }
            }
        }
    }
}