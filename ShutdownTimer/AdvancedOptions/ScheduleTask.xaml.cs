using ASquare.WindowsTaskScheduler;
using ASquare.WindowsTaskScheduler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Globalization;
using ShutdownTimer.AdvancedOptions;

namespace ShutdownTimer
{
    /// <summary>
    /// Interaction logic for AdvancedOptions.xaml
    /// </summary>
    public partial class ScheduleTask : Window
    {
        private ObservableCollection<string> files = new ObservableCollection<string>();
        public ScheduleTask()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            startDate.SelectedDate = DateTime.Today;
            endDate.SelectedDate = DateTime.Today.AddDays(7);
            startDate.HorizontalContentAlignment = HorizontalAlignment.Right;
            endDate.HorizontalContentAlignment = HorizontalAlignment.Right;
            GetFolderFiles();
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
            data.Add("24:00");
            comboBox.SelectedIndex = 9;
            comboBox.ItemsSource = data;
        }

        private void Button_Create(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(taskName.Text) || String.IsNullOrWhiteSpace(taskName.Text))
            {
                MessageBox.Show("Please fill in task name!");
                return;
            }
  
            string operation = operationBox.SelectedValue.ToString();
            string timespan = timespanBox.SelectedValue.ToString();
            string executionTime = ExecutionTime.SelectedValue.ToString();

            string dateStart = GetStartDate();
            string dateEnd = GetEndDate();
            var startDate = DateTime.ParseExact(dateStart, "d-M-yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(dateEnd, "d-M-yyyy", CultureInfo.InvariantCulture);

            if (startDate < DateTime.Today)
            {
                MessageBox.Show("Start date should be equal or greater than current date!");
                return;
            }

            if (endDate < DateTime.Today)
            {
                MessageBox.Show("End date should be greater than start date!");
                return;
            }

            string taskFile = $"\\{taskName.Text}.bat";

            var successful = Commands.Create(operation, timespan, executionTime, startDate, endDate, taskFile);

            if (successful)
            {
                MessageBox.Show("You successfully create task!");
            }
            else
            {
                MessageBox.Show("A file with that name is already exists!");
            }

            taskName.Clear();
            GetFolderFiles();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (lbFiles.SelectedItem != null)
            {
                string selectedItem = lbFiles.SelectedItem.ToString();
                string path = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat\\" + selectedItem + ".bat";
                Commands.Delete(path, files, selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a file!");
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private string GetEndDate()
        {
            string dateEnd = null;

            DateTime? endDateVar = this.endDate.SelectedDate;
            if (endDateVar.HasValue)
            {
                dateEnd = endDateVar.Value.ToString("d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            return dateEnd;
        }

        private string GetStartDate()
        {
            string startDate = null;

            DateTime? startDateVar = this.startDate.SelectedDate;
            if (startDateVar.HasValue)
            {
                startDate = startDateVar.Value.ToString("d-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            return startDate;
        }

        private void GetFolderFiles()
        {
            string folder = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat";
            string[] pathFiles = Directory.GetFiles(folder);
            foreach (var file in pathFiles)
            {
                var currentFile = file.Split('\\').LastOrDefault();

                if (currentFile != "Hibernate.bat" && currentFile != "Restart.bat" && currentFile != "Shutdown.bat" && currentFile != "AbortTimer.bat")
                {
                    string name = currentFile.Substring(0, currentFile.Length - 4);

                    if (!files.Contains(name))
                    {
                        files.Add(name);
                    }
                }
            }
            lbFiles.ItemsSource = files;
        }
    }
}
