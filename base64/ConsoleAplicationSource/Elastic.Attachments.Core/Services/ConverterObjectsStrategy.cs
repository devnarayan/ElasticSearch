// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterObjectsStrategy.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Strategy of convert blob item to document
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace Elastic.Attachments.Core.Services
{
    using System;

    using Elastic.Attachments.Core.Extensions;
    using Elastic.Attachments.Core.Models;

    /// <summary>
    /// Strategy of convert blob item to document
    /// </summary>
    public class ConverterObjectsStrategy : IConverterObjectsStrategy
    {
        /// <summary>
        /// Convert storage item to docuemnt
        /// </summary>
        /// <param name="item">Storage item</param>
        /// <returns>Document</returns>
        public BaseDoc Convert(BlobItem item)
        {
            var segments = item.Uri.Segments.Select(x => x.TrimEnd('/')).Skip(2).ToArray();
            var clientName = segments[0];
            var clientId = segments[1];
            var caseId = segments[2];
            var fileNameMsg = segments[3];

            var list = item.Uri.Segments.ToList();
            list.RemoveAt(list.Count - 1);
            list.Add(item.Name);
            var fileStorageLocation = string.Join("", list);

            var base64 = System.Convert.ToBase64String(item.Stream.ToArray());

            return new Doc()
                       {
                           ClientId = clientId,
                           CaseId = caseId,
                           FileType = item.Name.GetFileType(),
                           Id = string.Format("{0}-{1}-{2}.msg-{3}", clientId, caseId, fileNameMsg, item.Name),
                           StorageLocation = fileStorageLocation,
                           File = base64,
                           IsAttachment = true,
                           ParentId = string.Format("{0}-{1}-{2}.msg", clientId, caseId, fileNameMsg),
                           Timestamp = DateTime.UtcNow,
                           //File = new Attachment()
                           //           {
                           //               Content = base64,
                           //               ContentType = item.Name.GetMIMEType(),
                           //               Name = item.Name
                           //           },
                           Title = item.Name.GetFileName(),
                       };
        }
    }
}
