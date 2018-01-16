namespace ShutdownTimer
{
    using System.Diagnostics;
    using System.IO;
    using System.Windows;

    public class Process
    {
        public static void ShutdownComputer(int time)
        {
            string shutDownCommand = $"shutdown /s /t {time}";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + shutDownCommand);
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

        public static void Hibernate(int time)
        {
            string shutDownCommand = $"ping -n {time} 127.0.0.1 && shutdown /h /f";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + shutDownCommand);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            MessageBox.Show($"Your computer will hibernate after {time}");

        }

        public static void LogOff(int time)
        {
            string loggOfCommand = $"ping -n {time} 127.0.0.1 && rundll32.exe user32.dll,LockWorkStation";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + loggOfCommand);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            MessageBox.Show($"Your computer will log off after {time}");
        }

        public static void Restart(int time)
        {
            string shutDownCommand = $"shutdown /r /t {time}";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + shutDownCommand);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
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
