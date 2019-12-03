using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShutdownTimer.Views.Tasks
{
    using Schedulers;
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

            Commander
                .ShutdownCommand(seconds)
                .RunProcess();
        }
        private void Button_Hibernate(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            Commander
                .HibernateCommand(seconds)
                .RunProcess();

            string message = string.Format(HibernateMessage, seconds);

            MessageBox.Show(message);
        }
        private void Button_Restart(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            Commander
                .RestartCommand(seconds)
                .RunProcess();
        }

        private void Button_LogOff(object sender, RoutedEventArgs e)
        {
            int seconds = GetSeconds();

            Commander
                .LogOffCommand(seconds)
                .RunProcess();

            string message = string.Format(LogOffMessage, seconds);

            MessageBox.Show(message);
        }

        private void Button_Abort(object sender, RoutedEventArgs e)
        {
            Commander
                .AbortShutdownCommand()
                .RunProcess();
        }

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
            => ComboBox.SelectedValue.ToString().ConvertDateTimeStringToSeconds();
    }
}
