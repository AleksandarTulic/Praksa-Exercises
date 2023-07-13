using Common;
using PrepareVideos;

IWorker worker = new PrepareVideosWorker
{
    BaseUrl = "http://localhost:8080/api/",
    TaskName = "prepare_videos"
};

await worker.RunWorker();