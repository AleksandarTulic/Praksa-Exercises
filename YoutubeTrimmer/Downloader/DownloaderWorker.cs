using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Downloader
{
    internal class DownloaderWorker : Worker
    {
        public DownloaderWorker() { }

        public DownloaderWorker(string baseUrl, string TaskName)
            : base(baseUrl, TaskName) { }

        public async override Task<JObject> DoSomeWork(PollResult pollResult)
        {
            var guidValue = $"{Guid.NewGuid()}.%(ext)s";
            var outputFileName = await GetYtdlpFilename(YT_DLP, guidValue, pollResult.InputData["youtubeLink"] + "");

            await DownloadVideo(YT_DLP, guidValue, Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + outputFileName, pollResult.InputData["youtubeLink"] + "");

            Console.WriteLine(guidValue + " " + (Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + outputFileName));
            return JObject.FromObject(new DownloaderOutput
            {
                DownloadPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + outputFileName + Path.DirectorySeparatorChar + outputFileName
            }) ;
        }

        private async Task<string> GetYtdlpFilename(string ytdlp, string fileFormat, string youtubeLink)
        {
            var process = new Process();
            process.StartInfo.FileName = ytdlp;
            process.StartInfo.RedirectStandardOutput = true;
            var args = new[] { "--print", "filename", "-o", fileFormat, youtubeLink };
            foreach (var arg in args)
            {
                process.StartInfo.ArgumentList.Add(arg);
            }

            process.Start();
            var outputFilename = await process.StandardOutput.ReadToEndAsync();
            outputFilename = outputFilename.Replace("\n", string.Empty);
            await process.WaitForExitAsync();
            return outputFilename;
        }

        private async Task DownloadVideo(string ytdlp, string fileFormat, string downloadPath, string youtubeLink)
        {
            var downloadProcess = Process.Start(ytdlp, new[] { "-o", fileFormat, "-P", downloadPath, youtubeLink });
            await downloadProcess.WaitForExitAsync();
        }
    }
}
