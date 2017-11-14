using ASquare.WindowsTaskScheduler;
using ASquare.WindowsTaskScheduler.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace ShutdownTimer
{
    /// <summary>
    /// Interaction logic for AdvancedOptions.xaml
    /// </summary>
    public partial class ScheduleTask : Window
    {
        public ScheduleTask()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            startDate.SelectedDate = DateTime.Today;
            endDate.SelectedDate = DateTime.Today.AddDays(7);
            startDate.HorizontalContentAlignment = HorizontalAlignment.Right;
            endDate.HorizontalContentAlignment = HorizontalAlignment.Right;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateTask();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //this.Close();
        }

        private void Operation_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            List<string> data = new List<string>();
            data.Add("Shutdown");
            data.Add("Restart");
            data.Add("Hibernate");
            comboBox.SelectedIndex = 0;
            comboBox.ItemsSource = data;
        }

        private void RunEvery_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            List<string> data = new List<string>();
            data.Add("Hour");
            data.Add("Day");
            data.Add("Week");
            data.Add("Month");
            comboBox.SelectedIndex = 1;
            comboBox.ItemsSource = data;
        }

        private void ExecutionTime_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            List<string> data = new List<string>();
            data.Add("01:00");
            data.Add("02:00");
            data.Add("03:00");
            data.Add("04:00");
            data.Add("05:00");
            data.Add("06:00");
            data.Add("07:00");
            data.Add("08:00");
            data.Add("09:00");
            data.Add("10:00");
            data.Add("11:00");
            data.Add("12:00");
            data.Add("13:00");
            data.Add("14:00");
            data.Add("15:00");
            data.Add("16:00");
            data.Add("17:00");
            data.Add("18:00");
            data.Add("19:00");
            data.Add("20:00");
            data.Add("21:00");
            data.Add("22:00");
            data.Add("23:00");
            data.Add("00:00");
            comboBox.SelectedIndex = 9;
            comboBox.ItemsSource = data;
        }
         private void CreateTask()
        {
            string operation = operationBox.SelectedValue.ToString();
            string timespan = timespanBox.SelectedValue.ToString();    
            string executionTime = ExecutionTime.SelectedValue.ToString();

            string dateStart = null;
            string dateEnd = null;

            DateTime? startDateVar = this.startDate.SelectedDate;
            if (startDateVar.HasValue)
            {
                dateStart = startDateVar.Value.ToString("d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            }

            DateTime? endDateVar = this.endDate.SelectedDate;
            if (endDateVar.HasValue)
            {
                dateEnd = endDateVar.Value.ToString("d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            var startDate = DateTime.ParseExact(dateStart, "d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(dateEnd, "d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            string file = string.Empty;
            switch (operation)
            {
                case "Shutdown":
                    file = "\\Shutdown.bat";
                    break;
                case "Restart":
                    file = "\\Restart.bat";
                    break;
                case "Hibernate":
                    file = "\\Hibernate.bat";
                    break;
            }

            string intervals = string.Empty;
            switch (timespan)
            {
                case "Hour":
                    intervals = "HOURLY";
                    break;
                case "Day":
                    intervals = "DAILY";
                    break;
                case "Week":
                    intervals = "WEEKLY";
                    break;
                case "Month":
                    intervals = "MONTHLY";
                    break;
            }
         
            string taskFile = $"\\{operation} timer scheduler.bat";
            string path = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat" + taskFile;
           
            if (!File.Exists(path))
            {
                string taskName = $"{operation} timer scheduler";
                string executeBatFile = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat" + operation;

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"SchTasks /Create /SC {intervals} /TN \"{taskName}\" /TR \"{executeBatFile}\" /ST {executionTime} /SD {startDate.ToString("d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture)} /ED {endDate.ToString("d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture)}");
                }

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = path;
                proc.Start();
            }
        }
    }
}
