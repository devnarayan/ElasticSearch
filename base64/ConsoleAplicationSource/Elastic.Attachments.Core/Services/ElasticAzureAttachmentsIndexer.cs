// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElasticAzureAttachmentsIndexer.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Main Endpoint of Module. Class of Indexer  (download files from azure blob storage and upload in elasticsearch)
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Web;

    /// <summary>
    /// Main Endpoint of Module. Class of Indexer  (download files from azure blob storage and upload in elasticsearch)
    /// </summary>
    public class ElasticAzureAttachmentsIndexer : IAttachmentsIndexer
    {
        /// <summary>
        /// Storage service
        /// </summary>
        private readonly IStorageService storageService;

        /// <summary>
        /// Search engine service
        /// </summary>
        private readonly ISearchEngineService searchEngineService;

        /// <summary>
        /// Strategy of convert blob item to doc
        /// </summary>
        private readonly IConverterObjectsStrategy converterObjectsStrategy;

        public ElasticAzureAttachmentsIndexer(IStorageService storageService, ISearchEngineService searchEngineService, IConverterObjectsStrategy converterObjectsStrategy)
        {
            this.storageService = storageService;
            this.searchEngineService = searchEngineService;
            this.converterObjectsStrategy = converterObjectsStrategy;
        }

        #region Async Methods

        /// <summary>
        /// Index file by local path of storage
        /// </summary>
        /// <param name="uri">Local path (example, /demo2/demo2/1/1/10044/emailAttachments/Excel Training.docx)</param>
        /// <returns></returns>
        public async Task<bool> IndexAsync(string uri)
        {
            uri = HttpUtility.UrlDecode(uri);
            var file = await this.storageService.DownloadFileAsync(uri);
            if (file != null)
            {
                var item = this.converterObjectsStrategy.Convert(file);
                return await this.searchEngineService.IndexAsync(item);
            }

            return false;

        }

        /// <summary>
        /// Index files from container of storage
        /// </summary>
        /// <param name="containerName">Container name (example, demo2)</param>
        /// <returns></returns>
        public async Task<bool> IndexFromContainerAsync(string containerName = null)
        {
            var result = true;
            foreach (var file in this.storageService.DownloadFiles(containerName))
            {
                try
                {
                    if (file == null)
                    {
                        continue;
                    }

                    var item = this.converterObjectsStrategy.Convert(file);

                    var r = await this.searchEngineService.IndexAsync(item);
                    if (!r) result = false;
                }
                catch (Exception ex)
                {
                    result = false;
                    Console.WriteLine("An error occured: " + ex.Message);
                }
            }

            return result;
        }

        #endregion

        #region Sync Methods

        /// <summary>
        /// Index file by local path of storage
        /// </summary>
        /// <param name="uri">Local path (example, /demo2/demo2/1/1/10044/emailAttachments/Excel Training.docx)</param>
        public bool Index(string uri)
        {
            uri = HttpUtility.UrlDecode(uri);
            var file = this.storageService.DownloadFile(uri);
            if (file != null)
            {
                var item = this.converterObjectsStrategy.Convert(file);
                return this.searchEngineService.Index(item);
            }

            return false;
        }

        /// <summary>
        /// Index files from container of storage
        /// </summary>
        /// <param name="containerName">Container name (example, demo2)</param>
        public bool IndexFromContainer(string containerName = null)
        {
            var result = true;
            foreach (var file in this.storageService.DownloadFiles(containerName))
            {
                try
                {
                    if (file == null)
                        continue;

                    var item = this.converterObjectsStrategy.Convert(file);
                    var r = this.searchEngineService.Index(item);
                    if (!r) result = false;
                }
                catch (Exception ex)
                {
                    result = false;
                    Console.WriteLine("An error occured: " + ex.Message);
                }
               
            }

            return result;
        }

        #endregion
    }
}
