namespace Elastic.Attachments.Core.Models
{
    using System;
    using System.Collections.Generic;

    public class Email : BaseDoc
    {
        /// <summary>
        /// To field
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// From field
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Email subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Has the attachment? true or false
        /// </summary>
        public Boolean HasAttachment { get; set; }
        /// <summary>
        /// HTML body of the email
        /// </summary>
        public string EmailBody { get; set; }
        /// <summary>
        /// Text body of the email
        /// </summary>
        public string EmailBodyHTML { get; set; }
        /// <summary>
        /// List of attachments, example data: 
        /// <pre>["datageekslaw\\lawhssm\\1\\1\\1\\emailAttachments\\image001.gif","datageekslaw\\lawhssm\\1\\1\\1\\emailAttachments\\LSI LED Site Ltg_xgb3-datasheet.pdf",],</pre>
        /// </summary>
        public Dictionary<string, int> Attachements { get; set; }
        /// <summary>
        /// Attachment count by extension. Example data:
        /// <pre>{"pdf": 5, "docx": 1} </pre>
        /// </summary>
        public Dictionary<string, int> AttachmentCount { get; set; }
        //public IEnumerable<string> AttachmentList { get; set; }
        public IEnumerable<string> RecipientsList { get; set; }

        /// <summary>
        /// My thought is that we should keep the meta data and content of the attahments
        /// within the email so when we search we can search not only the email but the attachment(s) content as well
        /// </summary>
        public List<Doc> AttachmentList { get; set; }


    }

    //public class Email
    //{
    //    [ElasticProperty(Type = FieldType.Attachment, TermVector = TermVectorOption.WithPositionsOffsets, Store = true)]
    //    public IList<string> File { get; set; }
    //}
}
