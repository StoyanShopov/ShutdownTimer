using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShutdownTimer.AdvancedOptions
{
    public class Commands
    {
        public static void Delete(string path, ObservableCollection<string> files, string selectedItem)
        {
            string taskFile = selectedItem + ".bat";

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"SchTasks /Delete /TN \"{taskFile}\" /F");
            }

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = path;
            proc.Start();
            Thread.Sleep(100);
            File.Delete(path);
            files.Remove(selectedItem);
        }

        public static bool Create(string operation, string timespan, string executionTime, DateTime startDate, DateTime endDate, string taskFile)
        {
            if (executionTime == "24:00")
            {
                executionTime = "23:59";
            }

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

            string path = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat" + taskFile;

            if (!File.Exists(path))
            {
                string executeBatFile = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat" + file;

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"SchTasks /Create /SC {intervals} /TN \"{taskFile}\" /TR \"{executeBatFile}\" /ST {executionTime} /SD {startDate.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)} /ED {endDate.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)}");
                }

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.EnableRaisingEvents = false;
                proc.StartInfo.FileName = path;
                proc.Start();

                return true;
            }

            return false;
        }
    }
}
