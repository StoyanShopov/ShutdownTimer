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

            string folder = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat";
            string[] pathFiles = Directory.GetFiles(folder);


            foreach (var file in pathFiles)
            {
               var currentFile = file.Split('\\').LastOrDefault();
                
                if (currentFile != "Hibernate.bat" &&
                    currentFile != "Restart.bat" &&
                    currentFile != "Shutdown.bat")
                {
                    files.Add(currentFile);
                }
            }
            lbFiles.ItemsSource = files;
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (lbFiles.SelectedItem != null)
            {
                string task = lbFiles.SelectedItem.ToString();
                string taskFile = $"\\{lbFiles.SelectedItem.ToString()}";
                string path = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat" + taskFile;

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"SchTasks /Delete /TN \"{task}\" /F");
                }

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = path;
                proc.Start();
                Thread.Sleep(100);
                File.Delete(path);
                files.Remove(lbFiles.SelectedItem.ToString());
            }                
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
