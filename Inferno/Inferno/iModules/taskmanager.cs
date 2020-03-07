using Microsoft.Win32;
using System.Diagnostics;

namespace Inferno
{
    internal class taskmanager
    {
        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();


        // Check if process exists
        public static void Exists(string processName)
        {
            if (Process.GetProcessesByName(processName).Length > 0) {
                output.exists = true;
            } else {
                output.exists = false;
            }
            core.Exit("Process state received", output);
        }

        // Get process list
        public static void List()
        {
            var processlist = new System.Collections.Generic.List<string>();
            foreach (Process process in Process.GetProcesses())
            {
                processlist.Add(process.ProcessName);
            }
            output.count = processlist.Count;
            output.list = processlist;
            core.Exit("List if proccesses received", output);
        }

        // Kill process by name
        public static void Kill(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
            core.Exit("Process killed", output);
        }

        // Start process by name
        public static void Start(string processName)
        {
            try
            {
                Process.Start(processName);
            } catch (System.ComponentModel.Win32Exception) {
                output.error = true;
                core.Exit("Process not started", output, 1);
            }    
            core.Exit("Process started", output);
        }

        // Disable TaskManager
        public static void Disable()
        {
            if (!admin.isAdmin())
            {
                output.error = true;
                core.Exit("Access denied, administrator rights needed to disable taskmanager!", output, 2);
            }
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            objRegistryKey.SetValue("DisableTaskMgr", 1);
            objRegistryKey.Close();
            core.Exit("TaskManager disabled!", output);
        }
        // Enable TaskManager
        public static void Enable()
        {
            if (!admin.isAdmin())
            {
                output.error = true;
                core.Exit("Access denied, administrator rights needed to enable taskmanager!", output, 2);
            }
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            objRegistryKey.SetValue("DisableTaskMgr", 0);
            objRegistryKey.Close();
            core.Exit("TaskManager enabed!", output);
        }

    }
}
