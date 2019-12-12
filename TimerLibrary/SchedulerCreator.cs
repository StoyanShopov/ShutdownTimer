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
        private const string DateTimeFormat = "dd-MM-yyyy";

        public void Delete(string path, ObservableCollection<string> files, string selectedItem)
        {
            var taskFile = selectedItem + BatExtension;

            string content = string.Format(DeleteTask, taskFile);

            File.WriteAllText(path, content);

            path.Run();

            Thread.Sleep(100);

            File.Delete(path);
            files.Remove(selectedItem);
        }

        public bool Create(string operation, string timespan, string executionTime, DateTime? startDate, DateTime? endDate, string taskFile)
        {
            string path = Helper.GetPathFоrScheduleFolder;
            string executeBatFile = path + operation + BatExtension;

            if (File.Exists(executeBatFile))
            {
                return false;
            }

            string interval = timespan.ToUpper();

            string startDateAsString = startDate.Value.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
            string endDateAsString = endDate.Value.ToString(DateTimeFormat, CultureInfo.InvariantCulture);

            string content = string.Format(CreateTask, interval, taskFile, executeBatFile, executionTime,
                startDateAsString, endDateAsString);

            File.WriteAllText(executeBatFile, content);

            executeBatFile.Run();

            return true;
        }
    }
}
