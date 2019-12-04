namespace TimerLibrary
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.IO;
    using System.Threading;

    public class SchedulerCreator
    {
        private const string BatExtension = ".bat";
        private const string DeleteTask = "SchTasks /Delete /TN \"{0}\" /F";
        private const string CreateTask = "SchTasks /Create /SC {0} /TN \"{1}\" /TR \"{2}\" /ST {3} /SD {4} /ED {5}";
        public void Delete(string path, ObservableCollection<string> files, string selectedItem)
        {
            var taskFile = selectedItem + BatExtension;

            using (var sw = File.CreateText(path))
            {
                sw.WriteLine(DeleteTask, taskFile);
            }

            path.Run();

            Thread.Sleep(100);

            File.Delete(path);

            files.Remove(selectedItem);
        }

        public bool Create(string operation, string timespan, string executionTime, DateTime? startDate, DateTime? endDate, string taskFile)
        {
            string path = GetPathFromScheduleFolder(taskFile);

            if (File.Exists(path))
            {
                return false;
            }

            string file = operation + BatExtension;
            string interval = timespan.ToUpper();
            string executeBatFile = GetPathFromScheduleFolder(file);
            string startDateAsString = startDate.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            string endDateAsString = endDate.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

            using (var sw = File.CreateText(path))
            {
                sw.WriteLine(CreateTask, interval, taskFile, executeBatFile, executionTime, startDateAsString, endDateAsString);
            }

            path.Run();

            return true;
        }

        //TODO: Fix hardcoded path
        private string GetPathFromScheduleFolder(string fileName)
            => $@"D:\svn\ShutdownTimer.git\trunk\ShutdownTimer\LocalDatabase\ScheduledTasks\{fileName}.bat";
    }
}
