using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Lib.Services
{
   public interface IAzureStorageService
    {
        CloudBlobContainer GetStorageContainer();
        
        Task UploadFile(MemoryStream stream, string Module, string fileName);
        Task<MemoryStream> DownloadFile(string Module, string fileName);
        string GenerateFileName(string fileName);
        Task DeleteImage(string Module, string fileName);

    }
}
