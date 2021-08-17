using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DMSOnlineStore.WebUI.FileService
{
    public class FileService
    {
        private readonly UploadCore _uploadCore;

        public FileService(UploadCore uploadCore)
        {
            _uploadCore = uploadCore;
        }

        public Task<string> LocalUpload(IFormFile file, string folderName)
        {

            string url;
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                var filename = Rename() + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/" + folderName, filename);
                var stream = new FileStream(path, FileMode.Create);
                var result = file.CopyToAsync(stream);
                result.Wait();
                if (result.IsCompletedSuccessfully)
                {
                    url = _uploadCore.GetBaseUrl() + "/uploads/" + folderName + "/" + filename;
                    stream.Close();
                }
                else
                {
                    url = _uploadCore.GetBaseUrl() + "/uploads/default.jpg";
                }
            }
            else
            {
                url = _uploadCore.GetBaseUrl() + "/uploads/default.jpg";
            }
            return Task.FromResult(url);
        }
        private static string Rename()
        {
            var random = new Random();
            var randomNumber = random.Next(10000, 99999);
            var name = randomNumber.ToString();
            return name;
        }
    }
}
