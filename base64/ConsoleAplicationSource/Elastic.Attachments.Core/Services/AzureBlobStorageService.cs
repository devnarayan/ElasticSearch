// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AzureBlobStorageService.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Azure Blob Storage Service
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Elastic.Attachments.Core.Extensions;
    using Elastic.Attachments.Core.Models;

    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// Azure Blob Storage Service
    /// </summary>
    public class AzureBlobStorageService : IStorageService
    {
        /// <summary>
        /// Storage account
        /// </summary>
        private CloudStorageAccount _storageAccount;

        /// <summary>
        /// Blob client
        /// </summary>
        private CloudBlobClient _blobClient;

        /// <summary>
        /// Default container name
        /// </summary>
        private string defaultContainerName;

        public AzureBlobStorageService()
        {
            _storageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
             _blobClient = this._storageAccount.CreateCloudBlobClient();
             this.defaultContainerName = ConfigurationManager.AppSettings["StorageContainerName"];
        }

        /// <summary>
        /// Download file from blob storage by local path
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns>BlobItem</returns>
        public async Task<BlobItem> DownloadFileAsync(string localPath)
        {
            var paths = localPath.Split(new[] { "/", "//" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (paths.Count < 2)
            {
                return null;
            }

            var conainerName = paths.First();
            var pathFile = string.Format("/{0}", string.Join("/", paths.Skip(1)));


            var container = _blobClient.GetContainerReference(conainerName);
            var blockBlob = await container.GetBlobReferenceFromServerAsync(pathFile);
            return this.ToBlobItem(blockBlob);
        }

        /// <summary>
        /// Download file from blob storage by local path
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns>BlobItem</returns>
        public BlobItem DownloadFile(string localPath)
        {
            var paths = localPath.Split(new[] { "/", "//" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (paths.Count < 2)
            {
                return null;
            }

            var conainerName = paths.First();
            var pathFile = string.Join("/", paths.Skip(1));


            var container = _blobClient.GetContainerReference(conainerName);
            var blockBlob = container.GetBlockBlobReference(pathFile);
            return this.ToBlobItem(blockBlob);
        
        }

        /// <summary>
        /// Download files from container of blob storage 
        /// </summary>
        /// <param name="containerName">Conatiner name</param>
        /// <returns>BlobItem</returns>
        public IEnumerable<BlobItem> DownloadFiles(string containerName = null)
        {
            if (string.IsNullOrWhiteSpace(containerName))
            {
                containerName = defaultContainerName;
            }

            // Retrieve a reference to a container. 
            var container = _blobClient.GetContainerReference(containerName);
            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, true, BlobListingDetails.Metadata))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    var blob = (CloudBlockBlob)item;
                    BlobItem res = null;
                    try
                    {
                        res = this.ToBlobItem(blob);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occured: " + ex.Message);
                    }
                    yield return res;

                }
            }
        }

        /// <summary>
        /// Convert to BlobItem
        /// </summary>
        /// <param name="blob">Blob</param>
        /// <returns>BlobItem</returns>
        private BlobItem ToBlobItem(ICloudBlob blob)
        {
            if (blob != null && blob.Name.IsSupportFile())
            {
                Console.WriteLine("Block blob of length {0}: {1}", blob.Properties.Length, blob.Uri);
                // Read content
                var ms = new MemoryStream();
                blob.DownloadToStream(ms);
                ms.Position = 0;
                return new BlobItem() { Name = blob.Name.GetFileName(), Uri = blob.Uri, Stream = ms };
            }

            return null;
        }
    }
}
