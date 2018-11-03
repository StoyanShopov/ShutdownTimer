using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ShutdownTimer.Commands;

namespace ShutdownTimer
{
    public partial class Scheduler : Window
    {
        private const string dateTimeFormat = "d-M-yyyy";

        private readonly Command command;
        private readonly ObservableCollection<string> files;

        public Scheduler()
        {
            this.command = new Command();
            this.files = new ObservableCollection<string>();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            startDate.SelectedDate = DateTime.Today;
            endDate.SelectedDate = DateTime.Today.AddDays(7);
            startDate.HorizontalContentAlignment = HorizontalAlignment.Right;
            endDate.HorizontalContentAlignment = HorizontalAlignment.Right;
            InitializeComponent();
            GetFolderFiles();
        }

        private void Operation_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var data = new List<string> {"Shutdown", "Restart", "Hibernate"};
            comboBox.SelectedIndex = 0;
            comboBox.ItemsSource = data;
        }

        private void RunEvery_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var data = new List<string> {"Hour", "Day", "Week", "Month"};
            comboBox.SelectedIndex = 1;
            comboBox.ItemsSource = data;
        }

        private void ExecutionTime_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            var data = new List<string>
            {
                "01:00",
                "02:00",
                "03:00",
                "04:00",
                "05:00",
                "06:00",
                "07:00",
                "08:00",
                "09:00",
                "10:00",
                "11:00",
                "12:00",
                "13:00",
                "14:00",
                "15:00",
                "16:00",
                "17:00",
                "18:00",
                "19:00",
                "20:00",
                "21:00",
                "22:00",
                "23:00",
                "24:00"
            };
            comboBox.SelectedIndex = 9;
            comboBox.ItemsSource = data;
        }

        private void Button_Create(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskName.Text))
            {
                MessageBox.Show("Please fill in task name!");
                return;
            }

            var operation = operationBox.SelectedValue.ToString();
            var timespan = timespanBox.SelectedValue.ToString();
            var executionTime = ExecutionTime.SelectedValue.ToString();

            var dateStart = GetStartDate();
            var dateEnd = GetEndDate();

            var startDate = DateTime.ParseExact(dateStart, dateTimeFormat, CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(dateEnd, dateTimeFormat, CultureInfo.InvariantCulture);

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

            var taskFile = $"\\{taskName.Text}.bat";

            var successful = command.Create(operation, timespan, executionTime, startDate, endDate, taskFile);

            MessageBox.Show(successful ? "You successfully create task!" : "A file with that name is already exists!");

            taskName.Clear();
            GetFolderFiles();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (lbFiles.SelectedItem != null)
            {
                var selectedItem = lbFiles.SelectedItem.ToString();
                var path = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat\\" + selectedItem + ".bat";
                command.Delete(path, files, selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a file!");
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private string GetEndDate()
        {
            string dateEnd = null;

            var endDateVar = endDate.SelectedDate;

            if (endDateVar.HasValue) dateEnd = endDateVar.Value.ToString(dateTimeFormat, CultureInfo.InvariantCulture);

            return dateEnd;
        }

        private string GetStartDate()
        {
            string startDate = null;

            var startDateVar = this.startDate.SelectedDate;
            if (startDateVar.HasValue)
                startDate = startDateVar.Value.ToString(dateTimeFormat, CultureInfo.InvariantCulture);

            return startDate;
        }

        private void GetFolderFiles()
        {
            var folder = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat";

            var pathFiles = Directory.GetFiles(folder);
            foreach (var file in pathFiles)
            {
                var currentFile = file.Split('\\').LastOrDefault();

                if (currentFile != "Hibernate.bat" && currentFile != "Restart.bat" && currentFile != "Shutdown.bat" &&
                    currentFile != "AbortTimer.bat")
                {
                    var name = currentFile.Substring(0, currentFile.Length - 4);

                    if (!files.Contains(name)) files.Add(name);
                }
            }

            lbFiles.ItemsSource = files;
        }
    }
}