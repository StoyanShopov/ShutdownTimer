namespace ShutdownTimer.Views.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using TimerLibrary;

    /// <summary>
    /// Interaction logic for TaskGridView.xaml
    /// </summary>
    public partial class TaskGridView : Page
    {
        private const string HibernateMessage = "Your computer will hibernate after {0}";
        private const string LogOffMessage = "Your computer will log off after {0}";
        public TaskGridView()
        {
            InitializeComponent();
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
            int seconds = GetSeconds();

            BatchCommand
                .ShutdownCommand(seconds)
                .Run();
        }
        private void Button_Hibernate(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            BatchCommand
                .HibernateCommand(seconds)
                .Run();

            string message = string.Format(HibernateMessage, seconds);

            MessageBox.Show(message);
        }
        private void Button_Restart(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            BatchCommand
                .RestartCommand(seconds)
                .Run();
        }

        private void Button_LogOff(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            BatchCommand
                .LogOffCommand(seconds)
                .Run();

            string message = string.Format(LogOffMessage, seconds);

            MessageBox.Show(message);
        }

        private void Button_Abort(object sender, RoutedEventArgs e)
        {
            BatchCommand
                .AbortShutdownCommand()
                .Run();
        }

        //TODO: Find better way to do it
        private void Button_AdditionOptions(object sender, RoutedEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            // Change the page of the frame.
            if (pageFrame != null)
            {
                pageFrame.Source = new Uri("Views/Schedulers/SchedulerGridView.xaml", UriKind.Relative);
            }
        }

        private int GetSeconds()
            => this.ComboBox.SelectedValue.ToString().ConvertDateTimeStringToSeconds();
    }
}
