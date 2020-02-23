using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace Inferno
{
    internal class network
    {

        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

        // Get BSSID
        public static void bssid()
        {
  
        }

        // Download file
        public static void downloadFile(string url, string foutput = "")
        {
            if(string.IsNullOrEmpty(foutput))
            {
                foutput = url.Split('/')[url.Split('/').Length - 1];
            }
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, foutput);
            
            output.filename = foutput;
            core.Exit("File downloaded", output);
        }

        // Upload file to Anonfile.com
        public static void uploadFile(string filename)
        {
            // Check
            if (!File.Exists(filename))
            {
                output.error = true;
                core.Exit("File " + filename + " not found!", output, 1);
            }
            // POST request
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            byte[] responseBytes = client.UploadFile(@"https://api.anonfile.com/upload", "POST", filename);
            string response = System.Text.Encoding.ASCII.GetString(responseBytes);
            client.Dispose();
            // Parse json
            dynamic json = JObject.Parse(response);
            // Check upload status
            if(!json.status)
            {
                output.error = true;
                output.msg   = json.error.message;
                output.type  = json.error.type;
                output.code  = json.error.code;
                core.Exit("Failed upload file", output);
            } else
            {
                output.url = json.data.file.url.full;
                core.Exit("File uploaded successfully!", output);
            }
        }
        
        // Whois
        public static void Whois(string ip = "")
        {
            // Url
            string url = @"http://ip-api.com/json/" + ip;
            // GET request
            WebClient client = new WebClient();
            string response = client.DownloadString(url);
            // Parse json
            dynamic json = JObject.Parse(response);
            output.whois = json;
            core.Exit("Whois data received!", output);
        }

        // BSSID
        public static void BssidInfo(string bssid)
        {
            // Url
            string url = @"http://api.mylnikov.org/geolocation/wifi?v=1.1&data=open&bssid=" + bssid;
            // GET request
            WebClient client = new WebClient();
            string response = client.DownloadString(url);
            // Parse json
            dynamic json = JObject.Parse(response);
            output.bssid = json;
            core.Exit("BSSID info received!", output);
        }
    }
}
