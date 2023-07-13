using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Common.TaskConfig;

namespace PrepareVideos
{
    internal class PrepareVideosWorker : Worker
    {
        public PrepareVideosWorker() { }

        public PrepareVideosWorker(string baseUrl, string TaskName)
            : base(baseUrl, TaskName) { }

        public async override Task<JObject> DoSomeWork(PollResult pollResult)
        {
            var tasksI = pollResult.InputData["videosToProcess"].ToObject<List<VideoToProcess>>();
            var tasks = new List<TaskConfig>();

            Dictionary<string, VideoToProcess> mapTasksI = new Dictionary<string, VideoToProcess>();
            for(int i = 0; i < tasksI?.Count; i++)
            {
                mapTasksI.Add("key_" + i, tasksI[i]);

                tasks.Add(new TaskConfig
                {
                    Name = "download_and_process",
                    TaskReferenceName = "key_" + i,
                    Type = "SUB_WORKFLOW",
                    SubWorkflowParam = new SubWorkflowParamModel
                    {
                        Name = "download_and_process",
                        Version = 1
                    }
                }) ;
            }

            //var returnUpdate = new JObject(new JProperty("dynamicTasks", tasks), new JProperty("dynamicTasksI", mapTasksI));

            var returnUpdate = JObject.FromObject(new PreparedVideosOutput
            {
                DynamicTasks = tasks,
                DynamicTasksI = mapTasksI
            });

            return returnUpdate;
        }
    }
}
