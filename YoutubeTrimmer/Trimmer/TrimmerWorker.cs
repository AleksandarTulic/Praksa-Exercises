using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trimmer
{
    internal class TrimmerWorker : Worker
    {
        public TrimmerWorker() { }

        public TrimmerWorker(string baseUrl, string TaskName)
            : base(baseUrl, TaskName) { }

        public async override Task<JObject> DoSomeWork(PollResult pollResult)
        {
            var process = new Process();
            process.StartInfo.FileName = FFMPEG;
            process.StartInfo.RedirectStandardOutput = true;
            var fromVar = pollResult.InputData["from"] + "";
            var fromLength = pollResult.InputData["length"] + "";
            var args = new[] { "-i", pollResult.InputData["videoPath"] + "", "-ss", fromVar, "-t",
            fromLength, "-c:v", "copy", "-c:a", "copy", @"C:\Users\Codaxy\Desktop\GIT\YoutubeTrimmer\Downloader\bin\Debug\net7.0" + Path.DirectorySeparatorChar 
            + Guid.NewGuid() + 
            $".{pollResult.InputData["videoPath"]?.ToString().Split(@".")[(pollResult.InputData["videoPath"]+ "").Split(@".").Length - 1]}"};

            foreach (var arg in args)
            {
                process.StartInfo.ArgumentList.Add(arg);
                Console.WriteLine(arg);
            }

            process.Start();
            var outputFilename = await process.StandardOutput.ReadToEndAsync();
            outputFilename = outputFilename.Replace("\n", string.Empty);
            await process.WaitForExitAsync();
            //return outputFilename;
            return null;
        }
    }
}
