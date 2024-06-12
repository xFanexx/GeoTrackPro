using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GeoTrackPro
{
    public class Data
    {
        public string ip { get; set; }
        public string hostname { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country { get; set; }
        public string loc { get; set; }
        public string org { get; set; }
        public string postal { get; set; }
        public string timezone { get; set; }
    }

    internal class GeoTrackPro
    {
        static void WriteRainbow(string text)
        {
            ConsoleColor[] rainbowColors = {
                ConsoleColor.Red,
                ConsoleColor.DarkYellow,
                ConsoleColor.Yellow,
                ConsoleColor.Green,
                ConsoleColor.Blue,
                ConsoleColor.DarkMagenta
            };

            for (int i = 0; i < text.Length; i++)
            {
                Console.ForegroundColor = rainbowColors[i % rainbowColors.Length];
                Console.Write(text[i]);
            }
            Console.WriteLine();
            Console.ResetColor(); // Reset to default color
        }

        static async Task Main(string[] args)
        {
            WriteRainbow(@"
  _______  _______  _______ _________ _______  _______  _______  _        _______  _______  _______
 (  ____ \(  ____ \(  ___  )\__   __/(  ____ )(  ___  )(  ____ \| \    /\(  ____ )(  ____ )(  ___  )
 | (    \/| (    \/| (   ) |   ) (   | (    )|| (   ) || (    \/|  \  / /| (    )|| (    )|| (   ) |
 | |      | (__    | |   | |   | |   | (____)|| (___) || |      |  (_/ / | (____)|| (____)|| |   | |
 | | ____ |  __)   | |   | |   | |   |     __)|  ___  || |      |   _ (  |  _____)|     __)| |   | |
 | | \_  )| (      | |   | |   | |   | (\ (   | (   ) || |      |  ( \ \ | (      | (\ (   | |   | |
 | (___) || (____/\| (___) |   | |   | ) \ \__| )   ( || (____/\|  /  \ \| )      | ) \ \__| (___) |
 (_______)(_______/(_______)   )_(   |/   \__/|/     \|(_______/|_/    \/|/       |/   \__/(_______)
                                                                                                    
");

            Console.WriteLine(); // Add a blank line
            Console.Title = "GeoTrackPro";

            WriteRainbow("GeoTrackPro started");
            Console.WriteLine(); // Add a blank line
            WriteRainbow("Enter the IP address:");

            while (true)
            {
                string ip = Console.ReadLine();

                if (ip.ToLower() == "exit")
                {
                    break;
                }

                string url = $"https://ipinfo.io/{ip}/json";

                using HttpClient client = new HttpClient();
                try
                {
                    HttpResponseMessage responseMessage = await client.GetAsync(url);
                    responseMessage.EnsureSuccessStatusCode();

                    WriteRainbow("[+] Request successfully completed");

                    string responseData = await responseMessage.Content.ReadAsStringAsync();
                    Data ipInfo = JsonConvert.DeserializeObject<Data>(responseData);

                    WriteRainbow($"IP Address: {ipInfo.ip}");
                    WriteRainbow($"Hostname: {ipInfo.hostname}");
                    WriteRainbow($"City: {ipInfo.city}");
                    WriteRainbow($"Region: {ipInfo.region}");
                    WriteRainbow($"Country: {ipInfo.country}");
                    WriteRainbow($"Postal Code: {ipInfo.postal}");
                    WriteRainbow($"Timezone: {ipInfo.timezone}");
                    WriteRainbow($"Organization: {ipInfo.org}");

                    if (!string.IsNullOrEmpty(ipInfo.loc))
                    {
                        string[] coordinates = ipInfo.loc.Split(',');
                        WriteRainbow($"Google Maps: https://www.google.com/maps/?q={coordinates[0]},{coordinates[1]}");
                    }
                    else
                    {
                        WriteRainbow("Coordinates not available.");
                    }
                }
                catch (HttpRequestException httpRequestException)
                {
                    WriteRainbow($"[-] Error during request: {httpRequestException.Message}");
                }
                catch (Exception ex)
                {
                    WriteRainbow($"[-] An unexpected error occurred: {ex.Message}");
                }

                Console.WriteLine(); // Add a blank line for better formatting
                WriteRainbow("Enter a new IP address (or 'exit' to quit):");
            }

            WriteRainbow(@"
 ______   _______  _        _______ 
(  __  \ (  ___  )( (    /|(  ____ \
| (  \  )| (   ) ||  \  ( || (    \/
| |   ) || |   | ||   \ | || (__    
| |   | || |   | || (\ \) ||  __)   
| |   ) || |   | || | \   || (      
| (__/  )| (___) || )  \  || (____/\
(______/ (_______)|/    )_)(_______/
                                    
");

            Console.ReadLine(); // Wait for user input to exit
        }
    }
}
