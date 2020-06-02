using System;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Net;
using System.Threading.Tasks;

namespace _7_json
{
    class MyModel
    {
        public string year { get; set; }
        public string month { get; set; }
        public string day { get; set; }
        public int num { get; set; }
        public string link { get; set; }
        public string news { get; set; }
        public string safe_title { get; set; }
        public string transcript { get; set; }
        public string alt { get; set; }
        public string img { get; set; }
        public string title { get; set; }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://xkcd.com/info.0.json");
            HttpWebResponse res = (HttpWebResponse)await req.GetResponseAsync();
            
            Stream receiveStream = res.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            
            string json = await readStream.ReadToEndAsync();

            var comic = JsonSerializer.Deserialize<MyModel>(json);
            Console.WriteLine(comic.title);
            Console.WriteLine(comic.img);
        }
    }
}
