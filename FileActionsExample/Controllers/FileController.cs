using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace FileActionsExample.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase{
    
        [HttpPost("/small-files")]
        public async Task<bool> UploadSmallFiles(IFormFile file){
            try{
                if (file.Length > 0){
                    string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                
                    if (!Directory.Exists(path)){
                        Directory.CreateDirectory(path);
                    }

                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create)){
                        await file.CopyToAsync(fileStream);
                    }

                    return true;
                }
            }catch (Exception){
            }

            return false;
        }

        //FOR LARGE FILES USE STREAMING

        [HttpGet("/get-image/{id}")]
        public async Task<IActionResult> GetImage(string id){
            var path = Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles")), id);
            var stream = new FileStream(path, FileMode.Open);

            //FileStreamResult ControllerBase.File(Stream fileStream, string contentType, string? fileDownloadName)
            return File(stream, "application/octet-stream", id);
        }
    }
}