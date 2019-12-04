namespace TimerLibrary
{
    public static class BatchCommand
    {
        public static string ShutdownCommand(int seconds)
            => $"shutdown /s /t {seconds}";

        public static string ForceShutdownCommand()
            => "shutdown /s /f";
        public static string HibernateCommand(int seconds)
            => $"ping -n {seconds} 127.0.0.1 && shutdown /h /f";

        public static string ForceHibernateCommand()
            => "shutdown /h /f";
        public static string RestartCommand(int seconds)
            => $"shutdown /r /t {seconds}";

        public static string ForceRestartCommand()
            => "shutdown /r /f";

        public static string LogOffCommand(int seconds)
            => $"ping -n {seconds} 127.0.0.1 && rundll32.exe user32.dll,LockWorkStation";
        
        public static string AbortShutdownCommand()
            => "shutdown -a";

        public static string KillTaskPingCommand()
            => "Taskkill /IM PING.exe /F";
    }
}
