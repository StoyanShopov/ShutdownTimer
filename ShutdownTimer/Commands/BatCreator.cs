using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ShutdownTimer.Commands
{
    public class BatCreator
    {
        private const string abortShutdown = "shutdown -a";
        private const string forceShutdown = "shutdown /s /f";
        private const string forceRestart = "shutdown /r /f";
        private const string forceHibernate = "shutdown /h /f";
        private const string killPingTask = "Taskkill /IM PING.exe /F";

        private const string abortTime = "AbortTimer";
        private const string hibernate = "Hibernate";
        private const string restart = "Restart";
        private const string shutdown = "Shutdown";

        private readonly string currentDirPath;

        public BatCreator()
        {
            this.currentDirPath = Directory.GetCurrentDirectory();
        }

        public void ExecuteCommand(string command)
        {
            RunProcess(command);
        }

        public void AbortShutdown()
        {
            RunProcess(abortShutdown);

            var path = GetPathFromScheduleFolder(abortTime);

            var process = new Process
            {
                EnableRaisingEvents = false,
                StartInfo =
                {
                    FileName = path
                }
            };

            process.Start();

            MessageBox.Show($"Your aborted successfully all commands!");
        }

        public void CreateFolderWithBatFiles()
        {
            var directory = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var pathShutdown = GetPathFromScheduleFolder(shutdown);
            var pathRestart = GetPathFromScheduleFolder(restart);
            var pathHibernate = GetPathFromScheduleFolder(hibernate);
            var deleteTask = GetPathFromScheduleFolder(abortTime);

            CreateCommand(pathShutdown, forceShutdown);
            CreateCommand(pathRestart, forceRestart);
            CreateCommand(pathHibernate, forceHibernate);
            CreateCommand(deleteTask, killPingTask);
        }

        private string GetPathFromScheduleFolder(string fileName)
                        => this.currentDirPath + $"\\TaskSchedulesBat\\{fileName}.bat";
        
        private void RunProcess(string command)
        {
            var procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var proc = new Process
            {
                StartInfo = procStartInfo
            };
            proc.Start();
        }

        private void CreateCommand(string path, string command)
        {
            if (!File.Exists(path))
            {
                using (var sw = File.CreateText(path))
                {
                    var commandShutdown = command;
                    sw.WriteLine(commandShutdown);
                }
            }
        }
    }
}
