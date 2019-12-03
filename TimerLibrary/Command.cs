namespace TimerLibrary
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    public class Command
    {
        private const string batExtension = ".bat";

        private readonly string currentDirPath;

        private string deleteTask = "SchTasks /Delete /TN \"{0}\" /F";

        public Command()
        {
            this.currentDirPath = Directory.GetCurrentDirectory();
        }

        public void Delete(
            string path, 
            ObservableCollection<string> files, 
            string selectedItem)
        {
            var taskFile = selectedItem + batExtension;

            using (var sw = File.CreateText(path))
            {
                sw.WriteLine(string.Format(deleteTask, taskFile));
            }

            var proc = new Process
            {
                EnableRaisingEvents = false,
                StartInfo =
                {
                    FileName = path
                }
            };

            proc.Start();
            Thread.Sleep(100);
            File.Delete(path);
            files.Remove(selectedItem);
        }

        public bool Create(
            string operation,
            string timespan,
            string executionTime, 
            DateTime startDate,
            DateTime endDate, 
            string taskFile)
        {
            if (executionTime == "24:00")
            {
                executionTime = "23:59";
            }

            string file = GetFile(operation);
            string interval = GetIntervalTime(timespan);

            string path = GetPathFromScheduleFolder(taskFile);

            if (!File.Exists(path))
            {
                string executeBatFile = GetPathFromScheduleFolder(file);

                using (var sw = File.CreateText(path))
                {
                    sw.WriteLine($"SchTasks /Create /SC {interval} /TN \"{taskFile}\" /TR \"{executeBatFile}\" /ST {executionTime} /SD {startDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)} /ED {endDate.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}");
                }

                var proc = new Process
                {
                    EnableRaisingEvents = false,
                    StartInfo =
                    {
                        FileName = path
                    }
                };

                proc.Start();

                return true;
            }

            return false;
        }

        private string GetPathFromScheduleFolder(string fileName)
            => this.currentDirPath + $"\\TaskSchedulesBat\\{fileName}.bat";

        private string GetIntervalTime(string timespan)
        {
            switch (timespan)
            {
                case "Hour":
                    return "HOURLY";
                case "Day":
                    return "DAILY";
                case "Week":
                    return "WEEKLY";
                case "Month":
                    return "MONTHLY";
                default:
                    return string.Empty;
            }
        }

        private string GetFile(string operation)
        {
            switch (operation)
            {
                case "ShutdownCommand":
                   return "\\ShutdownCommand.bat";
                case "RestartCommand":
                    return "\\RestartCommand.bat";
                case "HibernateCommand":
                    return "\\HibernateCommand.bat";
                default:
                    return string.Empty;
            }
        }
    }
}
