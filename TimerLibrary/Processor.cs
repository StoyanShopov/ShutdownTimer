namespace TimerLibrary
{
    using System.Diagnostics;

    public static class Processor
    {
        public static void Run(this string command)
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
    }
}
