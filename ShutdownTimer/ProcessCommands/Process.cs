namespace ShutdownTimer
{
    using System.Diagnostics;
    using System.IO;
    using System.Windows;

    public class Process
    {
        public static void ExecuteCommand(string command)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }

        public static void AbortShutdown()
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + "shutdown -a");
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();

            string path = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat\\AbortTimer.bat";
            System.Diagnostics.Process processs = new System.Diagnostics.Process();
            processs.EnableRaisingEvents = false;
            processs.StartInfo.FileName = path;
            processs.Start();
            MessageBox.Show($"Your aborted successfully all commands!");
        }

        public static void CreateFolderWithBatFiles()
        {
            string directory = Directory.GetCurrentDirectory() + "\\TaskSchedulesBat";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string pathShutdown = directory + "\\Shutdown.bat";
            string pathRestart = directory + "\\Restart.bat";
            string pathHibernate = directory + "\\Hibernate.bat";
            string deleteTask = directory + "\\AbortTimer.bat";

            if (!File.Exists(pathShutdown))
            {
                using (StreamWriter sw = File.CreateText(pathShutdown))
                {
                    string commandShutdown = "shutdown /s /f";
                    sw.WriteLine(commandShutdown);
                }
            }

            if (!File.Exists(pathRestart))
            {
                using (StreamWriter sw = File.CreateText(pathRestart))
                {
                    string commandRestart = "shutdown /r /f";
                    sw.WriteLine(commandRestart);
                }
            }

            if (!File.Exists(pathHibernate))
            {
                using (StreamWriter sw = File.CreateText(pathHibernate))
                {
                    string commandHibernate = "shutdown /h /f";
                    sw.WriteLine(commandHibernate);
                }
            }

            if (!File.Exists(deleteTask))
            {
                using (StreamWriter sw = File.CreateText(deleteTask))
                {
                    string commandAbort = "Taskkill /IM PING.exe /F";
                    sw.WriteLine(commandAbort);
                }
            }
        }
    }
}
