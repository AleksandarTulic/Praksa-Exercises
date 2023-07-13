using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class Worker : IWorker
    {
        protected static readonly int DELAY_MILLISECONDS = 500;
        protected static readonly string YT_DLP = @"C:\Users\Codaxy\Downloads\yt-dlp.exe";
        private static readonly string Status = "COMPLETED";
        protected static readonly string FFMPEG = @"C:\Users\Codaxy\Downloads\ffmpeg-master-latest-win64-gpl\bin\ffmpeg.exe";

        public string BaseUrl { get; set; }
        public string TaskName { get; set; }

        public Worker() { }
    
        public Worker(string baseUrl, string TaskName)
        {
            this.BaseUrl = baseUrl;
            this.TaskName = TaskName;
        }

        public async Task RunWorker()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri($"{BaseUrl}")
            };

            while (true)
            {
                var response = await httpClient.GetAsync(@"tasks/poll/" + TaskName);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    try
                    {
                        PollResult pollResult = JsonConvert.DeserializeObject<PollResult>(await response.Content.ReadAsStringAsync());

                        Console.WriteLine(pollResult);

                        var value = await DoSomeWork(pollResult);

                        UpdateTaskStatus res = new UpdateTaskStatus
                        {
                            WorkflowInstanceId = pollResult.WorkflowInstanceId,
                            TaskId = pollResult.TaskId,
                            Status = Status,
                            OutputData = value
                        };

                        var jsonUpdate = JsonConvert.SerializeObject(res);
                        var stringContent = new StringContent(jsonUpdate.ToString(), Encoding.UTF8, "application/json");

                        var resultUpdate = await httpClient.PostAsync("tasks", stringContent);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Thread.Sleep(DELAY_MILLISECONDS);
            }
        }

        public async virtual Task<JObject> DoSomeWork(PollResult pollResult)
        {
            throw new NotImplementedException();
        }
    }
}
