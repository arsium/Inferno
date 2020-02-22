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

    }
}
