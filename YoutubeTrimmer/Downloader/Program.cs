using Common;
using Downloader;

IWorker worker = new DownloaderWorker
{
    BaseUrl = "http://localhost:8080/api/",
    TaskName = "downloader"
};

await worker.RunWorker();