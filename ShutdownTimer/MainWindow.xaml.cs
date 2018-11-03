using System.Threading.Tasks;
using ShutdownTimer.Commands;

namespace ShutdownTimer
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow : Window
    {
        private BatCreator batCreator;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.batCreator = new BatCreator();
            batCreator.CreateFolderWithBatFiles();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            List<string> data = new List<string>
            {
                "5m",
                "10m",
                "15m",
                "20m",
                "30m",
                "45m",
                "1h",
                "2h",
                "3h",
                "4h"
            };

            comboBox.SelectedIndex = 4;
            comboBox.ItemsSource = data;
            
        }

        private void Button_Shutdown(object sender, RoutedEventArgs e)
        {
            var shutDownCommand = $"shutdown /s /t {GetTime()}";
            batCreator.ExecuteCommand(shutDownCommand);
        }
        private void Button_Hibernate(object sender, RoutedEventArgs e)
        {
            var hibernateCommand = $"ping -n {GetTime()} 127.0.0.1 && shutdown /h /f";
            batCreator.ExecuteCommand(hibernateCommand);
            MessageBox.Show($"Your computer will hibernate after {GetTime()}");
        }
        private void Button_Restart(object sender, RoutedEventArgs e)
        {
            var restartCommand = $"shutdown /r /t {GetTime()}";
            batCreator.ExecuteCommand(restartCommand);
        }
        private void Button_LogOff(object sender, RoutedEventArgs e)
        {
            string loggOfCommand = $"ping -n {GetTime()} 127.0.0.1 && rundll32.exe user32.dll,LockWorkStation";
            batCreator.ExecuteCommand(loggOfCommand);
            MessageBox.Show($"Your computer will log off after {GetTime()}");
        }

        private void Button_Abort(object sender, RoutedEventArgs e)
        {
            batCreator.AbortShutdown();
        }

        private void Button_AdditionOptions(object sender, RoutedEventArgs e)
        {
            Scheduler scheduleTask = new Scheduler();
            scheduleTask.Show();
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
    }
}