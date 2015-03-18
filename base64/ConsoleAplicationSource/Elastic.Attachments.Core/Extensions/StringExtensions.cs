// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Elastic.Attachments">
//   Elastic.Attachments
// </copyright>
// <summary>
//   Extensions of strings
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Elastic.Attachments.Core.Extensions
{
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    /// Extensions of strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Check is file in support format
        /// </summary>
        /// <param name="fileName">FileName</param>
        /// <returns>True if support format</returns>
        public static bool IsSupportFile(this string fileName)
        {
            var extension = Path.GetExtension(fileName);
            var regex = new Regex(@"^\.(xls|xlsx|doc|docx|pdf|tiff|tif|htm|html|jpg|png|jpeg|txt)", RegexOptions.IgnoreCase);
            return extension != null && regex.IsMatch(extension);
        }

        /// <summary>
        /// Get file type by file name
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>File type</returns>
        public static string GetFileType(this string fileName)
        {
            var extension = Path.GetExtension(fileName);

            return extension != null ? extension.Replace(".", "").ToLower() : string.Empty;
        }

        /// <summary>
        /// Get mime-type by file name
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns>Mime type</returns>
        public static string GetMIMEType(this string fileName)
        {
            return MimeMapping.GetMimeMapping(fileName);
        }

        /// <summary>
        /// Get file name by filePath
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>File name</returns>
        public static string GetFileName(this string filePath)
        {
            return Path.GetFileName(filePath);
        }

    }
}
