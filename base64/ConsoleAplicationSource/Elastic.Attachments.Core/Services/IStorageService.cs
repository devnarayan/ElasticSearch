// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStorageService.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Interface of storage
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Elastic.Attachments.Core.Models;

    /// <summary>
    /// Interface of storage
    /// </summary>
    public interface IStorageService
    {
        /// <summary>
        /// Download file from blob storage by local path
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns>BlobItem</returns>
        Task<BlobItem> DownloadFileAsync(string localPath);

        /// <summary>
        /// Download file from blob storage by local path
        /// </summary>
        /// <param name="localPath"></param>
        /// <returns>BlobItem</returns>
        BlobItem DownloadFile(string localPath);


        /// <summary>
        /// Download files from container of blob storage 
        /// </summary>
        /// <param name="containerName">Conatiner name</param>
        /// <returns>BlobItem</returns>
        IEnumerable<BlobItem> DownloadFiles(string containerName = null);
    }
}