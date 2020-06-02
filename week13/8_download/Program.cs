using System;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _8_download
{
    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();
        static async Task DownloadInBackground(string address, string filename)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFileCompleted += DownloadFileCallback;
                client.DownloadProgressChanged += DownloadProgressCallback;
                Console.WriteLine("Starting download");
                await client.DownloadFileTaskAsync(new Uri(address), filename);
            }
        }
        static void DownloadFileCallback(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download complete!");
            Environment.Exit(0);
        }

        static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds > 1000) {
                stopwatch.Restart();
                Console.WriteLine($"Downloaded {e.BytesReceived} of {e.TotalBytesToReceive} bytes. {e.ProgressPercentage}% complete");
            }
        }
        
        static async Task Main(string[] args)
        {
            // This is a large file to test the download.
            // It's not an executable file, so you should be fine,
            // but do not download random files blindly from the internet!
            var downloadTask = DownloadInBackground("https://speed.hetzner.de/100MB.bin", "file.bin");
            stopwatch.Start();
            await downloadTask;
        }
    }
}
