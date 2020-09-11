using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Com.DanLiris.Service.DealTracking.Lib.Services
{
    public class AzureStorageService: IAzureStorageService
    {
        private IServiceProvider ServiceProvider { get; set; }
        //private CloudStorageAccount StorageAccount { get; set; }
        //private CloudBlobContainer StorageContainer { get; set; }
        private const string TIMESTAMP_FORMAT = "yyyyMMddHHmmssffff";
        
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudBlobContainer _storageContainer;

        public AzureStorageService(IServiceProvider serviceProvider)
        {
            string storageAccountName = Environment.GetEnvironmentVariable("StorageAccountName");
            string storageAccountKey = Environment.GetEnvironmentVariable("StorageAccountKey");
            string storageContainer = "deal-tracking";

            this.ServiceProvider = serviceProvider;
            //this.StorageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountName, storageAccountKey), useHttps: true);
            //this.StorageContainer = this.Configure(storageContainer).GetAwaiter().GetResult();

            _storageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountName, storageAccountKey), useHttps: true);
            _storageContainer = this.Configure(storageContainer).GetAwaiter().GetResult();
        }

        public CloudBlobContainer GetStorageContainer()
        {
            return _storageContainer;
        }

        private async Task<CloudBlobContainer> Configure(string storageContainer)
        {
          //  CloudBlobClient cloudBlobClient = this.StorageAccount.CreateCloudBlobClient();
            CloudBlobClient cloudBlobClient = _storageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(storageContainer);
            await cloudBlobContainer.CreateIfNotExistsAsync();

            BlobContainerPermissions permissions = SetContainerPermission(false);
            await cloudBlobContainer.SetPermissionsAsync(permissions);

            return cloudBlobContainer;
        }

        private BlobContainerPermissions SetContainerPermission(Boolean isPublic)
        {
            BlobContainerPermissions permissions = new BlobContainerPermissions();
            if (isPublic)
                permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            else
                permissions.PublicAccess = BlobContainerPublicAccessType.Off;
            return permissions;
        }

        public string GenerateFileName(string fileName)
        {
            return String.Format("{0}_{1}", DateTime.Now.ToString(TIMESTAMP_FORMAT), fileName);
        }

        public async Task UploadFile(MemoryStream stream, string Module, string fileName)
        {
            stream.Position = 0;
           // CloudBlobContainer container = this.StorageContainer;
            CloudBlobContainer container = _storageContainer;
            CloudBlobDirectory dir = container.GetDirectoryReference(Module);
            CloudBlockBlob blob = dir.GetBlockBlobReference(fileName);
            await blob.UploadFromStreamAsync(stream);
        }

        public async Task<MemoryStream> DownloadFile(string Module, string fileName)
        {
           // CloudBlobContainer container = this.StorageContainer;
            CloudBlobContainer container = _storageContainer;
            CloudBlobDirectory dir = container.GetDirectoryReference(Module);
            CloudBlockBlob blob = dir.GetBlockBlobReference(fileName);
            await blob.FetchAttributesAsync();

            MemoryStream stream = new MemoryStream();
            await blob.DownloadToStreamAsync(stream);

            return stream;
        }

        public async Task DeleteImage(string Module, string fileName)
        {
            //CloudBlobContainer container = this.StorageContainer;
            CloudBlobContainer container = _storageContainer;
            CloudBlobDirectory dir = container.GetDirectoryReference(Module);

            CloudBlockBlob blob = dir.GetBlockBlobReference(fileName);
            await blob.DeleteIfExistsAsync();
        }
    }
}
