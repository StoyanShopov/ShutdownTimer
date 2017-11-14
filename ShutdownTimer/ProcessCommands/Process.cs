using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShutdownTimer
{
    public class Process
    {
        public void ShutdownComputer(int time)
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

        public void AbortShutdown()
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + "shutdown -a");
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }

        public void Hibernate(int time)
        {
            string shutDownCommand = $"ping -n {time} 127.0.0.1 && shutdown /h /f";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + shutDownCommand);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }
        
        public void LogOff(int time)
        {
            string loggOfCommand = $"ping -n {time} 127.0.0.1 && rundll32.exe user32.dll,LockWorkStation";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + loggOfCommand);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }

        public void Restart(int time)
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
    }
}
