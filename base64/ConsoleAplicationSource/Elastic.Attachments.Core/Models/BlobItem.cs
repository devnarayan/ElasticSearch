// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlobItem.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Item form blob storage
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Models
{
    using System;
    using System.IO;

    /// <summary>
    /// Item form blob storage
    /// </summary>
    public class BlobItem
    {
        /// <summary>
        /// Name of file
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Uri of file
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Stream of file
        /// </summary>
        public MemoryStream Stream { get; set; }
    }
}
