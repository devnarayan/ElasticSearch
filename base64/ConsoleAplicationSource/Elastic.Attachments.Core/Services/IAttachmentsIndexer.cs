// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IElasticAttachmentsIndexer.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Main Endpoint of Module. Interface of Indexer and .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Main Endpoint of Module. Interface of Indexer (download files from storage and upload in search engine)
    /// </summary>
    public interface IAttachmentsIndexer
    {
        #region Async Methods

        /// <summary>
        /// Index file by local path of storage
        /// </summary>
        /// <param name="uri">Local path (example, /demo2/demo2/1/1/10044/emailAttachments/Excel Training.docx)</param>
        /// <returns></returns>
        Task<bool> IndexAsync(string uri);

        /// <summary>
        /// Index files from container of storage
        /// </summary>
        /// <param name="containerName">Container name (example, demo2)</param>
        /// <returns></returns>
        Task<bool> IndexFromContainerAsync(string containerName = null);

        #endregion

        #region Sync Methods

        /// <summary>
        /// Index file by local path of storage
        /// </summary>
        /// <param name="uri">Local path (example, /demo2/demo2/1/1/10044/emailAttachments/Excel Training.docx)</param>
        bool Index(string uri);

        /// <summary>
        /// Index files from container of storage
        /// </summary>
        /// <param name="containerName">Container name (example, demo2)</param>
        bool IndexFromContainer(string containerName = null);


        #endregion
    }
}