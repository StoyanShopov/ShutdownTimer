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
            //string shutDownCommand = $"  timeout /t {time} /nobreak & shutdown /h";
            //ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + shutDownCommand);
            //procStartInfo.RedirectStandardOutput = true;
            //procStartInfo.UseShellExecute = false;
            //procStartInfo.CreateNoWindow = true;
            //Process proc = new Process();
            //proc.StartInfo = procStartInfo;
            //proc.Start(); 
        }

        public void LogOff()
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + "shutdown /l");
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }
    }
}
