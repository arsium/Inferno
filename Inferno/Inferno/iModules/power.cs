using System;
using System.Diagnostics;

namespace Inferno
{
    internal class power
    {

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
        public static void shutdown()
        {
            Console.WriteLine("Shutting down..");
            command("/s /t 0");
        }

        // Restart
        public static void reboot()
        {
            Console.WriteLine("Rebooting computer..");
            command("/r /t 0");
        }

        // Hibernate
        public static void hibernate()
        {
            Console.WriteLine("Hibernate..");
            command("/h");
        }

        // Logoff
        public static void logoff()
        {
            Console.WriteLine("Logging off..");
            command("/l");
        }
    }
}
