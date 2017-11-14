using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ShutdownTimer.AdvancedOptions
{
    /// <summary>
    /// Interaction logic for DeleteTask.xaml
    /// </summary>
    public partial class DeleteTask : Window
    {
        private ObservableCollection<string> files = new ObservableCollection<string>();
        public DeleteTask()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            string shutdown = "Shutdown timer scheduler";
            string restart = "Restart timer scheduler";
            string hibernate = "Hibernate timer scheduler";

            string pathShutdown = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat" + "\\" + shutdown + ".bat";
            string pathRestart = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat" + "\\" + restart + ".bat";
            string pathHibernate = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat" + "\\" + hibernate + ".bat";

            if (File.Exists(pathShutdown))
            {
                files.Add(shutdown);
            }
            if (File.Exists(pathRestart))
            {
                files.Add(restart);
            }
            if (File.Exists(pathHibernate))
            {
                files.Add(hibernate);
            }

            lbFiles.ItemsSource = files;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (lbFiles.SelectedItem != null)
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + $"SchTasks /Delete /TN \"{lbFiles.SelectedItem.ToString()}\"");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                files.Remove(lbFiles.SelectedItem.ToString());
         

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }                
        }
    }
}
