using System;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace question3
{
    class ApiRoot
    {
        public string astro { get; set; }
        public string init { get; set; }
        public IList<WeatherInfo> dataseries { get; set; }
    }

    class WeatherInfo
    {
        public int timepoint { get; set; }
        public int cloudcover { get; set; }
        public int seeing { get; set; }
        public int transparency { get; set; }
        public int rh2m { get; set; }
        public WindInfo wind10m { get; set; }
        public int temp2m { get; set; }
        public string prec_type { get; set; }
    }

    class WindInfo
    {
        public string direction { get; set; }
        public int speed { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter latitude: ");
            string lat = Console.ReadLine();
            Console.Write("Enter longitude: ");
            string lon = Console.ReadLine();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create($"http://www.7timer.info/bin/astro.php?lon={lon}&lat={lat}&ac=0&unit=metric&output=json&tzshift=0");
            HttpWebResponse res = (HttpWebResponse)await req.GetResponseAsync();
            
            Stream receiveStream = res.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            
            string json = await readStream.ReadToEndAsync();

            var astro = JsonConvert.DeserializeObject<dynamic>(json);

            foreach (var entry in astro.dataseries)
            {
                Console.WriteLine($"Hour: {entry.timepoint}, Temp: {entry.temp2m}");
            }
        }
    }
}
