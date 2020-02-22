using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Inferno
{ 
    internal class admin
    {
        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetExitCodeProcess(System.IntPtr hProcess, out uint ExitCode);



        // Is administrator
        public static bool isAdmin()
        {
            bool result;
            using (WindowsIdentity current = WindowsIdentity.GetCurrent())
            {
                result = new WindowsPrincipal(current).IsInRole(WindowsBuiltInRole.Administrator);
            }
            return result;
        }
        // Is administrator (json)
        public static void isAdministrator()
        {
            
            output.isAdmin = isAdmin();
            core.Exit("Administrator status received", output);
        }

        // Start file as admin
        public static void startFile(string filename)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = filename;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.Start();
            proc.WaitForExit();
            output.exitcode = proc.ExitCode;
            core.Exit("File started", output);
        }

    }
}
