using Common;
using Trimmer;

IWorker worker = new TrimmerWorker
{
    BaseUrl = "http://localhost:8080/api/",
    TaskName = "trimmer"
};

await worker.RunWorker();