using System.Diagnostics;

namespace Inferno
{
    internal class power
    {
        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        // Command
        private static void command(string args)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "shutdown.exe";
            startInfo.Arguments = args;
            process.StartInfo = startInfo;
            process.Start();
        }

        // Poweroff
        public static void Shutdown()
        {
            command("/s /t 0");
            core.Exit("Shutting down..", output);
        }

        // Restart
        public static void Reboot()
        {
            command("/r /t 0");
            core.Exit("Rebooting computer..", output);
        }

        // Hibernate
        public static void Hibernate()
        {
            command("/h");
            core.Exit("Hibernate..", output);
        }

        // Logoff
        public static void Logoff()
        {
            command("/l");
            core.Exit("Logging off..", output);
        }
    }
}
