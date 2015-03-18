// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConverterObjectsStrategy.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Interface of strategy convert storage item to docuemnt
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Services
{
    using Elastic.Attachments.Core.Models;

    /// <summary>
    /// Interface of strategy convert storage item to docuemnt
    /// </summary>
    public interface IConverterObjectsStrategy
    {
        /// <summary>
        /// Convert storage item to docuemnt
        /// </summary>
        /// <param name="item">Storage item</param>
        /// <returns>Document</returns>
        BaseDoc Convert(BlobItem item);
    }
}