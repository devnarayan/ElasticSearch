using System;
using System.Collections.Generic;

namespace Elastic.Attachments.Core.Models
{
    using Nest;

    public class BaseDoc
    {
        /// <summary>
        /// Document identifier (it's the combination of client id, case id, and filename)
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Location of the document
        /// </summary>
        public string StorageLocation { get; set; }
        ///// <summary>
        ///// User identifier
        ///// </summary>
        //public string UserId { get; set; }
        /// <summary>
        /// Client identifier
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// Case identifier
        /// </summary>
        public string CaseId { get; set; }
        /// <summary>
        /// File type
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// Document body (plain text)
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// Tags. Example data:
        /// <pre>{"important": true, "favourite": true } </pre>
        /// </summary>
        public Dictionary<string, bool> Tags { get; set; }
        /// <summary>
        /// ES document kind
        /// </summary>
        /// <returns>email or doc</returns>
        public string Kind
        {
            get { return GetType().Name.ToLower(); }
        }
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Attachment content
        /// </summary>
        [ElasticProperty(Type = FieldType.Attachment, TermVector = TermVectorOption.WithPositionsOffsets, Store = true)]
        public string File { get; set; }
    }
}
