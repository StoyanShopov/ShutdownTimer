namespace ShutdownTimer.Views.Schedulers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using TimerLibrary;

    /// <summary>
    /// Interaction logic for SchedulerGridView.xaml
    /// </summary>
    public partial class SchedulerGridView : Page
    {
        private const string DateTimeFormat = "d-M-yyyy";

        private readonly SchedulerCreator schedulerCreator;
        private readonly ObservableCollection<string> files;

        public SchedulerGridView()
        {
            InitializeComponent();

            this.schedulerCreator = new SchedulerCreator();
            this.files = new ObservableCollection<string>();

            startDate.SelectedDate = DateTime.Today;
            endDate.SelectedDate = DateTime.Today.AddDays(7);

            PopulateWindowWithFolderFiles();
        }

        private void Operation_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            var data = new List<string>
            {
                "ShutdownCommand", "RestartCommand", "HibernateCommand"
            };

            comboBox.SelectedIndex = 0;
            comboBox.ItemsSource = data;
        }

        private void RunEvery_Loaded(object sender, RoutedEventArgs e)
        {
            var comboBox = sender as ComboBox;

            var data = new List<string>
            {
                "Hourly", "Daily", "Weekly", "Monthly"
            };

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
                "00:00"
            };

            comboBox.SelectedIndex = 9;
            comboBox.ItemsSource = data;
        }

        private void Button_Create(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskName.Text))
            {
                MessageBox.Show("Task name is missing!");
                return;
            }

            if (this.startDate.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Start date should be equal or greater than current date!");
                return;
            }

            if (this.endDate.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("End date should be greater than start date!");
                return;
            }

            var operation = operationBox.SelectedValue.ToString();
            var timespan = timespanBox.SelectedValue.ToString();
            var executionTime = ExecutionTime.SelectedValue.ToString();

            var dateStart = this.startDate.SelectedDate; 
            var dateEnd = this.endDate.SelectedDate;
            var taskFile = taskName.Text;

            var isSuccessful = schedulerCreator
                .Create(operation, timespan, executionTime, dateStart, dateEnd, taskFile);

            MessageBox.Show(isSuccessful
                ? "You successfully create task!" 
                : "A file with that name is already exists!");

            taskName.Clear();

            PopulateWindowWithFolderFiles();
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (lbFiles.SelectedItem == null)
            {
                MessageBox.Show("Please select a file!");
            }

            var selectedItem = lbFiles.SelectedItem.ToString();

            //TODO: Fix hardocoded path
            var path = @"D:\svn\ShutdownTimer.git\trunk\ShutdownTimer\LocalDatabase\ScheduledTasks\" + selectedItem + ".bat";
            schedulerCreator.Delete(path, files, selectedItem);
        }

        private void PopulateWindowWithFolderFiles()
        {
            //TODO: Fix hardocoded path
            var folder = @"D:\svn\ShutdownTimer.git\trunk\ShutdownTimer\LocalDatabase\ScheduledTasks";

            var pathFiles = Directory.GetFiles(folder);

            foreach (var file in pathFiles)
            {
                var currentFile = file
                    .Split('\\')
                    .LastOrDefault();

                if (currentFile == null || !currentFile.EndsWith(".bat"))
                {
                    continue;
                }

                var name = currentFile
                    .Substring(0, currentFile.Length - 4);

                if (!files.Contains(name))
                {
                    this.files.Add(name);
                }
            }

            this.lbFiles.ItemsSource = this.files;
        }
    }
}
