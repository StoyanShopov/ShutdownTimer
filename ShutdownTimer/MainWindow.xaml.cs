namespace ShutdownTimer
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Process.CreateFolderWithBatFiles();
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
            data.Add("45m");
            data.Add("1h");
            data.Add("2h");
            data.Add("3h");
            data.Add("4h");
            comboBox.SelectedIndex = 4;
            comboBox.ItemsSource = data;
            
        }

        private void Button_Shutdown(object sender, RoutedEventArgs e)
        {
            Process.ShutdownComputer(GetTime());
        }
        private void Button_Hibernate(object sender, RoutedEventArgs e)
        {
            Process.Hibernate(GetTime());
        }
        private void Button_Restart(object sender, RoutedEventArgs e)
        {
            Process.Restart(GetTime());
        }
        private void Button_LogOff(object sender, RoutedEventArgs e)
        {
            Process.LogOff(GetTime());
        }
        private void Button_Abort(object sender, RoutedEventArgs e)
        {
            Process.AbortShutdown();
        }
        private void Button_AdditionOptions(object sender, RoutedEventArgs e)
        {
            ScheduleTask scheduleTask = new ScheduleTask();
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