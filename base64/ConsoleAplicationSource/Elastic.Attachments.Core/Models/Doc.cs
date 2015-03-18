namespace Elastic.Attachments.Core.Models
{
    using System;

    public class Doc : BaseDoc
    {
        /// <summary>
        /// Document title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Document comments (if any)
        /// </summary>
        public string Comments { get; set; }
        /// <summary>
        /// Document footnotes (if any)
        /// </summary>
        public string Footnotes { get; set; }
        /// <summary>
        /// Is it an Attachment or Not
        /// </summary>
        public Boolean IsAttachment { get; set; }
        /// <summary>
        /// Parent Id - this should be the email id of the document
        /// </summary>
        public string ParentId { get; set; }
    }
}